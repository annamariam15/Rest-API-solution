using AnnaMariaSolution.Server.Data;
using AnnaMariaSolution.Server.DTOs;
using AnnaMariaSolution.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnnaMariaSolution.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectEmployeeController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProjectEmployeeController(ApplicationDbContext context)
    {
        _context = context;
    }


    // GET: api/ProjectEmployee
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.ProjectEmployees.ToListAsync());
    }


    // GET: api/ProjectEmployee/project/1
    [HttpGet("project/{projectId}")]
    public async Task<IActionResult> GetByProject(int projectId)
    {
        var employees = await _context.ProjectEmployees
            .Where(pe => pe.Project_ID == projectId)
            .ToListAsync();

        return Ok(employees);
    }


    // POST: api/ProjectEmployee
    [HttpPost]
    public async Task<IActionResult> AddEmployee(AddEmployeeToProjectDto dto)
    {
        var projectExists = await _context.Projects
            .AnyAsync(p => p.Id == dto.ProjectId);

        if (!projectExists)
            return NotFound("Project not found");


        var employeeExists = await _context.Users
            .AnyAsync(u => u.Id == dto.UserId);

        if (!employeeExists)
            return NotFound("User not found");


        var projectEmployee = new Project_Employee
        {
            Project_ID = dto.ProjectId,
            User_ID = dto.UserId,
            JoinedAt = DateTime.UtcNow
        };


        _context.ProjectEmployees.Add(projectEmployee);

        await _context.SaveChangesAsync();


        return Ok(projectEmployee);
    }


    // DELETE: api/ProjectEmployee/projectId/userId
    [HttpDelete("{projectId}/{userId}")]
    public async Task<IActionResult> RemoveEmployee(
        int projectId,
        string userId)
    {
        var projectEmployee = await _context.ProjectEmployees
            .FindAsync(projectId, userId);


        if (projectEmployee == null)
            return NotFound();


        _context.ProjectEmployees.Remove(projectEmployee);

        await _context.SaveChangesAsync();


        return NoContent();
    }
}
