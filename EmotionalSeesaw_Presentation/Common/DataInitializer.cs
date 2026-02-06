using EmotionalSeesaw_Domain.Entities;
using EmotionalSeesaw_Infrastructure.Context;

namespace EmotionalSeesaw_Presentation.Common;

public static class DataInitializer
{
    public async static void Initialize(this IApplicationBuilder applicationBuilder)
    {
        using var scope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<EmotionalSeesawDbContext>();

        if (!context.EmotionalStates.Any())
        {
            var emotionalStates = new[]
            {
                new EmotionalStateEntity()
                {
                Id = Guid.NewGuid(),
                Name = "Happy",
                Image = "happy.png",
                },
                new EmotionalStateEntity()
                {
                Id = Guid.NewGuid(),
                Name = "Pleasure",
                Image = "pleasure.png",
                },
                new EmotionalStateEntity()
                {
                Id = Guid.NewGuid(),
                Name = "Rest",
                Image = "rest.png",
                },
                new EmotionalStateEntity()
                {
                Id = Guid.NewGuid(),
                Name = "Inspiration",
                Image = "inspiration.png",
                },
                new EmotionalStateEntity()
                {
                Id = Guid.NewGuid(),
                Name = "Appreciation",
                Image = "appreciation.png",
                },
                new EmotionalStateEntity()
                {
                Id = Guid.NewGuid(),
                Name = "Delight",
                Image = "delight.png",
                },
                new EmotionalStateEntity()
                {
                Id = Guid.NewGuid(),
                Name = "Pride",
                Image = "pride.png",
                },
                new EmotionalStateEntity()
                {
                Id = Guid.NewGuid(),
                Name = "Love",
                Image = "love.png",
                },
                new EmotionalStateEntity()
                {
                Id = Guid.NewGuid(),
                Name = "Hope",
                Image = "hope.png",
                },
                new EmotionalStateEntity()
                {
                Id = Guid.NewGuid(),
                Name = "Optimism",
                Image = "optimism.png",
                },
                new EmotionalStateEntity()
                {
                Id = Guid.NewGuid(),
                Name = "Relief",
                Image = "relief.png",
                },
                new EmotionalStateEntity()
                {
                Id = Guid.NewGuid(),
                Name = "Comfort",
                Image = "comfort.png",
                },
                new EmotionalStateEntity()
                {
                Id = Guid.NewGuid(),
                Name = "Sadness",
                Image = "sadness.png",
                },
                new EmotionalStateEntity()
                {
                Id = Guid.NewGuid(),
                Name = "Disappointment",
                Image = "disappointment.png",
                },
                new EmotionalStateEntity()
                {
                Id = Guid.NewGuid(),
                Name = "Anxiety",
                Image = "anxiety.png",
                },
                new EmotionalStateEntity()
                {
                Id = Guid.NewGuid(),
                Name = "Fear",
                Image = "fear.png",
                },
                new EmotionalStateEntity()
                {
                Id = Guid.NewGuid(),
                Name = "Malice",
                Image = "malice.png",
                },
                new EmotionalStateEntity()
                {
                Id = Guid.NewGuid(),
                Name = "Irritation",
                Image = "irritation.png",
                },
                new EmotionalStateEntity()
                {
                Id = Guid.NewGuid(),
                Name = "Fatigue",
                Image = "fatigue.png",
                },
                new EmotionalStateEntity()
                {
                Id = Guid.NewGuid(),
                Name = "Loneliness",
                Image = "loneliness.png",
                },
                new EmotionalStateEntity()
                {
                Id = Guid.NewGuid(),
                Name = "Fault",
                Image = "fault.png",
                },
                new EmotionalStateEntity()
                {
                Id = Guid.NewGuid(),
                Name = "Shame",
                Image = "shame.png",
                },
                new EmotionalStateEntity()
                {
                Id = Guid.NewGuid(),
                Name = "Depression",
                Image = "depression.png",
                },
                new EmotionalStateEntity()
                {
                Id = Guid.NewGuid(),
                Name = "Impotence",
                Image = "impotence.png",
                },
                new EmotionalStateEntity()
                {
                Id = Guid.NewGuid(),
                Name = "Boredom",
                Image = "boredom.png",
                },
                new EmotionalStateEntity()
                {
                Id = Guid.NewGuid(),
                Name = "Surprise",
                Image = "surprise.png",
                },
                new EmotionalStateEntity()
                {
                Id = Guid.NewGuid(),
                Name = "Expectation",
                Image = "expectation.png",
                },
                new EmotionalStateEntity()
                {
                Id = Guid.NewGuid(),
                Name = "Internal conflict",
                Image = "internal_conflict.png",
                }
            };

            foreach (var es in emotionalStates)
                await context.EmotionalStates.AddAsync(es);

            await context.SaveChangesAsync();
        }
    }
}
