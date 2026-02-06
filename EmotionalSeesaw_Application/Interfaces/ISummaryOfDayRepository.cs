using EmotionalSeesaw_Domain.Entities;

namespace EmotionalSeesaw_Application.Interfaces;

public interface ISummaryOfDayRepository
{
    public Task AddAsync(SummaryOfDayEntity summaryOfDayEntity);
    public Task<SummaryOfDayEntity?> ExistSummaryByDateAsync(Guid userId, DateOnly date);
    public Task RemoveAsync(SummaryOfDayEntity summaryOfDayEntity);
    public Task<SummaryOfDayEntity?> GetByIdAsync(Guid id);
    public Task<SummaryOfDayEntity?> GetByIdIncludedAsync(Guid id);
    public Task UpdateAsync(SummaryOfDayEntity summaryOfDayEntity);    
    public Task<bool> IsAnalyzedAsync(Guid id);
    public Task<ICollection<SummaryOfDayEntity>> GetSummariesByMonth(Guid userId, int year, int month);
}
