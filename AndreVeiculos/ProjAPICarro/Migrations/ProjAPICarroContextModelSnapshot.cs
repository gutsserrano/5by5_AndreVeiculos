﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjAPICarro.Data;

#nullable disable

namespace ProjAPICarro.Migrations
{
    [DbContext(typeof(ProjAPICarroContext))]
    partial class ProjAPICarroContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicPlaceType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Models.Car", b =>
                {
                    b.Property<string>("Plate")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManufactureYear")
                        .HasColumnType("int");

                    b.Property<int>("ModelYear")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Sold")
                        .HasColumnType("bit");

                    b.HasKey("Plate");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("Models.CarOperation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CarPlate")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CarPlate1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<int>("OperationId")
                        .HasColumnType("int");

                    b.Property<int?>("OperationId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarPlate");

                    b.HasIndex("CarPlate1");

                    b.HasIndex("OperationId");

                    b.HasIndex("OperationId1");

                    b.ToTable("CarOperations");
                });

            modelBuilder.Entity("Models.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("Models.Person", b =>
                {
                    b.Property<string>("Document")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Document");

                    b.HasIndex("AddressId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("Models.Client", b =>
                {
                    b.HasBaseType("Models.Person");

                    b.Property<string>("DocumentPdf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Income")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("Models.Employee", b =>
                {
                    b.HasBaseType("Models.Person");

                    b.Property<decimal>("ComissionValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Commission")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.HasIndex("PositionId");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("Models.CarOperation", b =>
                {
                    b.HasOne("Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarPlate");

                    b.HasOne("Models.Car", null)
                        .WithMany()
                        .HasForeignKey("CarPlate1");

                    b.HasOne("Models.Operation", "Operation")
                        .WithMany()
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Operation", null)
                        .WithMany()
                        .HasForeignKey("OperationId1");

                    b.Navigation("Car");

                    b.Navigation("Operation");
                });

            modelBuilder.Entity("Models.Person", b =>
                {
                    b.HasOne("Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Models.Client", b =>
                {
                    b.HasOne("Models.Person", null)
                        .WithOne()
                        .HasForeignKey("Models.Client", "Document")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Employee", b =>
                {
                    b.HasOne("Models.Person", null)
                        .WithOne()
                        .HasForeignKey("Models.Employee", "Document")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");
                });
#pragma warning restore 612, 618
        }
    }
}
