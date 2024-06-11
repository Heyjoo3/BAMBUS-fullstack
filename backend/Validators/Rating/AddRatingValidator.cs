using Bambus.DTOs.RatingDtos;
using FluentValidation;

namespace Bambus.Validators.Rating
{
    public class AddRatingValidator : AbstractValidator<AddRatingDTO>
    {
        public AddRatingValidator()
        {
            RuleFor(x => x.ItemId).NotEmpty().WithMessage("ItemId is required");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required");
            RuleFor(x => x.Rating).NotEmpty().WithMessage("Rating is required").InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5");
            RuleFor(x => x.IsRecommended).NotNull().WithMessage("IsRecommended is required");
            RuleFor(x => x.Comment).MaximumLength(500).WithMessage("Comment must be less than 500 characters");
        }
    }
}
