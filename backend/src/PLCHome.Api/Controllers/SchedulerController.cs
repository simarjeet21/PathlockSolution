using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using PLCHome.Api.Services;
using PLCHome.Api.DTOs;

namespace PLCHome.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/projects/{projectId}/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly ISchedulerService _scheduler;
        public ScheduleController(ISchedulerService scheduler) => _scheduler = scheduler;
        private int GetUserId() => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        [HttpPost]
        public async Task<IActionResult> CreateSchedule(int projectId, ScheduleRequestDto req)
        {
            var userId = GetUserId();
            var plan = await _scheduler.GenerateSchedule(userId, projectId, req);
            return Ok(plan);
        }
    }
}
