using System;
using System.Collections.Generic;

namespace Model.Tables
{
    public partial class Dbbc
    {
        public Dbbc()
        {
            Table = new HashSet<Table>();
        }

        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? NumberOfSeats { get; set; }
        public int NumberSetsUsed { get; set; }

        public virtual User Teacher { get; set; }
        public virtual ICollection<Table> Table { get; set; }
    }
}
