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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); //identity tables


            builder.Entity<Project_Employee>()
                .HasKey(pe => new {pe.Project_ID, pe.User_ID}); //composite pk

            builder.Entity<Project_Employee>()
                .HasOne(pe => pe.Project)
                .WithMany(p => p.ProjectEmployees) //1:M
                .HasForeignKey(pe => pe.Project_ID);

            builder.Entity<Project_Employee>()
                .HasOne(pe => pe.Employee)
                .WithMany(u => u.ProjectEmployees) //1:M
                .HasForeignKey(pe => pe.User_ID);
        }
    }
}