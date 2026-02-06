using EmotionalSeesaw_Domain.Common;
using Google.Apis.Auth;
using Newtonsoft.Json;
namespace EmotionalSeesaw_Application.Common;

public static class GoogleAuthHelper
{
    public static async Task<bool> ValidateGoogleTokenAsync(string idToken)
    {
       var payload = await GoogleJsonWebSignature.ValidateAsync(idToken);

        if(payload == null || String.IsNullOrEmpty(payload.Email))
        {
            return false;
        }

        return true; 
    }
    public static async Task<GoogleUserInformation?> GetGoogleUserInformationAsync(string accesToken, string userInfoUrl)
    {
        using var httpClient = new HttpClient();

        var response = await httpClient.GetAsync($"{userInfoUrl}?access_token={accesToken}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
       
        var content = await response.Content.ReadAsStringAsync();

        var userInfo = JsonConvert.DeserializeObject<GoogleUserInformation>(content);
        return userInfo;
    }
    public static async Task<GoogleTokens?> GetGoogleTokens(string code, GoogleAuthorization googleAuthorization)
    {
        using var httpClient = new HttpClient();

        HttpContent body = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("code", code),
            new KeyValuePair<string, string>("client_id",googleAuthorization.ClientId),
            new KeyValuePair<string, string>("client_secret",googleAuthorization.ClientSecret),
            new KeyValuePair<string, string>("redirect_uri",googleAuthorization.RedirectUri),
            new KeyValuePair<string, string>("grant_type",googleAuthorization.GrantType),
        });
        
        var response = await httpClient.PostAsync($"https://oauth2.googleapis.com/token",body);

        var content = await response.Content.ReadAsStringAsync();

        //Console.WriteLine($"Google Token Response: {content}");

        var googleTokens = JsonConvert.DeserializeObject<GoogleTokens>(content);

        return googleTokens;
    }
}
