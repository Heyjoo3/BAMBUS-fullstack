using AutoMapper;
using Bambus.Data;
using Bambus.DTOs.UserDtos;
using Bambus.Models;
using Bambus.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bambus.Services.User;
    public class UserService : IUserService
    {
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public UserService(DataContext context, IMapper mapper, IConfiguration configuration)
    {
        _context = context;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<ServiceResponse<List<GetUserDTO>>> DeleteUser(int id)
    {
        ServiceResponse<List<GetUserDTO>> serviceResponse = new ServiceResponse<List<GetUserDTO>>();
        UserModel user = await _context.Users.FirstAsync(u => u.UserId == id);
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        serviceResponse.Data = _context.Users.Select(u => _mapper.Map<GetUserDTO>(u)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetUserDTO>>> GetAllUser()
    {
        ServiceResponse<List<GetUserDTO>> serviceResponse = new ServiceResponse<List<GetUserDTO>>();
        List<UserModel> dbUsers = await _context.Users.ToListAsync();
        serviceResponse.Data = dbUsers.Select(u => _mapper.Map<GetUserDTO>(u)).ToList();    
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetUserDTO>> Login(LoginDTO loginDTO)
    {
        ServiceResponse<GetUserDTO> serviceResponse = new ServiceResponse<GetUserDTO>();
        UserModel? user = await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(loginDTO.Email));
        serviceResponse.Data = _mapper.Map<GetUserDTO>(user);
        if (user == null)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Login fehlgeschlagen.";
        }
        else if (!Data.Utility.VerifyPasswordHash(loginDTO.Password, user.PasswordHash, user.PasswordSalt))
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Login fehlgeschlagen.";
        }
        else
        {
            serviceResponse.Data = _mapper.Map<GetUserDTO>(user);
            serviceResponse.Success = true;
            serviceResponse.Message = "Login erfolgreich.";
            serviceResponse.Token = CreateToken(user);
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetUserDTO>> Register(RegisterDTO registerDTO)
    {
        ServiceResponse<GetUserDTO> serviceResponse = new ServiceResponse<GetUserDTO>();
        UserModel user = _mapper.Map<UserModel>(registerDTO);
        if (await _context.Users.AnyAsync(u => u.Email.Equals(user.Email)))
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Email bereits vergeben.";
            return serviceResponse;
        }
        if (await _context.Users.AnyAsync(u => u.Username.Equals(user.Username)))
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Username bereits vergeben.";
            return serviceResponse;
        }

        Data.Utility.CreatePasswordHash(registerDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        user.NumberLoans = 0;
        user.NumberExtensions = 0;
        user.NumberMissedReturns = 0;

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        serviceResponse.Data = _mapper.Map<GetUserDTO>(user);
        serviceResponse.Token = CreateToken(user);
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetUserDTO>>> UpdateUser(UpdateUserDTO updateUserDTO)
    {
        ServiceResponse<List<GetUserDTO>> serviceResponse = new ServiceResponse<List<GetUserDTO>>();
        UserModel? user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == updateUserDTO.UserId);
        if (user == null)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "User nicht gefunden.";
            return serviceResponse;
        }
        if (updateUserDTO.Email != null)
        {
            user.Email = updateUserDTO.Email;
        }
        if (updateUserDTO.Username != null)
        {
            user.Username = updateUserDTO.Username;
        }
        if (updateUserDTO.Password != null)
        {
            user.Password = updateUserDTO.Password;
            Data.Utility.CreatePasswordHash(updateUserDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
        }
        if (updateUserDTO.FirstName != null)
        {
            user.FirstName = updateUserDTO.FirstName;
        }
        if (updateUserDTO.LastName != null)
        {
            user.LastName = updateUserDTO.LastName;
        }
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        serviceResponse.Data = _context.Users.Select(u => _mapper.Map<GetUserDTO>(u)).ToList();
        return serviceResponse;
    }

    private string CreateToken(UserModel user)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        SymmetricSecurityKey key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value)
        );

        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = creds
        };

        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}

