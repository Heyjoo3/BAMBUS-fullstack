using Bambus.DTOs.ItemDtos;
using FluentValidation;

namespace Bambus.Validators.Item
{
    public class AddItemValidator : AbstractValidator<AddItemDTO>
    {
        public AddItemValidator()
        {
            RuleFor(x => x.Title).NotNull().WithMessage("Title is required");
            RuleFor(x => x.Condition).NotNull().WithMessage("Condition is required");
            RuleFor(x => x.Type).NotNull().WithMessage("Type is required");
        }
    }
}
