using EmotionalSeesaw_Application.Interfaces;
using EmotionalSeesaw_Application.Interfaces.CQRS;
using EmotionalSeesaw_Domain.Entities;

namespace EmotionalSeesaw_Application.Requests.Query.GetSummariesOfMonth;

public class GetSummariesOfMonthQueryHandler(ISummaryOfDayRepository repository) : IQueryHandler<GetSummariesOfMonthQuery, ICollection<SummaryOfDayEntity>>
{
    public async Task<ICollection<SummaryOfDayEntity>> Handle(GetSummariesOfMonthQuery request)
    {
        var summaries = await repository.GetSummariesByMonth(request.UserId, request.Year, request.Month);

        return summaries.ToArray();
    }
}
