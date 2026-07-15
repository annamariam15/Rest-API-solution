namespace AnnaMariaSolution.Server.Models;
using System.ComponentModel.DataAnnotations;
public class Employee_Task
{
    public int Task_ID { get; set; }

    public int Project_ID { get; set; }

    public int Creator_ID { get; set; }

    public int Assigned_ID { get; set; }

    public string Status { get; set; }

    [Required]
    public string Name { get; set; }

    public string Desc { get; set; }

    public DateTime Created { get; set; }

    public DateTime LastUpdate { get; set; }
}
