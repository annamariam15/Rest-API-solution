using AnnaMariaSolution.Server.Data;
using AnnaMariaSolution.Server.DTOs;
using AnnaMariaSolution.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AnnaMariaSolution.Server.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class EmployeeTaskController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public EmployeeTaskController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet] //get all
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Tasks.ToListAsync());
    }


    [HttpGet("{id}")] //get by id
    public async Task<IActionResult> Get(int id)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
            return NotFound();

        return Ok(task);
    }


    [Authorize(Roles = "Employee")]
    [HttpPost] //create new task
    public async Task<IActionResult> Create(CreateTaskDto dto)
    {
        var task = new Employee_Task
        {
            Project = dto.ProjectId,
            Creator = dto.Creator,
            Assigned = dto.Assigned,
            Status = dto.Status,
            Name = dto.Name,
            Desc = dto.Desc,
            Created = DateTime.UtcNow,
            LastUpdate = DateTime.UtcNow
        };


        _context.Tasks.Add(task);

        await _context.SaveChangesAsync();


        return CreatedAtAction(
            nameof(Get),
            new { id = task.Id },
            task
        );
    }


    [Authorize(Roles = "Employee")]
    [HttpPut("{id}")] //edit existing task
    public async Task<IActionResult> Update(int id, UpdateTaskDto dto)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
            return NotFound();


        task.Creator = dto.Creator;
        task.Assigned = dto.Assigned;
        task.Status = dto.Status;
        task.Name = dto.Name;
        task.Desc = dto.Desc;
        task.LastUpdate = DateTime.UtcNow;


        await _context.SaveChangesAsync();

        return NoContent();
    }


    [Authorize(Roles = "Employee")]
    [HttpDelete("{id}")] //delete task
    public async Task<IActionResult> Delete(int id)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
            return NotFound();


        _context.Tasks.Remove(task);

        await _context.SaveChangesAsync();


        return NoContent();
    }
}
