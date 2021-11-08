﻿// <auto-generated />
using DeMoMVCNetCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DeMoMVCNetCore.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20211108015700_1234")]
    partial class _1234
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("DeMoMVCNetCore.Models.Employees", b =>
                {
                    b.Property<string>("EmployeeID")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DeMoMVCNetCore.Models.Person", b =>
                {
                    b.Property<string>("PersonID")
                        .HasColumnType("TEXT");

                    b.Property<string>("PersonName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("PersonID");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("DeMoMVCNetCore.Models.Products", b =>
                {
                    b.Property<string>("ProductID")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Quantity")
                        .HasColumnType("TEXT");

                    b.Property<string>("Unitprice")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DeMoMVCNetCore.Models.Students", b =>
                {
                    b.Property<string>("StudenID")
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentName")
                        .HasColumnType("TEXT");

                    b.HasKey("StudenID");

                    b.ToTable("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
