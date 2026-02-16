using AutoMapper;
using EmotionalSeesaw_Application.Requests.Command.CreateSummaryOfDay;
using EmotionalSeesaw_Application.Requests.Command.SummaryAnalysis;
using EmotionalSeesaw_Application.Requests.Query.GetSummariesOfMonth;
using EmotionalSeesaw_Application.Requests.Query.GetSummaryById;
using EmotionalSeesaw_Domain.Entities;
using EmotionalSeesaw_Domain.Requests.Summary;
using EmotionalSeesaw_Domain.Responses.Summary;
using EmotionalSeesaw_Presentation.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmotionalSeesaw_Presentation.Controllers
{
    [Route("api/summaries")]
    [ApiController]
    public class SummariesController(IDispatcher dispatcher, IMapper mapper) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSummaryById([FromRoute] Guid id)
        {
            var summary = await dispatcher.Send<SummaryOfDayEntity>(new GetSummaryByIdQuery(id));
            return Ok(mapper.Map<SummaryOfDayResponse>(summary));
        }
        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateSummaryOfDay([FromBody] CreateSummaryRequest request, string userID)
        {
            //var userID = User.Claims.First((c => c.Type == "Id")).Value;
            var summaryId = await dispatcher.Send<Guid>(new CreateSummaryOfDayCommand(request.Text, request.Day, request.Month, request.Year, Guid.Parse(userID)));
            return Ok(summaryId);
        }
        //[Authorize]
        [HttpPatch("{id}/emotional-states")]
        public async Task<IActionResult> SummaryAnalysis([FromRoute] Guid id, [FromQuery]Guid userID)
        {
            //var userID = User.Claims.First((c => c.Type == "Id")).Value;
            await dispatcher.Send(new SummaryAnalysisCommand(id, userID));
            return NoContent();
        }
        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> GetSummaries([FromQuery] int year, int month, string userID)
        {
            //var userID = User.Claims.First((c => c.Type == "Id")).Value;
            var summaries = await dispatcher.Send<ICollection<SummaryOfDayEntity>>(new GetSummariesOfMonthQuery(Guid.Parse(userID), month, year));
            return Ok(mapper.Map<ICollection<SummaryOfDayCollectionItemResponse>>(summaries));
        }
    }
}
