﻿// <auto-generated />
using DeMoMVCNetCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DeMoMVCNetCore.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20211129015753_1")]
    partial class _1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("DeMoMVCNetCore.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Categorynote")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("KeySearch")
                        .HasColumnType("TEXT");

                    b.Property<string>("MovieGenre")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DeMoMVCNetCore.Models.Demo", b =>
                {
                    b.Property<string>("DemoID")
                        .HasColumnType("TEXT");

                    b.Property<string>("DemoName")
                        .HasColumnType("TEXT");

                    b.HasKey("DemoID");

                    b.ToTable("Demo");
                });

            modelBuilder.Entity("DeMoMVCNetCore.Models.HiHi", b =>
                {
                    b.Property<int>("HiHiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HiHIname")
                        .HasColumnType("TEXT");

                    b.HasKey("HiHiId");

                    b.HasIndex("CategoryID");

                    b.ToTable("HiHi");
                });

            modelBuilder.Entity("DeMoMVCNetCore.Models.Person", b =>
                {
                    b.Property<int>("PerSonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .HasColumnType("TEXT");

                    b.HasKey("PerSonID");

                    b.ToTable("people");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("DeMoMVCNetCore.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProductName")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DeMoMVCNetCore.Models.Employees", b =>
                {
                    b.HasBaseType("DeMoMVCNetCore.Models.Person");

                    b.Property<int>("EplID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EplName")
                        .HasColumnType("TEXT");

                    b.ToTable("people");

                    b.HasDiscriminator().HasValue("Employees");
                });

            modelBuilder.Entity("DeMoMVCNetCore.Models.Student", b =>
                {
                    b.HasBaseType("DeMoMVCNetCore.Models.Person");

                    b.Property<int>("StudentID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("University")
                        .HasColumnType("TEXT");

                    b.ToTable("people");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("DeMoMVCNetCore.Models.HiHi", b =>
                {
                    b.HasOne("DeMoMVCNetCore.Models.Category", "Category")
                        .WithMany("HiHis")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("DeMoMVCNetCore.Models.Product", b =>
                {
                    b.HasOne("DeMoMVCNetCore.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("DeMoMVCNetCore.Models.Category", b =>
                {
                    b.Navigation("HiHis");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
