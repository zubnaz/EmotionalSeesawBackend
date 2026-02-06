using EmotionalSeesaw_Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmotionalSeesaw_Infrastructure.Context;

public class EmotionalSeesawDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public DbSet<EmotionalStateEntity> EmotionalStates { get; set; }
    public EmotionalSeesawDbContext(DbContextOptions<EmotionalSeesawDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>()
            .HasMany(u => u.SummariesOfDays)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<EmotionalStateEntity>()
            .HasMany(es => es.SummariesOfDays)
            .WithMany(s => s.EmotionalStates)
            .UsingEntity<Dictionary<string, object>>(
                "EmotionalStateSummaryOfDay",
                j => j
                    .HasOne<SummaryOfDayEntity>()
                    .WithMany()
                    .HasForeignKey("SummaryOfDayId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<EmotionalStateEntity>()
                    .WithMany()
                    .HasForeignKey("EmotionalStateId")
                    .OnDelete(DeleteBehavior.Cascade));

    }
}
