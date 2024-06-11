using Bambus.DTOs.RatingDtos;
using FluentValidation;

namespace Bambus.Validators.Rating
{
    public class UpdateRatingValidator : AbstractValidator<UpdateRatingDTO>
    {
        public UpdateRatingValidator()
        {
            RuleFor(x => x.RatingId).NotEmpty().WithMessage("RatingId is required");
            RuleFor(x => x.Rating).NotEmpty().WithMessage("Rating is required").InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5");
            RuleFor(x => x.IsRecommended).NotNull().WithMessage("IsRecommended is required");
            RuleFor(x => x.Comment).MaximumLength(500).WithMessage("Comment must be less than 500 characters");
        }
    }
}
