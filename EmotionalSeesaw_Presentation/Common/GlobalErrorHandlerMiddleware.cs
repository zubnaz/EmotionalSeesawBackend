
using EmotionalSeesaw_Domain.Common;
using Newtonsoft.Json;

namespace EmotionalSeesaw_Presentation.Common;

public class GlobalErrorHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
		try
		{
			await next(context);
		}
		catch (Exception exception)
		{
			await HandingError(context, exception);
		}
    }
	public async Task HandingError(HttpContext context, Exception exception)
	{
		context.Response.ContentType = "application/json";
		context.Response.StatusCode = exception switch
		{
			UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
			KeyNotFoundException => StatusCodes.Status404NotFound,
			InvalidOperationException => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
		};
		await context.Response.WriteAsync(JsonConvert.SerializeObject(new ApiResponse(context.Response.StatusCode,exception.Message)));
    }
}
