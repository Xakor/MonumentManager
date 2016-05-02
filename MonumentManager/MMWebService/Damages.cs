namespace MMWebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Damages
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Damages()
        {
            Sculptures = new HashSet<Sculptures>();
        }

        [Key]
        public int Damage_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Damage_Name { get; set; }

        public int? CareRecommendation_Id { get; set; }

        public int? CareFrequency { get; set; }

        [Column(TypeName = "image")]
        public byte[] Damage_Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sculptures> Sculptures { get; set; }
    }
}
