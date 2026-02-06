using EmotionalSeesaw_Application.Interfaces.CQRS;
using EmotionalSeesaw_Domain.Requests.Auth;
using MediatR;

namespace EmotionalSeesaw_Application.Requests.Command.AuthorizeUser;

public record AuthorizeUserCommand(GoogleAuthorizationRequest GoogleAuthorizationRequest) : ICommand<string>;
