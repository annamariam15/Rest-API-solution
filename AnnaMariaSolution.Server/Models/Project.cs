using System.ComponentModel.DataAnnotations;
namespace AnnaMariaSolution.Server.Models;
public class Project
    {
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(500)]
    public string Desc { get; set; }

    public DateTime Created { get; set; }

    public DateTime Deadline { get; set; }

    public bool IsComplete { get; set; }

    public ICollection<Project_Employee> ProjectEmployees { get; set; }

    public ICollection<Employee_Task> Tasks { get; set; }

    public Project(){ IsComplete = false; }
}