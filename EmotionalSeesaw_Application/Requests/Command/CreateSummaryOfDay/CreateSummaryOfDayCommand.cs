using EmotionalSeesaw_Application.Interfaces.CQRS;

namespace EmotionalSeesaw_Application.Requests.Command.CreateSummaryOfDay;

public record CreateSummaryOfDayCommand(string Text, int Day, int Month, int Year, Guid UserId) : ICommand<Guid>;
