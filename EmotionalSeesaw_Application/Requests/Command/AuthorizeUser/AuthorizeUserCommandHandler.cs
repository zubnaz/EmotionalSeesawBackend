using EmotionalSeesaw_Application.Common;
using EmotionalSeesaw_Application.Interfaces;
using EmotionalSeesaw_Application.Interfaces.CQRS;
using EmotionalSeesaw_Domain.Common;
using EmotionalSeesaw_Domain.Entities;
using Microsoft.Extensions.Options;

namespace EmotionalSeesaw_Application.Requests.Command.AuthorizeUser;

public class AuthorizeUserCommandHandler(IUserRepository userRepository,
    IOptions<GoogleAuthorization> authOptions,
    JwtService jwtService) : ICommandHandler<AuthorizeUserCommand, string>
{
    public async Task<string> Handle(AuthorizeUserCommand request)
    {
        var tokens = await GoogleAuthHelper.GetGoogleTokens(request.GoogleAuthorizationRequest.AuthCode, 
                                                            authOptions.Value);
        if (tokens == null || tokens.IdToken == null || tokens.AccessToken == null)
        {
            throw new InvalidOperationException("Something went wrong");
        }
        var payload = await GoogleAuthHelper.ValidateGoogleTokenAsync(tokens.IdToken);
        if (payload == false)
        {
            throw new UnauthorizedAccessException("Invalid Google token.");
        }

        var userGoogleInformation = await GoogleAuthHelper.GetGoogleUserInformationAsync(tokens.AccessToken, 
                                                                                         authOptions.Value.UserInfoUrl);
        if (userGoogleInformation == null)
        {
            throw new Exception("Something went wrong");
        }
        var user = await userRepository.ExistsByEmailAsync(userGoogleInformation.Email);
        if(user == null)
        {
            user = new User()
            {
                Email = userGoogleInformation.Email,
                UserName = userGoogleInformation.Name
            };
            await userRepository.AddAsync(user);
        }
        

        var token = jwtService.GenerateToken(user.Id, user.Email!);

        return token;
    }
}
