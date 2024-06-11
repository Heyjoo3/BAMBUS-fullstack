using Bambus.DTOs.UserDtos;
using FluentValidation;

namespace Bambus.Validators.User
{
    public class LoginDTOValidator : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
        {
            RuleFor(model => model.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(model => model.Email).NotEmpty().WithMessage("Email is required");
        }
    }
}
