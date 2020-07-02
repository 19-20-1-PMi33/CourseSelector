using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public partial class Dbbctouser
    {
        public int? Id { get; set; }
        public string UserId { get; set; }
        public int? Dbbcid { get; set; }
        [Display(Name = "Notate")]
        public string Notate { get; set; }
        public virtual Dbbc Dbbc { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}