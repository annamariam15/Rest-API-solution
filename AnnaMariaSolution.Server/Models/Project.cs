using AnnaMariaSolution.Server.Models;
using System.ComponentModel.DataAnnotations;

public class Project
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Desc { get; set; }

    public DateTime Created { get; set; }

    public DateTime Deadline { get; set; }

    public bool IsComplete { get; set; } = false;

    public ICollection<Project_Employee> ProjectEmployees { get; set; } = new List<Project_Employee>();

    public ICollection<Employee_Task> Tasks { get; set; } = new List<Employee_Task>();
}
