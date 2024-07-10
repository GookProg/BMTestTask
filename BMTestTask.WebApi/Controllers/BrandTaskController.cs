using BMTestTask.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;

namespace BMTestTask.WebApi.Controllers;

[Route("api/task")]
[ApiController]
public class BrandTaskController : ControllerBase
{
    private readonly IBrandTaskService _taskService;

    public BrandTaskController(IBrandTaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTask([FromRoute] string id)
    {
        if (!Guid.TryParse(id, out var guid))
        {
            return BadRequest();
        }

        var task = await _taskService.GetAsync(guid);

        if (task == null)
        {
            return NotFound();
        }

        return Ok(task.Status.GetDisplayName());
    }

    [HttpPost]
    public async Task<IActionResult> PostTask()
    {
        var guid = await _taskService.PostAsync();

        return Accepted(guid);
    }
}