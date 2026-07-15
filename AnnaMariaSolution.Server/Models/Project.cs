using System.ComponentModel.DataAnnotations;
namespace AnnaMariaSolution.Server.Models;
public class Project
    {
    public int Project_ID { get; set; }
        
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(500)]
    public string Desc { get; set; }

    public DateTime Created { get; set; }

    public DateTime Deadline { get; set; }

    public ICollection<Project_Employee> ProjectEmployees { get; set; }

    public ICollection<Employee_Task> Tasks { get; set; }
}