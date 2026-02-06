using Microsoft.AspNetCore.Identity;

namespace EmotionalSeesaw_Domain.Entities;

public class User : IdentityUser<Guid>
{
    public ICollection<SummaryOfDayEntity>? SummariesOfDays { get; set; }
}
