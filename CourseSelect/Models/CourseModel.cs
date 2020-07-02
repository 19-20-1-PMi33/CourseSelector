using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseSelect.Models
{
    public class CourseModel
    {
        public Dbbc Dbbc { get; set; }
        public Dbbctouser Dbbctouser { get; set; }
        public List<AspNetUsers> Users { get; set; }
    }
}