namespace EmotionalSeesaw_Application.Common;

internal static class GeminiPrompts
{
    public static string SummaryOfDayAnalysis(string summaryOfDay, string emotionalStates) 
        => $"This is a summary of the day : <{summaryOfDay}>, " +
        $"based on this data, create a list of emotional states that best describe the day. The list should be in the form of an array of classes with a field \"Name\" also, if there are negative emotional states in the list, add one general field \"Advice\", write advice in this field, if advice is not needed, leave null. " +
        $"Emotional states : {emotionalStates}";
}
