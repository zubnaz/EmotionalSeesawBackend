using EmotionalSeesaw_Application.Interfaces;
using EmotionalSeesaw_Domain.Entities;
using EmotionalSeesaw_Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EmotionalSeesaw_Infrastructure.Repositories;

public class CalendarRepository(EmotionalSeesawDbContext context) : ICalendarRepository
{
    private readonly DbSet<CalendarEntity> calendars = context.Set<CalendarEntity>();
    public async Task AddAsync(CalendarEntity calendarEntity)
    {
        var result = await calendars.AddAsync(calendarEntity);
       
        if(result.State != EntityState.Added)
        {
            throw new Exception("Something went wrong");
        }

        await context.SaveChangesAsync();
    }
    public async Task<CalendarEntity?> GetByIdAsync(Guid id)
    {
        return await calendars.Include(c => c.SummaryOfDays).FirstOrDefaultAsync(c => c.UserId == id);
    }
}
