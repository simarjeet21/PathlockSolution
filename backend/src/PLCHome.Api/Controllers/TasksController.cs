using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using PLCHome.Api.DTOs;
using PLCHome.Api.Services;

namespace PLCHome.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/projects/{projectId}/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _tasks;
        public TasksController(ITaskService tasks) => _tasks = tasks;
        private int GetUserId() => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        [HttpGet]
        public async Task<IActionResult> GetAll(int projectId)
        {
            var userId = GetUserId();
            var res = await _tasks.GetAllAsync(userId, projectId);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int projectId, CreateTaskDto dto)
        {
            var userId = GetUserId();
            var res = await _tasks.CreateAsync(userId, projectId, dto);
            return Ok(res);
        }

        [HttpPut("{taskId}/toggle")]
        public async Task<IActionResult> Toggle(int projectId, int taskId)
        {
            var userId = GetUserId();
            var res = await _tasks.ToggleCompleteAsync(userId, projectId, taskId);
            return Ok(res);
        }

        [HttpDelete("{taskId}")]
        public async Task<IActionResult> Delete(int projectId, int taskId)
        {
            var userId = GetUserId();
            await _tasks.DeleteAsync(userId, projectId, taskId);
            return NoContent();
        }
    }
}
