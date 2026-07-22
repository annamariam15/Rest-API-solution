namespace AnnaMariaSolution.Server.Models;
using System.ComponentModel.DataAnnotations;
public class Employee_Task
{
    [Key]
    public int Id { get; set; }
    public int Project { get; set; }
    public string Creator { get; set; } = string.Empty;
    public string Assigned { get; set; } = string.Empty;
    public string Status { get; set; }
    [Required]
    public string Name { get; set; }
    public string Desc { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastUpdate { get; set; }

}
