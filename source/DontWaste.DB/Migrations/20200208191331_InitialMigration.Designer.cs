﻿// <auto-generated />
using System;
using DontWaste.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DontWaste.DB.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200208191331_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DontWaste.DB.Domain.FoodCategory", b =>
                {
                    b.Property<Guid>("FoodCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FoodCategoryId");

                    b.ToTable("FoodCategories");
                });

            modelBuilder.Entity("DontWaste.DB.Domain.FoodItem", b =>
                {
                    b.Property<Guid>("FoodItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("DishName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FoodCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FoodItemDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ImageFileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("FoodItemId");

                    b.HasIndex("FoodCategoryId");

                    b.HasIndex("ImageFileId");

                    b.HasIndex("OrderId");

                    b.ToTable("FoodItems");
                });

            modelBuilder.Entity("DontWaste.DB.Domain.ImageFile", b =>
                {
                    b.Property<Guid>("ImageFileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Image")
                        .HasColumnType("tinyint");

                    b.HasKey("ImageFileId");

                    b.ToTable("ImageFiles");
                });

            modelBuilder.Entity("DontWaste.DB.Domain.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DontWaste.DB.Domain.FoodItem", b =>
                {
                    b.HasOne("DontWaste.DB.Domain.FoodCategory", "FoodCategory")
                        .WithMany("FoodItems")
                        .HasForeignKey("FoodCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DontWaste.DB.Domain.ImageFile", "Image")
                        .WithMany()
                        .HasForeignKey("ImageFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DontWaste.DB.Domain.Order", null)
                        .WithMany("FoodItems")
                        .HasForeignKey("OrderId");
                });
#pragma warning restore 612, 618
        }
    }
}