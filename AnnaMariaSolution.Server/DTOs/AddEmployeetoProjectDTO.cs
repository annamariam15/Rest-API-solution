using System.ComponentModel.DataAnnotations;

namespace AnnaMariaSolution.Server.DTOs
{
    public class AddEmployeeToProjectDto
    {
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public string UserId { get; set; } = "";
    }

}
