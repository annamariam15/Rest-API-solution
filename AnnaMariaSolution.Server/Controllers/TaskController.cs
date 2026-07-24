using AnnaMariaSolution.Server.DTOs;
using AnnaMariaSolution.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnnaMariaSolution.Server.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class EmployeeTaskController : ControllerBase
{
    private readonly IEmployeeTaskService _taskService;

    public EmployeeTaskController(IEmployeeTaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet] //retrieves all tasks
    //all for admin, only own for employees
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _taskService.GetAllAsync());
    }

    [HttpGet("{id}")]//retrieves task by id
    //all for admin, only own for employees
    public async Task<IActionResult> Get(int id)
    {
        var task = await _taskService.GetByIdAsync(id);

        return task == null
            ? NotFound()
            : Ok(task);
    }

    [Authorize(Roles = "Employee")]
    [HttpPost]//create task
    //only for own tasks, employee-only for testing purposes
    public async Task<IActionResult> Create(CreateTaskDto dto)
    {
        var task = await _taskService.CreateAsync(dto);

        return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
    }

    [Authorize(Roles = "Employee")]
    [HttpPut("{id}")]//edit task by id
    //only for own tasks, employee-only for testing purposes
    public async Task<IActionResult> Update(int id, UpdateTaskDto dto)
    {
        var updated = await _taskService.UpdateAsync(id, dto);

        return updated
            ? NoContent()
            : NotFound();
    }

    [Authorize(Roles = "Employee")]
    [HttpDelete("{id}")]//delete task by id
    //only for own tasks, employee-only for testing purposes
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _taskService.DeleteAsync(id);

        return deleted
            ? NoContent()
            : NotFound();
    }
}

