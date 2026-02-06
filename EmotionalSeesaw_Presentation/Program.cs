using EmotionalSeesaw_Application;
using EmotionalSeesaw_Domain.Common;
using EmotionalSeesaw_Infrastructure;
using EmotionalSeesaw_Presentation;
using EmotionalSeesaw_Presentation.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddPresentation(builder.Configuration)
                .AddInfrastructure(builder.Configuration)
                .AddApplication(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
//app.UseHttpsRedirection();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "images")),
    RequestPath = "/images"
});
app.UseMiddleware<GlobalErrorHandlerMiddleware>();

app.UseCors("AllowPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
DataInitializer.Initialize(app);

app.Run();
