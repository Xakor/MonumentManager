namespace MMWebService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SculptureContext : DbContext
    {
        public SculptureContext()
            : base("name=SculptureContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<DamageRecommendation> DamageRecommendation { get; set; }
        public virtual DbSet<Damages> Damages { get; set; }
        public virtual DbSet<Inspections> Inspections { get; set; }
        public virtual DbSet<Materials> Materials { get; set; }
        public virtual DbSet<Sculptures> Sculptures { get; set; }
        public virtual DbSet<SculptureValues> SculptureValues { get; set; }
        public virtual DbSet<Types> Types { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DamageRecommendation>()
                .Property(e => e.CareDescription)
                .IsFixedLength();

            modelBuilder.Entity<Damages>()
                .Property(e => e.Damage_Name)
                .IsFixedLength();

            modelBuilder.Entity<Damages>()
                .HasMany(e => e.Sculptures)
                .WithMany(e => e.Damages)
                .Map(m => m.ToTable("SculpturesDamages").MapLeftKey("Damages_Id").MapRightKey("Sculpture_Id"));

            modelBuilder.Entity<Inspections>()
                .Property(e => e.Inspection_NoteTitle)
                .IsFixedLength();

            modelBuilder.Entity<Materials>()
                .Property(e => e.Material_Name)
                .IsFixedLength();

            modelBuilder.Entity<Materials>()
                .HasMany(e => e.Sculptures)
                .WithMany(e => e.Materials)
                .Map(m => m.ToTable("SculptureMaterials").MapLeftKey("Material_Id").MapRightKey("Sculpture_Id"));

            modelBuilder.Entity<Sculptures>()
                .Property(e => e.Sculpture_Name)
                .IsFixedLength();

            modelBuilder.Entity<Sculptures>()
                .Property(e => e.Sculpture_Address)
                .IsFixedLength();

            modelBuilder.Entity<Sculptures>()
                .Property(e => e.Sculpture_Placement)
                .IsFixedLength();

            modelBuilder.Entity<Sculptures>()
                .HasMany(e => e.Inspections)
                .WithRequired(e => e.Sculptures)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sculptures>()
                .HasMany(e => e.SculptureValues)
                .WithRequired(e => e.Sculptures)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sculptures>()
                .HasMany(e => e.Types)
                .WithMany(e => e.Sculptures)
                .Map(m => m.ToTable("SculptureTypes").MapLeftKey("Sculpture_Id").MapRightKey("Type_Id"));

            modelBuilder.Entity<SculptureValues>()
                .Property(e => e.Value)
                .IsUnicode(false);

            modelBuilder.Entity<Types>()
                .Property(e => e.Type_Name)
                .IsFixedLength();
        }
    }
}
