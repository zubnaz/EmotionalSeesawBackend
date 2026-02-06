using EmotionalSeesaw_Application.Interfaces.CQRS;
using FluentValidation;
using static Google.Apis.Requests.BatchRequest;
namespace EmotionalSeesaw_Presentation.Common;

public interface IDispatcher
{
    Task<TResponse> Send<TResponse>(IQuery<TResponse> request);
    Task<TResponse> Send<TResponse>(ICommand<TResponse> request);
    Task Send(ICommand request);

}
public class Dispatcher : IDispatcher
{
    private readonly IServiceProvider _serviceProvider;
    public Dispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public async Task<TResponse> Send<TResponse>(IQuery<TResponse> request)
    {
        await Validate(request);        

        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
        dynamic handler = _serviceProvider.GetService(handlerType)!;
        if (handler == null)
        {
            throw new InvalidOperationException($"Handler not found for {request.GetType().Name}");
        }
        return await handler.Handle((dynamic)request);
    }

    public async Task<TResponse> Send<TResponse>(ICommand<TResponse> request)
    {
        await Validate(request);        

        var handlerType = typeof(ICommandHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
        dynamic handler = _serviceProvider.GetService(handlerType)!;
        if (handler == null)
        {
            throw new InvalidOperationException($"Handler not found for {request.GetType().Name}");
        }
        return await handler.Handle((dynamic)request);
    }

    public async Task Send(ICommand request)
    {       
        await Validate(request);

        var handlerType = typeof(ICommandHandler<>).MakeGenericType(request.GetType());
        dynamic handler = _serviceProvider.GetService(handlerType)!;
        if (handler == null)
        {
            throw new InvalidOperationException($"Handler not found for {request.GetType().Name}");
        }
        await handler.Handle((dynamic)request);
    }
    private async Task Validate(object request)
    {
        var validatorType = typeof(IValidator<>).MakeGenericType(request.GetType());
        dynamic? validator = _serviceProvider.GetService(validatorType);
        if (validator != null)
        {
            var validationResult = await validator.ValidateAsync((dynamic)request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }   
}
