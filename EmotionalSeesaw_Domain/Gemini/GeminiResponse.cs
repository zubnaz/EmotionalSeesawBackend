namespace EmotionalSeesaw_Domain.Gemini;

public sealed class GeminiResponse
{
    public Candidate[] Candidates { get; set; }
}

public sealed class Candidate
{
    public Content Content { get; set; }
}
public sealed class Content
{
    public Part[] Parts { get; set; }
}
public sealed class Part
{
    public string Text { get; set; } = string.Empty;
}