using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using PLCHome.Api.DTOs;
using PLCHome.Api.Services;

namespace PLCHome.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projects;
        public ProjectsController(IProjectService projects) => _projects = projects;

        private int GetUserId() => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = GetUserId();
            var res = await _projects.GetAllAsync(userId);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectDto dto)
        {
            var userId = GetUserId();
            var res = await _projects.CreateAsync(userId, dto);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = GetUserId();
            await _projects.DeleteAsync(userId, id);
            return NoContent();
        }

        [HttpGet("{projectId}")]
        public async Task<IActionResult> Get(int projectId)
        {
            var userId = GetUserId();
            var res = await _projects.GetByIdAsync(userId, projectId);
            return Ok(res);
        }
    }
}
