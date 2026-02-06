namespace EmotionalSeesaw_Domain.Entities;

public class SummaryOfDayEntity
{
    public Guid Id { get; set; }
    public required string Text { get; set; }
    public ICollection<EmotionalStateEntity>? EmotionalStates { get; set; }
    public string? Advice { get; set; }
    public required DateOnly Date { get; set; }
    public required User User { get; set; }
    public Guid UserId { get; set; }
    //public required CalendarEntity Calendar { get; set; }
    //public Guid CalendarId { get; set; }
}
