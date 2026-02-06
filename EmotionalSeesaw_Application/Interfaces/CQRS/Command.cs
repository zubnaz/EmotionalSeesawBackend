using MediatR;

namespace EmotionalSeesaw_Application.Interfaces.CQRS;

public interface ICommand;
public interface ICommand<TResponse>;

public interface ICommandHandler<in TRequest>
    where TRequest : ICommand
{
    Task Handle(TRequest request);
}
public interface ICommandHandler<in TRequest, TResponse>
    where TRequest : ICommand<TResponse>
{
    Task<TResponse> Handle(TRequest request);
}

