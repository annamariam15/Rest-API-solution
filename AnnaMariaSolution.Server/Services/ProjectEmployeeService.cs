using AnnaMariaSolution.Server.Data;
using AnnaMariaSolution.Server.DTOs;
using AnnaMariaSolution.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace AnnaMariaSolution.Server.Services;

public class ProjectEmployeeService : IProjectEmployeeService
{
    private readonly ApplicationDbContext _context;

    public ProjectEmployeeService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Project_Employee>> GetAllAsync()
    {
        return await _context.ProjectEmployees.ToListAsync();
    }

    public async Task<IEnumerable<Project_Employee>> GetByProjectAsync(int projectId)
    {
        return await _context.ProjectEmployees
            .Where(pe => pe.Project_ID == projectId)
            .ToListAsync();
    }

    public async Task<Project_Employee?> AddEmployeeAsync(AddEmployeeToProjectDto dto)
    {
        var projectExists = await _context.Projects
            .AnyAsync(p => p.Id == dto.ProjectId);

        if (!projectExists)
            return null;

        var employeeExists = await _context.Users
            .AnyAsync(u => u.Id == dto.UserId);

        if (!employeeExists)
            return null;

        var alreadyAssigned = await _context.ProjectEmployees
            .AnyAsync(pe =>
                pe.Project_ID == dto.ProjectId &&
                pe.User_ID == dto.UserId);

        if (alreadyAssigned)
            throw new InvalidOperationException("Employee is already assigned to this project.");

        var projectEmployee = new Project_Employee
        {
            Project_ID = dto.ProjectId,
            User_ID = dto.UserId,
            JoinedAt = DateTime.UtcNow
        };

        _context.ProjectEmployees.Add(projectEmployee);
        await _context.SaveChangesAsync();

        return projectEmployee;
    }

    public async Task<bool> RemoveEmployeeAsync(int projectId, string userId)
    {
        var assignment = await _context.ProjectEmployees
            .FindAsync(projectId, userId);

        if (assignment == null)
            return false;

        _context.ProjectEmployees.Remove(assignment);
        await _context.SaveChangesAsync();

        return true;
    }
}
