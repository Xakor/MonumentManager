namespace MMWebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DamageRecommendation")]
    public partial class DamageRecommendation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CareRecommendation_Id { get; set; }

        [StringLength(50)]
        public string CareDescription { get; set; }
    }
}
