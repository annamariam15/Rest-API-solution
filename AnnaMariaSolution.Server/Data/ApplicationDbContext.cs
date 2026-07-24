using AnnaMariaSolution.Server.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnnaMariaSolution.Server.Data
{
    public class ApplicationDbContext: IdentityDbContext<User, Role, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }//constructor
        public DbSet<Project> Projects { get; set; } //add project table
        public DbSet<Employee_Task> Tasks { get; set; } //add employee_task table
        public DbSet<Project_Employee> ProjectEmployees { get; set; } //add project_employee table
        //public object Project { get; internal set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); //identity tables

            builder.Entity<Project_Employee>()
                .HasKey(pe => new {pe.Project_ID, pe.User_ID}); //composite pk

            builder.Entity<Project_Employee>() //one project has many employees
                .HasOne(pe => pe.Project)
                .WithMany(p => p.ProjectEmployees)
                .HasForeignKey(pe => pe.Project_ID);

            builder.Entity<Project_Employee>() //one employee can have many projects
                .HasOne(pe => pe.Employee)
                .WithMany(u => u.ProjectEmployees) 
                .HasForeignKey(pe => pe.User_ID);

            builder.Entity<Employee_Task>() //one employee can create many tasks
                .HasOne(t => t.Creator)
                .WithMany(u => u.CreatedTasks) 
                .HasForeignKey(t => t.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.Entity<Employee_Task>() //one employee can be assigned many tasks
                .HasOne(t => t.Assigned)
                .WithMany(u => u.AssignedTasks)
                .HasForeignKey(t => t.AssignedId)
                .OnDelete(DeleteBehavior.Restrict);


        }

    }
}