using AnnaMariaSolution.Server.Data;
using AnnaMariaSolution.Server.DTOs;
using AnnaMariaSolution.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace AnnaMariaSolution.Server.Services;

public class EmployeeTaskService : IEmployeeTaskService
{
    private readonly ApplicationDbContext _context;

    public EmployeeTaskService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Employee_Task>> GetAllAsync()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task<Employee_Task?> GetByIdAsync(int id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async Task<Employee_Task> CreateAsync(CreateTaskDto dto)
    {
        // Verify the project exists before creating the task.
        var projectExists = await _context.Projects
            .AnyAsync(p => p.Id == dto.ProjectId);

        if (!projectExists)
            throw new InvalidOperationException("Project does not exist.");

        var task = new Employee_Task
        {
            Project = dto.ProjectId,
            CreatorId = dto.CreatorId,
            AssignedId = dto.AssignedId,
            Status = dto.Status,
            Name = dto.Name,
            Desc = dto.Desc,
            Created = DateTime.UtcNow,
            LastUpdate = DateTime.UtcNow
        };

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        return task;
    }

    public async Task<bool> UpdateAsync(int id, UpdateTaskDto dto)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
            return false;

        task.CreatorId = dto.CreatorId;
        task.AssignedId = dto.AssignedId;
        task.Status = dto.Status;
        task.Name = dto.Name;
        task.Desc = dto.Desc;
        task.LastUpdate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
            return false;

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();

        return true;
    }
}
