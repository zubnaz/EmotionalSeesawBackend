using FluentValidation;

namespace EmotionalSeesaw_Application.Requests.Command.CreateSummaryOfDay;

public class CreateSummaryOfDayCommandValidation : AbstractValidator<CreateSummaryOfDayCommand>
{
    public CreateSummaryOfDayCommandValidation()
    {
        RuleFor(model => model.Year)
            .Equal(DateTime.UtcNow.Year).WithMessage("Reports can only be created for the current year and month.");
        RuleFor(model => model.Month)
            .Equal(DateTime.UtcNow.Month).WithMessage("Reports can only be created for the current year and month.");
        RuleFor(model => model.Text).NotEmpty().WithMessage("Text cannot be empty");
    }
}
