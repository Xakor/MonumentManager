namespace MMwebservice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Damages
    {
        [Key]
        public int Damage_Id { get; set; }

        [Required]
        public string Damage_Name { get; set; }

        public string CareRecommendation { get; set; }

        public int? CareFrequency { get; set; }

        public int Sculpture_Id { get; set; }

        public virtual Sculptures Sculptures { get; set; }
    }
}
