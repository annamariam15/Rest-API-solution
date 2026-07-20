namespace AnnaMariaSolution.Server.DTOs
{
    public class CreateProjectDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Desc { get; set; }
        public DateTime Deadline { get; set; }
    }

}
