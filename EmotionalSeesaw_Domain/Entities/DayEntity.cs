namespace EmotionalSeesaw_Domain.Entities;

public class DayEntity
{
    public Guid Id { get; set; }
    public required DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    public required CalendarEntity Calendar { get; set; }
    public SummaryOfDayEntity? SummaryOfDay { get; set; }
    public Guid CalendarId { get; set; }
}
