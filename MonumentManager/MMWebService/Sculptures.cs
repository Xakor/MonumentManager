namespace MMWebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sculptures
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sculptures()
        {
            Inspections = new HashSet<Inspections>();
            SculptureValues = new HashSet<SculptureValues>();
            Materials = new HashSet<Materials>();
            Damages = new HashSet<Damages>();
            Types = new HashSet<Types>();
        }

        [Key]
        public int Sculpture_Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Sculpture_Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Sculpture_Address { get; set; }

        public int Sculpture_InsFreq { get; set; }

        [StringLength(200)]
        public string Sculpture_Placement { get; set; }

        [Column(TypeName = "image")]
        public byte[] Sculpture_Picture { get; set; }

        public bool? Sculpture_DNI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inspections> Inspections { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SculptureValues> SculptureValues { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Materials> Materials { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Damages> Damages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Types> Types { get; set; }
    }
}
