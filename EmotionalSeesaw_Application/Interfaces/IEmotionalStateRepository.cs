using EmotionalSeesaw_Domain.Common;
using EmotionalSeesaw_Domain.Entities;
using System.Linq.Expressions;

namespace EmotionalSeesaw_Application.Interfaces;

public interface IEmotionalStateRepository
{
    public Task<ICollection<T>> GetAsync<T>(Expression<Func<EmotionalStateEntity, T>> func);
    public Task<ICollection<EmotionalStateEntity>> GetAsync();
    public Task<EmotionalStateEntity?> GetByNameAsync(string Name);
    public Task<ICollection<EmotionalStateEntity>?> GetByNameAsync(string[] Names);
}
