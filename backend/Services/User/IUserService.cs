using Bambus.Models;
using Bambus.DTOs.UserDtos;

namespace Bambus.Services.User
{
    public interface IUserService
    {
        Task<ServiceResponse<GetUserDTO>> Register(RegisterDTO registerDTO);
        Task<ServiceResponse<GetUserDTO>> Login(LoginDTO loginDTO);
        Task<ServiceResponse<List<GetUserDTO>>> UpdateUser(UpdateUserDTO updateUserDTO);
        Task<ServiceResponse<List<GetUserDTO>>> DeleteUser(int id);
        Task<ServiceResponse<List<GetUserDTO>>> GetAllUser();
    }
}