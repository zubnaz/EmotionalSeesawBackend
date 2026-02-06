using EmotionalSeesaw_Domain.Entities;

namespace EmotionalSeesaw_Application.Interfaces;

public interface ICalendarRepository
{
    public Task AddAsync(CalendarEntity calendarEntity);
    public Task<CalendarEntity?> GetByIdAsync(Guid Id);
}
