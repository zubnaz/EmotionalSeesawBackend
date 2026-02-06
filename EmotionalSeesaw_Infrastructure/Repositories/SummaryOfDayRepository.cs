using EmotionalSeesaw_Application.Interfaces;
using EmotionalSeesaw_Domain.Entities;
using EmotionalSeesaw_Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EmotionalSeesaw_Infrastructure.Repositories;

public class SummaryOfDayRepository(EmotionalSeesawDbContext context) : ISummaryOfDayRepository
{
    private readonly DbSet<SummaryOfDayEntity> summaryOfDays = context.Set<SummaryOfDayEntity>();
    public async Task AddAsync(SummaryOfDayEntity summaryOfDayEntity)
    {
        var result = await summaryOfDays.AddAsync(summaryOfDayEntity);
       
        if(result.State != EntityState.Added)
        {
            throw new Exception("Something went wrong");
        }
        await context.SaveChangesAsync();
    }
    public async Task<SummaryOfDayEntity?> ExistSummaryByDateAsync(Guid userId, DateOnly date)
    {
        return await summaryOfDays.FirstOrDefaultAsync(s => s.UserId == userId && s.Date == date);
    }
    public async Task RemoveAsync(SummaryOfDayEntity summaryOfDayEntity)
    {
        var result = summaryOfDays.Remove(summaryOfDayEntity);
       
        if(result.State != EntityState.Deleted)
        {
            throw new Exception("Something went wrong");
        }
        await context.SaveChangesAsync();
    }
    public async Task<SummaryOfDayEntity?> GetByIdAsync(Guid id)
    {
        return await summaryOfDays.FirstOrDefaultAsync(s => s.Id == id);
    }
    public async Task<SummaryOfDayEntity?> GetByIdIncludedAsync(Guid id)
    {
        return await summaryOfDays
            .Include(s => s.EmotionalStates)
            .FirstOrDefaultAsync(s => s.Id == id);
    }
    public async Task UpdateAsync(SummaryOfDayEntity summaryOfDayEntity)
    {
        var result = summaryOfDays.Update(summaryOfDayEntity);
       
        if(result.State != EntityState.Modified)
        {
            throw new Exception("Something went wrong");
        }
        await context.SaveChangesAsync();
    }
    public async Task<bool> IsAnalyzedAsync(Guid id)
    {
        var summary = await summaryOfDays
            .Include(s => s.EmotionalStates)
            .FirstOrDefaultAsync(s => s.Id == id);

        return summary!.EmotionalStates != null && summary.EmotionalStates.Any();
    }
    public async Task<ICollection<SummaryOfDayEntity>> GetSummariesByMonth(Guid userId, int year, int month)
    {
        return await summaryOfDays.Where(s => s.UserId == userId && s.Date.Year == year && s.Date.Month == month)
            .ToListAsync();
    }
}
