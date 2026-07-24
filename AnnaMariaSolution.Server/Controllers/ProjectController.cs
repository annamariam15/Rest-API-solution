using AnnaMariaSolution.Server.DTOs;
using AnnaMariaSolution.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnnaMariaSolution.Server.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet] //retrieves all projects
    //all for admin, only own for employees
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _projectService.GetAllAsync());
    }

    [HttpGet("{id}")]//retrieves project by id
    //any for admin, only own for employees
    public async Task<IActionResult> Get(int id)
    {
        var project = await _projectService.GetByIdAsync(id);

        return project == null
            ? NotFound()
            : Ok(project);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost] //create project
    //admin only
    public async Task<IActionResult> CreateProjectAsync(CreateProjectDto dto)
    {
        var project = await _projectService.CreateAsync(dto);

        return CreatedAtAction(nameof(Get), new { id = project.Id }, project);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")] //edit project by id
    //admin only
    public async Task<IActionResult> Update(int id, UpdateProjectDto dto)
    {
        var updated = await _projectService.UpdateAsync(id, dto);

        return updated ? NoContent() : NotFound();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]//delete project by id
    //admin only
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _projectService.DeleteAsync(id);

        return deleted ? NoContent() : NotFound();
    }
}
