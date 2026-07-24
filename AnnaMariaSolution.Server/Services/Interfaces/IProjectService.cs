using AnnaMariaSolution.Server.DTOs;
namespace AnnaMariaSolution.Server.Services;

public interface IProjectService
{
    Task<IEnumerable<Project>> GetAllAsync();
    Task<Project?> GetByIdAsync(int id);
    Task<Project> CreateAsync(CreateProjectDto dto);
    Task<bool> UpdateAsync(int id, UpdateProjectDto dto);
    Task<bool> DeleteAsync(int id);
}
