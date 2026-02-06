namespace EmotionalSeesaw_Domain.Common;

public class TokenOptions
{
    public required string Audience { get; set; }
    public required string Issuer { get; set; }
    public required string SecretKey { get; set; }
}
