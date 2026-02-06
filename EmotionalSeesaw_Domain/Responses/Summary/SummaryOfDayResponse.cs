using EmotionalSeesaw_Domain.Responses.EmotionalState;

namespace EmotionalSeesaw_Domain.Responses.Summary;

public class SummaryOfDayResponse
{
    public Guid Id { get; set; }
    public required string Text { get; set; }
    public Guid UserId { get; set; }
    public string? Advice { get; set; }
    public DateOnly Date { get; set; }
    public required EmotionalStateResponse[] EmotionalStates { get; set; }
}
