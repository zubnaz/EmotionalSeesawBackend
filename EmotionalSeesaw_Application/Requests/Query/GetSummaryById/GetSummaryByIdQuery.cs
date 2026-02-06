using EmotionalSeesaw_Application.Interfaces.CQRS;
using EmotionalSeesaw_Domain.Entities;

namespace EmotionalSeesaw_Application.Requests.Query.GetSummaryById;

public record GetSummaryByIdQuery(Guid Id) : IQuery<SummaryOfDayEntity>;
