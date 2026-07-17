namespace AnnaMariaSolution.Server.Models;
public class Project_Employee
{
    public int Project_ID { get; set; }
    public string User_ID { get; set; } = null!;
    public Project Project { get; set; } = null!;
    public User Employee { get; set; } = null!;
    public DateTime JoinedAt { get; set; }
}
