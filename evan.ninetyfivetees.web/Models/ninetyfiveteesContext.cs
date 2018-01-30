using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace evan.ninetyfivetees.web.Models
{
    public partial class ninetyfiveteesContext : DbContext
    {
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Designs> Designs { get; set; }
        public virtual DbSet<Shirts> Shirts { get; set; }
        public virtual DbSet<Size> Size { get; set; }

        public ninetyfiveteesContext(DbContextOptions<ninetyfiveteesContext> options)
    : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Designs>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Shirts>(entity =>
            {
                entity.Property(e => e.ColorId).HasColumnName("colorId");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.DesignId).HasColumnName("designId");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.SizeId).HasColumnName("sizeId");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.Shirts)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("FK_Shirts_Color");

                entity.HasOne(d => d.Design)
                    .WithMany(p => p.Shirts)
                    .HasForeignKey(d => d.DesignId)
                    .HasConstraintName("FK_Shirts_Designs");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.Shirts)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK_Shirts_Size");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });
        }
    }
}
