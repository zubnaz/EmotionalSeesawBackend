using EmotionalSeesaw_Domain.Gemini;

namespace EmotionalSeesaw_Application.Common;

internal static class GeminiRequestFactory
{
    public static GeminiRequest CreateRequest(string Prompt)
    {
            return new GeminiRequest()
            {
                Contents = new GeminiContent[]
            {
                new GeminiContent()
                {
                    Role = "user",
                    Parts = new GeminiPart[]
                    {
                        new GeminiPart()
                        {
                            Text = Prompt,
                        }
                    }
                }
            }

            };                 
    }
}
