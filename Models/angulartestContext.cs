using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AngularTestApi.Models
{
    public partial class angulartestContext : DbContext
    {

        public angulartestContext()
        {

        }

        public angulartestContext(DbContextOptions<angulartestContext> options) : base(options)
        {

        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<ItemCategories> ItemCategories { get; set; }
        public virtual DbSet<Items> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=angulartest;Persist Security Info=True;User ID=sa;Password=Aptean@123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<ItemCategories>(entity =>
            {
                entity.HasKey(e => e.ItemCategoryId);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ItemCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_ItemCategories_Categories");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemCategories)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_ItemCategories_Items");
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.Property(e => e.Name).HasMaxLength(200);
            });
        }
    }
}
