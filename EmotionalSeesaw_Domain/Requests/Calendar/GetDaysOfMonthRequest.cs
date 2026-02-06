namespace EmotionalSeesaw_Domain.Requests.Calendar;

public record GetDaysOfMonthRequest(Guid UserId, int Month, int Year);
