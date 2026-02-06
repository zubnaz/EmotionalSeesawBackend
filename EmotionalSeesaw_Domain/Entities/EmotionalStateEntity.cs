namespace EmotionalSeesaw_Domain.Entities;

public class EmotionalStateEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Image { get; set; }
    public ICollection<SummaryOfDayEntity>? SummariesOfDays { get; set; }
}
