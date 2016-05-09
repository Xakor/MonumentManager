namespace MMwebservice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SculptureValues
    {
        [Key]
        public int Value_Id { get; set; }

        [StringLength(1)]
        public string Value { get; set; }

        public int Sculpture_Id { get; set; }

        public string Value_Note { get; set; }

        public virtual Sculptures Sculptures { get; set; }
    }
}
