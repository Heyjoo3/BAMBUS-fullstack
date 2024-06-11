using Bambus.DTOs.UserDtos;
using FluentValidation;

namespace Bambus.Validators.User
{
    public class RegisterDTOValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterDTOValidator()
        {
            RuleFor(model => model.Username).NotEmpty().WithMessage("Username is required");
            RuleFor(model => model.Password).NotEmpty().WithMessage("Password is required").MinimumLength(6).WithMessage("Password must be at least 6 characters long");
            RuleFor(model => model.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Email is not valid");
            RuleFor(model => model.FirstName).NotEmpty().WithMessage("First name is required");
            RuleFor(model => model.LastName).NotEmpty().WithMessage("Last name is required");
        }
    }
}
