using EmotionalSeesaw_Application.Interfaces;
using EmotionalSeesaw_Application.Interfaces.CQRS;
using EmotionalSeesaw_Domain.Entities;

namespace EmotionalSeesaw_Application.Requests.Command.CreateSummaryOfDay;

public class CreateSummaryOfDayCommandHandler(IUserRepository userRepository,
                                              ISummaryOfDayRepository summaryOfDayRepository) : ICommandHandler<CreateSummaryOfDayCommand, Guid>
{
    public async Task<Guid> Handle(CreateSummaryOfDayCommand request)
    {
        var user = await userRepository.GetByIdAsync(request.UserId);

        if (user == null) 
        { 
            throw new KeyNotFoundException("User not found");
        }
        DateOnly creatingDate = new DateOnly(request.Year, request.Month, request.Day);

        if(creatingDate > DateOnly.FromDateTime(DateTime.UtcNow))
        {
            throw new InvalidOperationException("Cannot create summary for future dates");
        }

        SummaryOfDayEntity? summaryOfDay = await summaryOfDayRepository.ExistSummaryByDateAsync(request.UserId, creatingDate);
        if (summaryOfDay != null)
        {
            await summaryOfDayRepository.RemoveAsync(summaryOfDay);
        }

        summaryOfDay = new SummaryOfDayEntity()
        {
            Id = Guid.NewGuid(),
            Text = request.Text,
            UserId = request.UserId,
            Date = creatingDate,
            User = user
        };

        await summaryOfDayRepository.AddAsync(summaryOfDay);

        return summaryOfDay.Id;
    }
}
