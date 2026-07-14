using System;
using System.Collections.Generic;
using System.Text;

namespace Solution_dbEntities
{
    public class Project_Employee
    {
        public int P_E_Id { get; set; }

        public int P_ID { get; set; }

        public string U_ID { get; set; } = null!;

        public DateTime JoinedAt { get; set; }

        public Project Project { get; set; } = null!;

        public User User { get; set; } = null!;
    }
}
