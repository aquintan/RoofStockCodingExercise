using Microsoft.EntityFrameworkCore;

namespace RoofStock.CodingExercise.Api.Data.Database
{
    using Domain;

    public partial class PropertiesContext : DbContext
    {
        public PropertiesContext()
        {
        }

        public PropertiesContext(DbContextOptions<PropertiesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Property> Properties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Address)
                    .HasMaxLength(200);

                entity.Property(e => e.Guid).ValueGeneratedOnAdd();
                entity.Property(e => e.YearBuilt);
                entity.Property(e => e.MonthlyRent);
                entity.Property(e => e.ListPrice);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}