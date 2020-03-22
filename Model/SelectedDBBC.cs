namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SelectedDBBC")]
    public partial class SelectedDBBC
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? DBBCId { get; set; }

        public virtual DBBC DBBC { get; set; }

        public virtual User User { get; set; }
    }
}
