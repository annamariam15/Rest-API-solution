//using AnnaMariaSolution.Server.Services.Interfaces;
//using Azure.Core;
//using AnnaMariaSolution.Server.Models;

using AnnaMariaSolution.Server.Data;
using AnnaMariaSolution.Server.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnnaMariaSolution.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase //ControllerBase functionality
    {
        private readonly ApplicationDbContext _context; //db context

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        } //constructor


        [Authorize]
        [HttpGet] //retrieves all projects
        public async Task<IActionResult> GetAll() => Ok(await _context.Projects.ToListAsync());

        [Authorize]
        [HttpGet("{id}")]// retrieves by id
        public async Task<IActionResult> Get(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            return project == null ? NotFound() : Ok(project);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost] //create project
        public async Task<IActionResult> CreateProjectAsync(CreateProjectDto dto)
        {
            var project = new Project
            {
                Name = dto.Name,
                Desc = dto.Desc,
                Deadline = dto.Deadline,
                Created = DateTime.UtcNow
            };

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = project.Id }, project);
        }



        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")] //update project by id
        public async Task<IActionResult> Update(int id, UpdateProjectDto dto)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
                return NotFound();

            project.Name = dto.Name;
            project.Desc = dto.Desc;
            project.Deadline = dto.Deadline;
            project.IsComplete = dto.IsComplete;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")] //delete by id
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null) return NotFound();
            _context.Projects.Remove(project); //marks for deletion
            await _context.SaveChangesAsync(); // tldr sql execution
            return NoContent();
        }

    }
}
