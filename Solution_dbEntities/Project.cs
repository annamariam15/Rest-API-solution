namespace Solution_dbEntities
{
    public class Project
    {
        public int P_ID { get; set; }
        public string Name { get; set; }

        public string Desc { get; set; }

        public DateTime Created { get; set; }

        public DateTime Deadline { get; set; }

    }
}
