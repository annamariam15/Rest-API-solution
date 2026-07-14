using System;
using System.Collections.Generic;
using System.Text;

namespace Solution_dbEntities
{
    public class Task
    {
        public int T_ID { get; set; }

        public int P_ID { get; set; }

        public int Creator_ID { get; set; }

        public int Assigned_ID { get; set; }

        public string Status { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}
