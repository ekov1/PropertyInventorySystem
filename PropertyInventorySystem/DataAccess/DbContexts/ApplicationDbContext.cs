using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<OwnerEntity> Owners { get; set; }
        public DbSet<PropertyEntity> Properties { get; set; }
        public DbSet<PropertyOwnerEntity> PropertyOwners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PropertyOwnerEntity>()
                .HasKey(k => new { k.PropertyId, k.OwnerId });
            modelBuilder.Entity<PropertyOwnerEntity>()
                .HasOne(po => po.Property)
                .WithMany(b => b.PropertyOwners)
                .HasForeignKey(fk => fk.PropertyId);
            modelBuilder.Entity<PropertyOwnerEntity>()
                .HasOne(bc => bc.Owner)
                .WithMany(c => c.PropertyOwners)
                .HasForeignKey(fk => fk.OwnerId);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Server=.;Database=PropertyInventorySystemDB;Trusted_Connection=True;TrustServerCertificate=True;");
        //}
    }
}
