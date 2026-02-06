using EmotionalSeesaw_Application.Interfaces.CQRS;
using EmotionalSeesaw_Domain.Entities;

namespace EmotionalSeesaw_Application.Requests.Query.GetSummariesOfMonth;

public record GetSummariesOfMonthQuery(Guid UserId, int Month, int Year) : IQuery<ICollection<SummaryOfDayEntity>>;
