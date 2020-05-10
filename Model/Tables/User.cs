using System;
using System.Collections.Generic;

namespace Model.Tables
{
    public partial class User
    {
        public User()
        {
            Dbbc = new HashSet<Dbbc>();
            Table = new HashSet<Table>();
        }

        public int Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string Credit { get; set; }

        public virtual ICollection<Dbbc> Dbbc { get; set; }
        public virtual ICollection<Table> Table { get; set; }
    }
}
