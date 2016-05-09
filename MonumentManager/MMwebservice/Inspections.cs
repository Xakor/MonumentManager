namespace MMwebservice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inspections
    {
        [Key]
        public int Inspection_Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Inspection_Date { get; set; }

        public int Sculpture_Id { get; set; }

        [StringLength(50)]
        public string Inspection_NoteTitle { get; set; }

        public string Inspection_NoteContent { get; set; }

        public virtual Sculptures Sculptures { get; set; }
    }
}
