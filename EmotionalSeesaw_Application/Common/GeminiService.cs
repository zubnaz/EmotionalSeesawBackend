using EmotionalSeesaw_Domain.Common;
using EmotionalSeesaw_Domain.Gemini;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace EmotionalSeesaw_Application.Common;

public sealed class GeminiService(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings()
    {
        ContractResolver = new DefaultContractResolver()
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        },
    };
    //private readonly GeminiOptions _options = options.Value;

    public async Task<string> RequestAsync(string Prompt)
    {
        var requestBody = GeminiRequestFactory.CreateRequest(Prompt);
        var content = new StringContent(JsonConvert.SerializeObject(requestBody, Formatting.None, _serializerSettings),Encoding.UTF8,"application/json");

        var response = await _httpClient.PostAsync("", content);

        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();

        var desearilizedResponse = JsonConvert.DeserializeObject<GeminiResponse>(responseBody);

        var responseText = desearilizedResponse!
            .Candidates[0]
            .Content
            .Parts[0]
            .Text
            .Replace("`", "")
            .Replace("json", "")
            .Trim();

        return responseText;
    }
}
