using EmotionalSeesaw_Application.Interfaces.CQRS;

namespace EmotionalSeesaw_Application.Requests.Command.SummaryAnalysis;

public record SummaryAnalysisCommand(Guid Id, Guid UserId) : ICommand;
