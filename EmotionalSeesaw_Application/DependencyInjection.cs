using EmotionalSeesaw_Application.Common;
using EmotionalSeesaw_Application.Interfaces.CQRS;
using EmotionalSeesaw_Application.Requests.Command.CreateSummaryOfDay;
using EmotionalSeesaw_Application.Requests.Query.GetSummariesOfMonth;
using EmotionalSeesaw_Domain.Common;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;


namespace EmotionalSeesaw_Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDispatcherHandlers(AppDomain.CurrentDomain.GetAssemblies());
        services.Configure<GoogleAuthorization>(opt =>
        {
            opt.UserInfoUrl = configuration["GoogleAuthorization:UserInfoUrl"]!;
            opt.ClientId = configuration["GoogleAuthorization:ClientId"]!;
            opt.ClientSecret = configuration["GoogleAuthorization:ClientSecret"]!;
            opt.RedirectUri = configuration["GoogleAuthorization:RedirectUri"]!;
            opt.GrantType = configuration["GoogleAuthorization:GrantType"]!;
        });
        services.Configure<TokenOptions>(opt =>
        {
            opt.Audience = configuration["TokenOptions:Audience"]!;
            opt.Issuer = configuration["TokenOptions:Issuer"]!;
            opt.SecretKey = configuration["TokenOptions:SecretKey"]!;
        });
        services.Configure<GeminiOptions>(opt =>
        {
            opt.ApiKey = configuration["GeminiOptions:ApiKey"]!;
            opt.Url = configuration["GeminiOptions:Url"]!;
        });
        services.AddTransient<GeminiDelegatingHandler>();
        services.AddHttpClient<GeminiService>(
            (serviceProvider, httpClient) =>
            {
                var options = serviceProvider.GetRequiredService<IOptions<GeminiOptions>>().Value;

                httpClient.BaseAddress = new Uri($"{options.Url}");
            }).AddHttpMessageHandler<GeminiDelegatingHandler>();
        services.AddSingleton<JwtService>();
        services.AddValidators();

        return services;
    }
    private static IServiceCollection AddDispatcherHandlers(this IServiceCollection services, params Assembly[] assemblies)
    {
        var handlerInterfaces = new[]
        {
            typeof(IQueryHandler<,>),
            typeof(ICommandHandler<,>),
            typeof(ICommandHandler<>)
        };

        var types = assemblies
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => !type.IsAbstract && !type.IsInterface)
            .ToList();

        foreach (var type in types)
        {
            var interfaces = type.GetInterfaces()
                                .Where(i => handlerInterfaces.Any(h => h.IsGenericTypeDefinition && i.IsGenericType
                                && i.GetGenericTypeDefinition() == h));

            foreach (var _interface in interfaces)
            {
                services.AddScoped(_interface, type);
            }
        }

        return services;
    }
    private static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddTransient<IValidator<CreateSummaryOfDayCommand>,CreateSummaryOfDayCommandValidation>();
        services.AddTransient<IValidator<GetSummariesOfMonthQuery>,GetSummariesOfMonthQueryValidation>();
        return services;
    }
}
