using FluentValidation;
using Movies.Api.Contracts.Queries;

namespace Movies.Api.Validators
{
    public class RatingBodyValidator : AbstractValidator<RatingBody>
    {
        public RatingBodyValidator()
        {
            RuleFor(r => r.Rating)
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(5)
                .NotEmpty();
        }
    }
}
