using EmotionalSeesaw_Application.Interfaces;
using EmotionalSeesaw_Application.Interfaces.CQRS;
using EmotionalSeesaw_Domain.Entities;

namespace EmotionalSeesaw_Application.Requests.Query.GetSummaryById;

public class GetSummaryByIdQueryHandler(ISummaryOfDayRepository summaryOfDayRepository) : IQueryHandler<GetSummaryByIdQuery, SummaryOfDayEntity>
{
    public async Task<SummaryOfDayEntity> Handle(GetSummaryByIdQuery request)
    {
        var summary = await summaryOfDayRepository.GetByIdIncludedAsync(request.Id);

        if(summary == null)
        {
            throw new KeyNotFoundException("Summary not found");
        }
        Console.WriteLine("Count: " + summary.EmotionalStates.Count());
        return summary;
    }
}
