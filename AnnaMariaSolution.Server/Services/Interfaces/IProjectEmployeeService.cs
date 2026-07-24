using AnnaMariaSolution.Server.DTOs;
using AnnaMariaSolution.Server.Models;

namespace AnnaMariaSolution.Server.Services;

public interface IProjectEmployeeService
{
    Task<IEnumerable<Project_Employee>> GetAllAsync();
    Task<IEnumerable<Project_Employee>> GetByProjectAsync(int projectId);
    Task<Project_Employee?> AddEmployeeAsync(AddEmployeeToProjectDto dto);
    Task<bool> RemoveEmployeeAsync(int projectId, string userId);
}

