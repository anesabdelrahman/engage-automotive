﻿// <auto-generated />
using System;
using AutomotivePartsOrdering.Service.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutomotivePartsOrdering.Service.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241106001323_Reinstated_Price_Id")]
    partial class Reinstated_Price_Id
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AutomotivePartsOrdering.Service.Domain.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BlockName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BuildingName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoorNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FloorNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasMaxLength(140)
                        .HasColumnType("nvarchar(140)");

                    b.Property<string>("Suburb")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("AutomotivePartsOrdering.Service.Domain.AlternativePart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AlternativeType")
                        .HasColumnType("int");

                    b.Property<Guid?>("PartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("SupersessionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PartId");

                    b.ToTable("AlternativePart");
                });

            modelBuilder.Entity("AutomotivePartsOrdering.Service.Domain.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("AlternateDeliveryAddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DeliveryAddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MandatoryVehicleReferenceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderContactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OrderReference")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<int>("OrderType")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PartsOrderDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AlternateDeliveryAddressId");

                    b.HasIndex("DeliveryAddressId");

                    b.HasIndex("MandatoryVehicleReferenceId");

                    b.HasIndex("OrderContactId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("AutomotivePartsOrdering.Service.Domain.OrderContact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrderContacts");
                });

            modelBuilder.Entity("AutomotivePartsOrdering.Service.Domain.OrderLine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ListPriceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<Guid>("OrderPriceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PartsOrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PartsOrderLineStatus")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("UnitOfMeasureId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UnitOfSale")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("value")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("Id");

                    b.HasIndex("ListPriceId");

                    b.HasIndex("OrderId");

                    b.HasIndex("OrderPriceId");

                    b.HasIndex("PartId");

                    b.HasIndex("UnitOfMeasureId");

                    b.ToTable("PartsOrderLines");
                });

            modelBuilder.Entity("AutomotivePartsOrdering.Service.Domain.Part", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BrandCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Part");
                });

            modelBuilder.Entity("AutomotivePartsOrdering.Service.Domain.PartDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AlternativePartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BrandCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlternativePartId");

                    b.ToTable("PartDetail");
                });

            modelBuilder.Entity("AutomotivePartsOrdering.Service.Domain.Price", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("GrossValue")
                        .HasColumnType("decimal(6,2)");

                    b.Property<decimal>("NetValue")
                        .HasColumnType("decimal(6,2)");

                    b.Property<decimal>("TaxRate")
                        .HasColumnType("decimal(3,2)");

                    b.Property<decimal>("TaxValue")
                        .HasColumnType("decimal(6,2)");

                    b.Property<string>("currencyCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("AutomotivePartsOrdering.Service.Domain.UnitOfMeasure", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Unit")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("Id");

                    b.ToTable("UnitOfMeasures");
                });

            modelBuilder.Entity("AutomotivePartsOrdering.Service.Domain.VehicleReference", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VehicleReferences");
                });

            modelBuilder.Entity("AutomotivePartsOrdering.Service.Domain.AlternativePart", b =>
                {
                    b.HasOne("AutomotivePartsOrdering.Service.Domain.Part", null)
                        .WithMany("AlternativeParts")
                        .HasForeignKey("PartId");
                });

            modelBuilder.Entity("AutomotivePartsOrdering.Service.Domain.Order", b =>
                {
                    b.HasOne("AutomotivePartsOrdering.Service.Domain.Address", "AlternateDeliveryAddress")
                        .WithMany()
                        .HasForeignKey("AlternateDeliveryAddressId");

                    b.HasOne("AutomotivePartsOrdering.Service.Domain.Address", "DeliveryAddress")
                        .WithMany()
                        .HasForeignKey("DeliveryAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutomotivePartsOrdering.Service.Domain.VehicleReference", "MandatoryVehicleReference")
                        .WithMany()
                        .HasForeignKey("MandatoryVehicleReferenceId");

                    b.HasOne("AutomotivePartsOrdering.Service.Domain.OrderContact", "OrderContact")
                        .WithMany()
                        .HasForeignKey("OrderContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AlternateDeliveryAddress");

                    b.Navigation("DeliveryAddress");

                    b.Navigation("MandatoryVehicleReference");

                    b.Navigation("OrderContact");
                });

            modelBuilder.Entity("AutomotivePartsOrdering.Service.Domain.OrderLine", b =>
                {
                    b.HasOne("AutomotivePartsOrdering.Service.Domain.Price", "ListPrice")
                        .WithMany()
                        .HasForeignKey("ListPriceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutomotivePartsOrdering.Service.Domain.Order", null)
                        .WithMany("Parts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutomotivePartsOrdering.Service.Domain.Price", "OrderPrice")
                        .WithMany()
                        .HasForeignKey("OrderPriceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutomotivePartsOrdering.Service.Domain.Part", "Part")
                        .WithMany()
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutomotivePartsOrdering.Service.Domain.UnitOfMeasure", "UnitOfMeasure")
                        .WithMany()
                        .HasForeignKey("UnitOfMeasureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ListPrice");

                    b.Navigation("OrderPrice");

                    b.Navigation("Part");

                    b.Navigation("UnitOfMeasure");
                });

            modelBuilder.Entity("AutomotivePartsOrdering.Service.Domain.PartDetail", b =>
                {
                    b.HasOne("AutomotivePartsOrdering.Service.Domain.AlternativePart", null)
                        .WithMany("Parts")
                        .HasForeignKey("AlternativePartId");
                });

            modelBuilder.Entity("AutomotivePartsOrdering.Service.Domain.AlternativePart", b =>
                {
                    b.Navigation("Parts");
                });

            modelBuilder.Entity("AutomotivePartsOrdering.Service.Domain.Order", b =>
                {
                    b.Navigation("Parts");
                });

            modelBuilder.Entity("AutomotivePartsOrdering.Service.Domain.Part", b =>
                {
                    b.Navigation("AlternativeParts");
                });
#pragma warning restore 612, 618
        }
    }
}