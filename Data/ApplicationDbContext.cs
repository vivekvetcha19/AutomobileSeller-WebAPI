using AutomobileSeller.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomobileSeller.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // -------------------------
            // Brand Configuration
            // -------------------------
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brands");

                entity.HasKey(b => b.Id);

                entity.Property(b => b.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(b => b.Country)
                      .HasMaxLength(100);

                entity.Property(b => b.CreatedDate)
                      .HasDefaultValueSql("GETUTCDATE()");
            });

            // -------------------------
            // CarModel Configuration
            // -------------------------
            modelBuilder.Entity<CarModel>(entity =>
            {
                entity.ToTable("CarModels");

                entity.HasKey(cm => cm.Id);

                entity.Property(cm => cm.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(cm => cm.Price)
                      .HasColumnType("decimal(18,2)");

                entity.HasOne(cm => cm.Brand)
                      .WithMany(b => b.CarModels)
                      .HasForeignKey(cm => cm.BrandId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Inventory Configuration
            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventories");

                entity.HasKey(i => i.Id);

                entity.Property(i => i.QuantityInStock)
                      .IsRequired();

                entity.Property(i => i.LastUpdated)
                      .HasDefaultValueSql("GETUTCDATE()");

                entity.HasOne(i => i.CarModel)
                      .WithOne()
                      .HasForeignKey<Inventory>(i => i.CarModelId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Customer config
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers");

                entity.HasKey(c => c.Id);

                entity.Property(c => c.FirstName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(c => c.LastName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(c => c.Email)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(c => c.PhoneNumber)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.Property(c => c.CreatedDate)
                      .HasDefaultValueSql("GETUTCDATE()");
            });
        }
    }
}
