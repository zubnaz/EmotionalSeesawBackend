using EmotionalSeesaw_Domain.Common;
using EmotionalSeesaw_Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;

namespace EmotionalSeesaw_Infrastructure.Common;

internal class EmotionalSeesawDbContextFactory : IDesignTimeDbContextFactory<EmotionalSeesawDbContext>
{
    public EmotionalSeesawDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EmotionalSeesawDbContext>();
        optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Userid=postgres;Password=nazar345;Database=emotionalseesaw");

        return new EmotionalSeesawDbContext(optionsBuilder.Options);
    }
}
