using EmotionalSeesaw_Application.Common;
using EmotionalSeesaw_Application.Interfaces;
using EmotionalSeesaw_Application.Interfaces.CQRS;
using EmotionalSeesaw_Domain.Common;
using EmotionalSeesaw_Domain.Entities;
using Newtonsoft.Json;


namespace EmotionalSeesaw_Application.Requests.Command.SummaryAnalysis;

public class SummaryAnalysisCommandHandler(ISummaryOfDayRepository summaryOfDayRepository, 
                                    IEmotionalStateRepository emotionalStateRepository,
                                    GeminiService geminiService) : ICommandHandler<SummaryAnalysisCommand>
{
    public async Task Handle(SummaryAnalysisCommand request)
    {
        var summary = await summaryOfDayRepository.GetByIdAsync(request.Id);
        if (summary == null)
        {
            throw new KeyNotFoundException("Summary not found");
        }
        if (summary.UserId != request.UserId)
        {
            throw new KeyNotFoundException("User hasn't summary with this Id");
        }
        if (await summaryOfDayRepository.IsAnalyzedAsync(summary.Id) == true)
        {
            throw new InvalidOperationException("This day is already analyzed");
        }
        var emotionalStateNames = await emotionalStateRepository.GetAsync<string>(es => es.Name);

        
        var listOfEmotionalStates = String.Join(",", emotionalStateNames);
        
        var result = await geminiService.RequestAsync(GeminiPrompts.SummaryOfDayAnalysis(summary.Text, listOfEmotionalStates));
        
  
        var analysOfDay = JsonConvert.DeserializeObject<AnalysOfDay>(result);

        foreach (var emotionalState in analysOfDay!.EmotionalStates)
        {
            Console.WriteLine("Emotional State: " + emotionalState.Name);
        }
        Console.WriteLine("Advice: " + analysOfDay!.Advice);
        var emotionalStates = await emotionalStateRepository.GetByNameAsync(analysOfDay!.EmotionalStates.Select(es => es.Name).ToArray() ?? []);
        
        if(emotionalStates == null || emotionalStates.Count == 0)
        {
            throw new KeyNotFoundException("No necessary emotional states were found to describe the day");
        }

        
        summary.EmotionalStates = new List<EmotionalStateEntity>();
        
        foreach (var emotionalState in emotionalStates)
        {
            summary.EmotionalStates.Add(emotionalState);
        }
        summary.Advice = analysOfDay.Advice;

        await summaryOfDayRepository.UpdateAsync(summary);
    }
    
}
