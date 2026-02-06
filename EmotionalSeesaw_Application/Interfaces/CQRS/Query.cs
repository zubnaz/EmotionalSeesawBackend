namespace EmotionalSeesaw_Application.Interfaces.CQRS;

public interface IQuery<TResponse>;

public interface IQueryHandler<in TRequest,TResponse>
    where TRequest : IQuery<TResponse>
{
    Task<TResponse> Handle(TRequest request);
};
