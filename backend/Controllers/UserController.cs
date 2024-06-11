using Microsoft.AspNetCore.Mvc;
using Bambus.DTOs.UserDtos;
using Bambus.Services.User;
using Bambus.Validators.User;
using Microsoft.AspNetCore.Authorization;

namespace Bambus.Controllers
{
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            try
            {
                var validator = new RegisterDTOValidator();
                var validationResult = await validator.ValidateAsync(registerDTO);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }
                return Ok(await _userService.Register(registerDTO));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            try
            {
                var validator = new LoginDTOValidator();
                var validationResult = await validator.ValidateAsync(loginDTO);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }
                return Ok(await _userService.Login(loginDTO));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserDTO updateUserDTO)
        {
            try
            {
                var validator = new UpdateUserDTOValidator();
                var validationResult = await validator.ValidateAsync(updateUserDTO);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }
                return Ok(await _userService.UpdateUser(updateUserDTO));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPost("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                return Ok(await _userService.DeleteUser(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                return Ok(await _userService.GetAllUser());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
