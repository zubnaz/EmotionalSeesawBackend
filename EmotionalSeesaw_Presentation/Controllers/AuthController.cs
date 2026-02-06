using EmotionalSeesaw_Application.Requests.Command.AuthorizeUser;
using EmotionalSeesaw_Domain.Requests.Auth;
using EmotionalSeesaw_Presentation.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace EmotionalSeesaw_Presentation.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController(IDispatcher dispatcher) : ControllerBase
{
    /*[HttpPost("google")]
    public async Task<IActionResult> GoogleAuthorization([FromBody] GoogleAuthorizationRequest request)
    {
        string result = await dispatcher.Send<string>(new AuthorizeUserCommand(request));
        return Ok(result);
    }*/
    [HttpPost("google")]
    public async Task<IActionResult> GoogleAuthorization([FromBody] GoogleAuthorizationRequest request)
    {
        //Console.WriteLine($"Code : {request.AuthCode}");
        string result = await dispatcher.Send<string>(new AuthorizeUserCommand(request));
        return Ok(result);
    }

    [Authorize]
    [HttpGet("authorization-check")]
    public IActionResult AuthorizationCheck()
    {
        var userID = User.Claims.First((c => c.Type == "Id")).Value;
        Console.WriteLine($"User ID: {userID}");
        return Ok("User is authorized");
    }
}
