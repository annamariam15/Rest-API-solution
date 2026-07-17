/*using AnnaMariaSolution.Server.Data;
using AnnaMariaSolution.Server.DTOs;
using AnnaMariaSolution.Server.Models;
using AnnaMariaSolution.Server.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore; // needed for ToListAsync

namespace AnnaMariaSolution.Server.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProjectService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<Project> CreateAsync(Project project)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Project?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Project?> UpdateAsync(int id, Project project)
        {
            throw new NotImplementedException();
        }

        Task<Project> IProjectService.CreateProjectAsync(CreateProjectRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task CreateProjectAsync(CreateProjectRequest request)
        {
            try
            {
                var todo = _mapper.Map<Project>(request);
                todo.Created = DateTime.UtcNow;
                _context.Projects.Add(project);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the Todo item.");
            }
        }

        //fetch all projects from db
        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            var project = await _context.Projects.ToListAsync();
            if (project == null)
            {
                throw new Exception(" No project items found");
            }
            return project;
        }
    }
}
*/