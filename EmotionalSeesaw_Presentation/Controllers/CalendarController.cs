using AutoMapper;
using EmotionalSeesaw_Domain.Entities;
using EmotionalSeesaw_Domain.Requests.Calendar;
using EmotionalSeesaw_Domain.Responses.Summary;
using EmotionalSeesaw_Presentation.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmotionalSeesaw_Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CalendarController(IDispatcher dispatcher, IMapper mapper) : ControllerBase
{
    /*[HttpGet]
    public async Task<IActionResult> GetDaysOfMonth([FromQuery] GetDaysOfMonthRequest request)
    {
        var days = await dispatcher.Send<ICollection<SummaryOfDayEntity>>(new GetDaysOfMonthQuery(request.UserId, request.Month, request.Year));
        return Ok(mapper.Map<ICollection<SummaryOfDayCollectionItemResponse>>(days));
    }*/
}
