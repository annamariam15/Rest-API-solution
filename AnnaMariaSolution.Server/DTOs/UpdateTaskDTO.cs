using System.ComponentModel.DataAnnotations;

namespace AnnaMariaSolution.Server.DTOs;

public class UpdateTaskDto
{
    public int Creator { get; set; }

    public int Assigned { get; set; }

    public string Status { get; set; } = "Pending";

    [Required]
    public string Name { get; set; } = "";

    public string? Desc { get; set; }
}
