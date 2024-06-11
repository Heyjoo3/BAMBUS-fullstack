using Bambus.DTOs.ItemDtos;
using FluentValidation;

namespace Bambus.Validators.Item
{
    public class UpdateItemValidator : AbstractValidator<UpdateItemDTO>
    {
        public UpdateItemValidator()
        {
            RuleFor(x => x.ItemId).NotEmpty();
            RuleFor(x => x.Condition).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Type).NotEmpty();
        }
    }
}
