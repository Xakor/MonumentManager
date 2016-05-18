using System.Web.Http;

namespace MMwebservice
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
            // because the damages refer to sculpture and sculpture refers to damages, we need to handle the endless loop as below
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            // because we have the data in json format we need to remove the xml format 
            GlobalConfiguration.Configuration.Formatters.Remove(
                GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }

        public virtual DbSet<Damages> Damages { get; set; }
        public virtual DbSet<Inspections> Inspections { get; set; }
        public virtual DbSet<Sculptures> Sculptures { get; set; }
        public virtual DbSet<SculptureValues> SculptureValues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inspections>()
                .Property(e => e.Inspection_NoteTitle)
                .IsFixedLength();

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
                .Property(e => e.Sculpture_Material)
                .IsFixedLength();

            modelBuilder.Entity<Sculptures>()
                .Property(e => e.Sculpture_Type)
                .IsFixedLength();

            modelBuilder.Entity<Sculptures>()
                .HasMany(e => e.Damages)
                .WithRequired(e => e.Sculptures)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sculptures>()
                .HasMany(e => e.Inspections)
                .WithRequired(e => e.Sculptures)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sculptures>()
                .HasMany(e => e.SculptureValues)
                .WithRequired(e => e.Sculptures)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SculptureValues>()
                .Property(e => e.Value)
                .IsUnicode(false);
        }
    }
}
