using System.ComponentModel.DataAnnotations;

namespace AnnaMariaSolution.Server.DTOs
{
    public class CreateTaskDto
    {
        [Required]
        public int ProjectId { get; set; }
        public string CreatorId { get; set; } = string.Empty;
        public string AssignedId { get; set; } = string.Empty;

        public string Status { get; set; } = "Pending";

        [Required]
        public string Name { get; set; } = "";

        public string? Desc { get; set; }
    }

}
