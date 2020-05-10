using System;
using System.Collections.Generic;

namespace Model.Tables
{
    public partial class Table
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Dbbcid { get; set; }

        public virtual Dbbc Dbbc { get; set; }
        public virtual User User { get; set; }
    }
}
