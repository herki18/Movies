using FluentValidation;
using Movies.Api.Contracts.Queries;

namespace Movies.Api.Validators
{
    public class MoviesQueryValidator : AbstractValidator<MoviesQuery>
    {
        public MoviesQueryValidator()
        {
            RuleFor(y => y.YearOfRelease)
                .NotEmpty()
                .NotNull()
                .When(t => t.Title == "")
                .When(g => g.Genres == null)
                .WithMessage("Invalid criteria");

            RuleFor(t => t.Title)
                .NotEmpty()
                .When(y => y.YearOfRelease == null)
                .When(g => g.Genres == null)
                .WithMessage("Invalid criteria");

            RuleFor(g => g.Genres)
                .NotNull()
                .When(t => t.Title == "")
                .When(y => y.YearOfRelease == null)
                .WithMessage("Invalid criteria");
        }
    }
}