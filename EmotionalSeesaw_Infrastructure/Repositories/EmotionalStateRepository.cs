using EmotionalSeesaw_Application.Interfaces;
using EmotionalSeesaw_Domain.Common;
using EmotionalSeesaw_Domain.Entities;
using EmotionalSeesaw_Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmotionalSeesaw_Infrastructure.Repositories;

public class EmotionalStateRepository(EmotionalSeesawDbContext context) : IEmotionalStateRepository
{
    private readonly DbSet<EmotionalStateEntity> emotionalStates = context.Set<EmotionalStateEntity>();
    public async Task<ICollection<T>> GetAsync<T>(Expression<Func<EmotionalStateEntity, T>> func)
    {
        return await emotionalStates.Select(func).ToListAsync();
    }
    public async Task<ICollection<EmotionalStateEntity>> GetAsync()
    {       
        return await emotionalStates.ToListAsync();
    }
    public async Task<EmotionalStateEntity?> GetByNameAsync(string Name)
    {
        return await emotionalStates.FirstOrDefaultAsync(es => es.Name == Name);
    }
    public async Task<ICollection<EmotionalStateEntity>?> GetByNameAsync(string[] Names)
    {
        return await emotionalStates.Where(es => Names.Contains(es.Name)).ToListAsync();
    }
}
