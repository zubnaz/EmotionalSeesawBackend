namespace EmotionalSeesaw_Domain.Entities;

public class CalendarEntity
{
    public Guid UserId { get; set; }
    public required User User { get; set; }
    public ICollection<SummaryOfDayEntity>? SummaryOfDays { get; set; }
}
