
using EmotionalSeesaw_Domain.Common;
using Microsoft.Extensions.Options;

namespace EmotionalSeesaw_Application.Common;

internal sealed class GeminiDelegatingHandler(IOptions<GeminiOptions> options) : DelegatingHandler
{
    private readonly GeminiOptions _options = options.Value;
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add("x-goog-api-key",$"{_options.ApiKey}");
        return base.SendAsync(request, cancellationToken);
    }
}
