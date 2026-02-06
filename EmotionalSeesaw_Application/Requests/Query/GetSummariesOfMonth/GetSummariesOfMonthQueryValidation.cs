using FluentValidation;

namespace EmotionalSeesaw_Application.Requests.Query.GetSummariesOfMonth;

public class GetSummariesOfMonthQueryValidation : AbstractValidator<GetSummariesOfMonthQuery>
{
    public GetSummariesOfMonthQueryValidation()
    {
        RuleFor(x => x.Year)
            .GreaterThan(2020)
            .WithMessage("Year must be greater than 2020.")
            .LessThanOrEqualTo(DateTime.Now.Year)
            .WithMessage("Year should not be the future.");

        RuleFor(x => x.Month)
            .InclusiveBetween(1, 12)
            .WithMessage("Month must be between 1 and 12.");

        RuleFor(x => x.Month)
            .LessThanOrEqualTo(DateTime.Now.Month)
            .WithMessage("Month should not be the future.")
            .When(x => x.Year == DateTime.Now.Year);
    }
}
