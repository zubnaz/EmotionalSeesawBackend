using EmotionalSeesaw_Domain.Common;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EmotionalSeesaw_Application.Common;

public class JwtService(IOptions<TokenOptions> options)
{
    private readonly TokenOptions _options = options.Value;
    public string GenerateToken(Guid UserId, string Email)
    {
        var claims = new Claim[]
        {
            new Claim("Id", UserId.ToString()),
            new Claim(ClaimTypes.Email, Email)
        };

        var token = new JwtSecurityToken(
            claims: claims,
            notBefore: DateTime.UtcNow,
            issuer: _options.Issuer,
            audience: _options.Audience,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256)
            );

        var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

        return jwtToken;
    }
}
