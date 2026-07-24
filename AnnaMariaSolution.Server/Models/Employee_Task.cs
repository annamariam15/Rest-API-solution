namespace AnnaMariaSolution.Server.Models;
using System.ComponentModel.DataAnnotations;
public class Employee_Task
{
    public int Id { get; set; }

    public int Project { get; set; }

    public string CreatorId { get; set; }
    public User Creator { get; set; }

    public string AssignedId { get; set; }
    public User Assigned { get; set; }

    public string Status { get; set; }
    [Required]
    public string Name { get; set; }
    public string Desc { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastUpdate { get; set; }

}
