﻿// <auto-generated />
using System;
using AutomationService.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutomationService.EF.Migrations
{
    [DbContext(typeof(AutomationServiceDBContext))]
    [Migration("20221123134237_mig_4")]
    partial class mig4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AutomationService.EF.DTOs.BreakdownDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("BreakdownSolverId")
                        .HasColumnType("int");

                    b.Property<string>("Cause")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsElectrical")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMechanical")
                        .HasColumnType("bit");

                    b.Property<int>("SectorId")
                        .HasColumnType("int");

                    b.Property<string>("Service")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SolvedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BreakdownSolverId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("SectorId");

                    b.ToTable("Breakdowns");
                });

            modelBuilder.Entity("AutomationService.EF.DTOs.BreakdownFileDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BreakdownId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BreakdownId");

                    b.ToTable("BreadownFiles");
                });

            modelBuilder.Entity("AutomationService.EF.DTOs.BreakdownSolverDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NameSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BreakdownSolvers");
                });

            modelBuilder.Entity("AutomationService.EF.DTOs.CustomerDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("AutomationService.EF.DTOs.DepartmentDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("AutomationService.EF.DTOs.EmployeeDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NameSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("AutomationService.EF.DTOs.SectorDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("SectorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sectors");
                });

            modelBuilder.Entity("CustomerDTOEmployeeDTO", b =>
                {
                    b.Property<int>("CustomersDTOId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeesId")
                        .HasColumnType("int");

                    b.HasKey("CustomersDTOId", "EmployeesId");

                    b.HasIndex("EmployeesId");

                    b.ToTable("CustomerDTOEmployeeDTO");
                });

            modelBuilder.Entity("AutomationService.EF.DTOs.BreakdownDTO", b =>
                {
                    b.HasOne("AutomationService.EF.DTOs.BreakdownSolverDTO", "BreakdownSolver")
                        .WithMany("Breakdowns")
                        .HasForeignKey("BreakdownSolverId");

                    b.HasOne("AutomationService.EF.DTOs.CustomerDTO", "Customer")
                        .WithMany("Breakdowns")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutomationService.EF.DTOs.DepartmentDTO", "Department")
                        .WithMany("BreakdownDTOs")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutomationService.EF.DTOs.EmployeeDTO", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutomationService.EF.DTOs.SectorDTO", "Sector")
                        .WithMany("BreakdownDTOs")
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BreakdownSolver");

                    b.Navigation("Customer");

                    b.Navigation("Department");

                    b.Navigation("Employee");

                    b.Navigation("Sector");
                });

            modelBuilder.Entity("AutomationService.EF.DTOs.BreakdownFileDTO", b =>
                {
                    b.HasOne("AutomationService.EF.DTOs.BreakdownDTO", "Breakdown")
                        .WithMany("BreadownFiles")
                        .HasForeignKey("BreakdownId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Breakdown");
                });

            modelBuilder.Entity("CustomerDTOEmployeeDTO", b =>
                {
                    b.HasOne("AutomationService.EF.DTOs.CustomerDTO", null)
                        .WithMany()
                        .HasForeignKey("CustomersDTOId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutomationService.EF.DTOs.EmployeeDTO", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutomationService.EF.DTOs.BreakdownDTO", b =>
                {
                    b.Navigation("BreadownFiles");
                });

            modelBuilder.Entity("AutomationService.EF.DTOs.BreakdownSolverDTO", b =>
                {
                    b.Navigation("Breakdowns");
                });

            modelBuilder.Entity("AutomationService.EF.DTOs.CustomerDTO", b =>
                {
                    b.Navigation("Breakdowns");
                });

            modelBuilder.Entity("AutomationService.EF.DTOs.DepartmentDTO", b =>
                {
                    b.Navigation("BreakdownDTOs");
                });

            modelBuilder.Entity("AutomationService.EF.DTOs.SectorDTO", b =>
                {
                    b.Navigation("BreakdownDTOs");
                });
#pragma warning restore 612, 618
        }
    }
}
