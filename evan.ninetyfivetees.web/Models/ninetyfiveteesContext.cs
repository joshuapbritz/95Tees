using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace evan.ninetyfivetees.web.Models
{
    public partial class ninetyfiveteesContext : DbContext
    {
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Designs> Designs { get; set; }
        public virtual DbSet<Genders> Genders { get; set; }
        public virtual DbSet<Shirts> Shirts { get; set; }
        public virtual DbSet<ShirtSizes> ShirtSizes { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<YearSeasons> YearSeasons { get; set; }

        public ninetyfiveteesContext(DbContextOptions<ninetyfiveteesContext> options) : base(options)
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

            modelBuilder.Entity<Genders>(entity =>
            {
                entity.ToTable("genders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Shirts>(entity =>
            {
                entity.HasIndex(e => e.ColorId);

                entity.HasIndex(e => e.DesignId);

                entity.HasIndex(e => e.GenderId);

                entity.HasIndex(e => e.SeasonId);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ColorId).HasColumnName("colorId");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(550);

                entity.Property(e => e.DesignId).HasColumnName("designId");

                entity.Property(e => e.GenderId).HasColumnName("genderId");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Instock).HasColumnName("instock");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.SeasonId).HasColumnName("seasonId");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(150);

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.Shirts)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("FK_Shirts_Color");

                entity.HasOne(d => d.Design)
                    .WithMany(p => p.Shirts)
                    .HasForeignKey(d => d.DesignId)
                    .HasConstraintName("FK_Shirts_Designs");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Shirts)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_Shirts_genders");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.InverseIdNavigation)
                    .HasForeignKey<Shirts>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shirts_Shirts1");

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.Shirts)
                    .HasForeignKey(d => d.SeasonId)
                    .HasConstraintName("FK_Shirts_YearSeasons");
            });

            modelBuilder.Entity<ShirtSizes>(entity =>
            {
                entity.HasKey(e => new { e.ShirtId, e.SizeId });

                entity.Property(e => e.ShirtId).HasColumnName("shirtId");

                entity.Property(e => e.SizeId).HasColumnName("sizeId");

                entity.HasOne(d => d.Shirt)
                    .WithMany(p => p.ShirtSizes)
                    .HasForeignKey(d => d.ShirtId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShirtSizes_Shirts");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.ShirtSizes)
                    .HasForeignKey(d => d.SizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShirtSizes_Size");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<YearSeasons>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(250);
            });
        }
    }
}
