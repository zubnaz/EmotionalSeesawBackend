using EmotionalSeesaw_Application.Interfaces;
using EmotionalSeesaw_Application.Interfaces.CQRS;
using EmotionalSeesaw_Domain.Entities;
using EmotionalSeesaw_Infrastructure.Context;
using EmotionalSeesaw_Infrastructure.Repositories;
using EmotionalSeesaw_Presentation.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;



namespace EmotionalSeesaw_Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.ScopeRepositories();
        services.AddTransient<GlobalErrorHandlerMiddleware>();
        services.AddIdentity<User,IdentityRole<Guid>>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 10;
            options.User.RequireUniqueEmail = true;

            options.SignIn.RequireConfirmedEmail = true;
        })
        .AddEntityFrameworkStores<EmotionalSeesawDbContext>()
        .AddDefaultTokenProviders();
        
        services.AddJwt(configuration);
        services.AddMapper();
        services.AddCORS();
        return services;
    }
    private static IServiceCollection ScopeRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICalendarRepository, CalendarRepository>();
        services.AddScoped<ISummaryOfDayRepository, SummaryOfDayRepository>();
        services.AddScoped<IEmotionalStateRepository, EmotionalStateRepository>();

        services.AddScoped<IDispatcher, Dispatcher>();
        return services;
    }
    private static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {          
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["TokenOptions:Issuer"],
                    ValidAudience = configuration["TokenOptions:Audience"],
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["TokenOptions:SecretKey"]!)),
                    
                };
            });
        services.AddAuthorization(conf =>
        {
            conf.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
        });
        return services;
    }
    private static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }   
    private static IServiceCollection AddCORS(this IServiceCollection services)
    {
        services.AddCors(options =>
        {     
            options.AddPolicy("AllowPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:5173")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
            });
        });
        return services;
    }
}
