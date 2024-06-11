using Bambus.DTOs.MessageDtos;
using Bambus.Models;
using FluentValidation;

namespace Bambus.Validators.Message
{
    public class AddMessageValidator : AbstractValidator<AddMessageDTO>
    {
        public AddMessageValidator()
        {
            RuleFor(x => x.SenderId).NotNull().WithMessage("SenderId is required");
            RuleFor(x => x.ReceiverId).NotNull().WithMessage("ReceiverId is required");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Date is required");
            RuleFor(x => x.Text).NotEmpty().WithMessage("Text is required");
            RuleFor(x => x.Type).NotNull().WithMessage("Type is required");
        }
    }
}
