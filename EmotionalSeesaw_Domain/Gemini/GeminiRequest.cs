namespace EmotionalSeesaw_Domain.Gemini;

public sealed class GeminiRequest
{
    public required GeminiContent[] Contents { get; set; }
}
public sealed class  GeminiContent
{
    public required string Role { get; set; }
    public required GeminiPart[] Parts { get; set; }
}
public sealed class  GeminiPart
{
    public required string Text { get; set; }
}