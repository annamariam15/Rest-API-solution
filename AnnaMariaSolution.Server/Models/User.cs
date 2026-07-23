using Microsoft.AspNetCore.Identity;
namespace AnnaMariaSolution.Server.Models;

public class User : IdentityUser
{
    public string? ProfilePicture { get; set; }

    public ICollection<Project_Employee> ProjectEmployees { get; set; }
        = new List<Project_Employee>();
    public ICollection<Employee_Task> Tasks { get; set; }
        = new List<Employee_Task>();
}

