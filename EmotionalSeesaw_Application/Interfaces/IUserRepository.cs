using EmotionalSeesaw_Domain.Entities;

namespace EmotionalSeesaw_Application.Interfaces;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User?> ExistsByEmailAsync(string email);
    Task<User?> GetByIdAsync(Guid id);
}
