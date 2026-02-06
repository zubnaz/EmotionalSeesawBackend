using EmotionalSeesaw_Application.Interfaces;
using EmotionalSeesaw_Domain.Entities;
using EmotionalSeesaw_Infrastructure.Context;
using Microsoft.AspNetCore.Identity;

namespace EmotionalSeesaw_Infrastructure.Repositories;

public class UserRepository(UserManager<User> userManager, EmotionalSeesawDbContext dbContext) : IUserRepository
{
    public async Task AddAsync(User user)
    {
        var result = await userManager.CreateAsync(user);
        if(!result.Succeeded)
        {
            throw new Exception($"{result.Errors.FirstOrDefault()!.Description}");
        }
    }
    public async Task<User?> ExistsByEmailAsync(string email)
    {
        return await userManager.FindByEmailAsync(email);
    }
    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await userManager.FindByIdAsync(id.ToString());
    }
}
