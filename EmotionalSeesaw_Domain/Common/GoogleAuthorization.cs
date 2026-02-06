namespace EmotionalSeesaw_Domain.Common;

public class GoogleAuthorization
{
    public required string UserInfoUrl { get; set; }
    public required string ClientId { get; set; }
    public required string ClientSecret { get; set; }
    public required string RedirectUri { get; set; }
    public required string GrantType { get; set; }

}
