using AnnaMariaSolution.Server.DTOs;
using AnnaMariaSolution.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnnaMariaSolution.Server.Controllers;

[ApiController]
[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
public class ProjectEmployeeController : ControllerBase
{
    private readonly IProjectEmployeeService _service;

    public ProjectEmployeeController(IProjectEmployeeService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("project/{projectId}")]
    public async Task<IActionResult> GetByProject(int projectId)
    {
        return Ok(await _service.GetByProjectAsync(projectId));
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee(AddEmployeeToProjectDto dto)
    {
        try
        {
            var assignment = await _service.AddEmployeeAsync(dto);

            if (assignment == null)
                return NotFound("Project or user not found.");

            return Ok(assignment);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpDelete("{projectId}/{userId}")]
    public async Task<IActionResult> RemoveEmployee(int projectId, string userId)
    {
        var removed = await _service.RemoveEmployeeAsync(projectId, userId);

        return removed
            ? NoContent()
            : NotFound();
    }
}
