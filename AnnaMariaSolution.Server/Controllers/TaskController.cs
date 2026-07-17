//literally renamed copy of projectcontroller, nothing worth looking at right now

/*using AnnaMariaSolution.Server.Data;
using AnnaMariaSolution.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace AnnaMariaSolution.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase //ControllerBase functionality
    {
        private readonly ApplicationDbContext _context; //db context

        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        } //constructor


        [HttpGet] //retrieves all tasks
        public async Task<IActionResult> GetAll() => Ok(await _context.Tasks.ToListAsync());

        [HttpGet("{id}")]// get by id
        public async Task<IActionResult> Get(int id)
        {
            var task = await _context.Projects.FindAsync(id);
            return task == null ? NotFound() : Ok(task);
        }


        [HttpPost]// create task
        public async Task<IActionResult> CreateProjectAsync(Employee_Task task)
        {
            _context.Projects.Add(task); //marks entity for insertion
            await _context.SaveChangesAsync(); // tldr sql execution
            return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
        }


        [HttpPut("{id}")] //update task by id
        public async Task<IActionResult> Update(int id, Employee_Task task)
        {
            if (id != project.Id) return BadRequest();
            _context.Entry(project).State = EntityState.Modified; // marks as modifie
            await _context.SaveChangesAsync(); // tldr sql execution
            return NoContent();
        }


        [HttpDelete("{id}")] //delete by id
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _context.Projects.FindAsync(id);
            if (task == null) return NotFound();
            _context.Projects.Remove(task); //marks for deletion
            await _context.SaveChangesAsync(); // tldr sql execution
            return NoContent();
        }

    }
}*/
