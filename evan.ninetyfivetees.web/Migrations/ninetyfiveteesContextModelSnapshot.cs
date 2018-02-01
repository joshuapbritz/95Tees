﻿// <auto-generated />
using evan.ninetyfivetees.web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace evan.ninetyfivetees.web.Migrations
{
    [DbContext(typeof(ninetyfiveteesContext))]
    partial class ninetyfiveteesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("evan.ninetyfivetees.web.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Color");
                });

            modelBuilder.Entity("evan.ninetyfivetees.web.Models.Designs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Designs");
                });

            modelBuilder.Entity("evan.ninetyfivetees.web.Models.Genders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("genders");
                });

            modelBuilder.Entity("evan.ninetyfivetees.web.Models.Shirts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int?>("ColorId")
                        .HasColumnName("colorId");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasMaxLength(550);

                    b.Property<int?>("DesignId")
                        .HasColumnName("designId");

                    b.Property<int?>("GenderId")
                        .HasColumnName("genderId");

                    b.Property<string>("Image")
                        .HasColumnName("image");

                    b.Property<bool?>("Instock")
                        .HasColumnName("instock");

                    b.Property<int?>("Price")
                        .HasColumnName("price");

                    b.Property<int?>("SeasonId")
                        .HasColumnName("seasonId");

                    b.Property<string>("Title")
                        .HasColumnName("title")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("DesignId");

                    b.HasIndex("GenderId");

                    b.HasIndex("SeasonId");

                    b.ToTable("Shirts");
                });

            modelBuilder.Entity("evan.ninetyfivetees.web.Models.ShirtSizes", b =>
                {
                    b.Property<int>("ShirtId")
                        .HasColumnName("shirtId");

                    b.Property<int>("SizeId")
                        .HasColumnName("sizeId");

                    b.HasKey("ShirtId", "SizeId");

                    b.HasIndex("SizeId");

                    b.ToTable("ShirtSizes");
                });

            modelBuilder.Entity("evan.ninetyfivetees.web.Models.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Size");
                });

            modelBuilder.Entity("evan.ninetyfivetees.web.Models.YearSeasons", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("YearSeasons");
                });

            modelBuilder.Entity("evan.ninetyfivetees.web.Models.Shirts", b =>
                {
                    b.HasOne("evan.ninetyfivetees.web.Models.Color", "Color")
                        .WithMany("Shirts")
                        .HasForeignKey("ColorId")
                        .HasConstraintName("FK_Shirts_Color");

                    b.HasOne("evan.ninetyfivetees.web.Models.Designs", "Design")
                        .WithMany("Shirts")
                        .HasForeignKey("DesignId")
                        .HasConstraintName("FK_Shirts_Designs");

                    b.HasOne("evan.ninetyfivetees.web.Models.Genders", "Gender")
                        .WithMany("Shirts")
                        .HasForeignKey("GenderId")
                        .HasConstraintName("FK_Shirts_genders");

                    b.HasOne("evan.ninetyfivetees.web.Models.Shirts", "IdNavigation")
                        .WithOne("InverseIdNavigation")
                        .HasForeignKey("evan.ninetyfivetees.web.Models.Shirts", "Id")
                        .HasConstraintName("FK_Shirts_Shirts1");

                    b.HasOne("evan.ninetyfivetees.web.Models.YearSeasons", "Season")
                        .WithMany("Shirts")
                        .HasForeignKey("SeasonId")
                        .HasConstraintName("FK_Shirts_YearSeasons");
                });

            modelBuilder.Entity("evan.ninetyfivetees.web.Models.ShirtSizes", b =>
                {
                    b.HasOne("evan.ninetyfivetees.web.Models.Shirts", "Shirt")
                        .WithMany("ShirtSizes")
                        .HasForeignKey("ShirtId")
                        .HasConstraintName("FK_ShirtSizes_Shirts");

                    b.HasOne("evan.ninetyfivetees.web.Models.Size", "Size")
                        .WithMany("ShirtSizes")
                        .HasForeignKey("SizeId")
                        .HasConstraintName("FK_ShirtSizes_Size");
                });
#pragma warning restore 612, 618
        }
    }
}
