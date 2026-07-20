namespace AnnaMariaSolution.Server.DTOs
{
    public class UpdateProjectDto
    {
        public string Name { get; set; } = "";
        public string? Desc { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsComplete { get; set; }
    }

}
