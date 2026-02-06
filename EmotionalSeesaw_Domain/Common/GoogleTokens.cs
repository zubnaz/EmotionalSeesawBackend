using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace EmotionalSeesaw_Domain.Common;

public class GoogleTokens
{
    [JsonProperty("access_token")]
    public required string AccessToken { get; set; }
    [JsonProperty("id_token")]
    public required string IdToken { get; set; }
}
