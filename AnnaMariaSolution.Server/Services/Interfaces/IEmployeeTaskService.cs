using AnnaMariaSolution.Server.DTOs;
using AnnaMariaSolution.Server.Models;

namespace AnnaMariaSolution.Server.Services;

public interface IEmployeeTaskService
{
    Task<IEnumerable<Employee_Task>> GetAllAsync();
    Task<Employee_Task?> GetByIdAsync(int id);
    Task<Employee_Task> CreateAsync(CreateTaskDto dto);
    Task<bool> UpdateAsync(int id, UpdateTaskDto dto);
    Task<bool> DeleteAsync(int id);
}
