﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NBD_ClientManagementGood.Data;

namespace NBD_ClientManagementGood.Migrations
{
    [DbContext(typeof(NBD_ClientManagementGoodContext))]
    [Migration("20200312193059_NBDMigration")]
    partial class NBDMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("CMO")
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NBD_ClientManagementGood.Models.Bid", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount");

                    b.Property<string>("BlueprintCode")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.Property<DateTime>("EstEnd");

                    b.Property<DateTime>("EstStart");

                    b.Property<string>("Location")
                        .IsRequired();

                    b.Property<int>("ProjectID");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.City", b =>
                {
                    b.Property<int>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryID");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("CityID");

                    b.HasIndex("CountryID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("CityID");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FormalName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50);

                    b.Property<long>("Phone");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("eMail")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("ClientID");

                    b.HasIndex("CityID");

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.HasIndex("eMail")
                        .IsUnique();

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.Country", b =>
                {
                    b.Property<int>("CountryID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("CountryID");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.DesignBudget", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrentHours");

                    b.Property<int>("EstHours");

                    b.Property<int>("HoursTotal");

                    b.Property<DateTime>("SubmissionDate");

                    b.Property<string>("Submitter")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("DesignBudget");
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.DesignDaily", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Hours");

                    b.Property<string>("Stage")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.Property<DateTime>("SubmissionDate");

                    b.Property<string>("Submitter")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Task")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("ID");

                    b.ToTable("DesignDaily");
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.InvBid", b =>
                {
                    b.Property<int>("BidID");

                    b.Property<int>("ItemID");

                    b.HasKey("BidID", "ItemID");

                    b.HasIndex("ItemID");

                    b.ToTable("InvBids");
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<DateTime>("DeliveryDate");

                    b.Property<DateTime>("InstallDate");

                    b.Property<double>("Net");

                    b.Property<int?>("ProductionWorkReportID");

                    b.Property<int>("Qty")
                        .HasMaxLength(12);

                    b.Property<string>("Size")
                        .HasMaxLength(100);

                    b.Property<double>("TotalCost");

                    b.Property<string>("Type")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.HasIndex("ProductionWorkReportID");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.Labour", b =>
                {
                    b.Property<int>("LabourUnitID");

                    b.Property<int>("ProductionID");

                    b.HasKey("LabourUnitID", "ProductionID");

                    b.HasIndex("ProductionID");

                    b.ToTable("Labours");
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.LabourDepartment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentDescription")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("LabourDepartments");
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.LabourReport", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cost");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<double>("Price");

                    b.Property<DateTime>("SubmissionDate");

                    b.Property<string>("Submitter")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("LabourReport");
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.LabourStaff", b =>
                {
                    b.Property<int>("LabourDeparmentID");

                    b.Property<int>("StaffID");

                    b.Property<int?>("LabourDepartmentID");

                    b.HasKey("LabourDeparmentID", "StaffID");

                    b.HasIndex("LabourDepartmentID");

                    b.HasIndex("StaffID");

                    b.ToTable("LabourStaffs");
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.LabourUnit", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cost");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int>("EstCost");

                    b.Property<int>("Hours");

                    b.Property<int?>("ProductionWorkReportID");

                    b.Property<string>("TaskDescription")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.HasIndex("ProductionWorkReportID");

                    b.ToTable("LabourUnits");
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.Material", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("List");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("OIS");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("ID");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.Plant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvgNet");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("IS_OB");

                    b.Property<DateTime>("LastOrdered");

                    b.Property<int>("List");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("OIS");

                    b.Property<int>("OOO");

                    b.Property<int>("OO_OB");

                    b.HasKey("ID");

                    b.ToTable("Plant");
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.Pottery", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Features")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("IS_OB");

                    b.Property<int>("List");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("OIS");

                    b.HasKey("ID");

                    b.ToTable("Pottery");
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.Product", b =>
                {
                    b.Property<int>("ItemID");

                    b.Property<int>("MaterialID");

                    b.Property<int>("PlantID");

                    b.Property<int>("PotteryID");

                    b.Property<int>("ToolID");

                    b.HasKey("ItemID", "MaterialID", "PlantID", "PotteryID", "ToolID");

                    b.HasIndex("MaterialID");

                    b.HasIndex("PlantID");

                    b.HasIndex("PotteryID");

                    b.HasIndex("ToolID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.Production", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BidID");

                    b.Property<int>("LabourDepartmentID");

                    b.Property<double>("ProBidPercent");

                    b.Property<double>("ProEstHourly");

                    b.Property<double>("ProEstMaterialCost");

                    b.Property<double>("ProEstTotalHours");

                    b.HasKey("ID");

                    b.HasIndex("BidID");

                    b.HasIndex("LabourDepartmentID");

                    b.ToTable("Productions");
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.ProductionItem", b =>
                {
                    b.Property<int>("ItemID");

                    b.Property<int>("ProductionID");

                    b.HasKey("ItemID", "ProductionID");

                    b.HasIndex("ProductionID");

                    b.ToTable("ProductionItems");
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.ProductionWorkReport", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("SubmissionDate");

                    b.Property<string>("Submitter")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("ProductionWorkReport");
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.Project", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientID");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("StartDate");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.Staff", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<long>("Phone");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.Tool", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("Tools");
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.Bid", b =>
                {
                    b.HasOne("NBD_ClientManagementGood.Models.Project", "Project")
                        .WithMany("Bids")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.City", b =>
                {
                    b.HasOne("NBD_ClientManagementGood.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.Client", b =>
                {
                    b.HasOne("NBD_ClientManagementGood.Models.City", "City")
                        .WithMany("Clients")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.InvBid", b =>
                {
                    b.HasOne("NBD_ClientManagementGood.Models.Bid", "Bid")
                        .WithMany("InvBids")
                        .HasForeignKey("BidID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NBD_ClientManagementGood.Models.Item", "Item")
                        .WithMany("InvBids")
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.Item", b =>
                {
                    b.HasOne("NBD_ClientManagementGood.Models.ProductionWorkReport")
                        .WithMany("Items")
                        .HasForeignKey("ProductionWorkReportID");
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.Labour", b =>
                {
                    b.HasOne("NBD_ClientManagementGood.Models.LabourUnit", "LabourUnit")
                        .WithMany("Labours")
                        .HasForeignKey("LabourUnitID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NBD_ClientManagementGood.Models.Production", "Production")
                        .WithMany("Labour")
                        .HasForeignKey("ProductionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.LabourStaff", b =>
                {
                    b.HasOne("NBD_ClientManagementGood.Models.LabourDepartment", "LabourDepartment")
                        .WithMany("LabourStaffs")
                        .HasForeignKey("LabourDepartmentID");

                    b.HasOne("NBD_ClientManagementGood.Models.Staff", "Staff")
                        .WithMany("LabourStaffs")
                        .HasForeignKey("StaffID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.LabourUnit", b =>
                {
                    b.HasOne("NBD_ClientManagementGood.Models.ProductionWorkReport")
                        .WithMany("LabourUnits")
                        .HasForeignKey("ProductionWorkReportID");
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.Product", b =>
                {
                    b.HasOne("NBD_ClientManagementGood.Models.Item", "Item")
                        .WithMany("Products")
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NBD_ClientManagementGood.Models.Material", "Material")
                        .WithMany("Products")
                        .HasForeignKey("MaterialID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NBD_ClientManagementGood.Models.Plant", "Plant")
                        .WithMany("Products")
                        .HasForeignKey("PlantID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NBD_ClientManagementGood.Models.Pottery", "Pottery")
                        .WithMany("Products")
                        .HasForeignKey("PotteryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NBD_ClientManagementGood.Models.Tool", "Tool")
                        .WithMany("Products")
                        .HasForeignKey("ToolID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.Production", b =>
                {
                    b.HasOne("NBD_ClientManagementGood.Models.Bid", "Bid")
                        .WithMany()
                        .HasForeignKey("BidID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NBD_ClientManagementGood.Models.LabourDepartment", "LabourDepartment")
                        .WithMany("Productions")
                        .HasForeignKey("LabourDepartmentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.ProductionItem", b =>
                {
                    b.HasOne("NBD_ClientManagementGood.Models.Item", "Item")
                        .WithMany("ProductionItems")
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NBD_ClientManagementGood.Models.Production", "Production")
                        .WithMany("ProductionItems")
                        .HasForeignKey("ProductionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NBD_ClientManagementGood.Models.Project", b =>
                {
                    b.HasOne("NBD_ClientManagementGood.Models.Client", "Client")
                        .WithMany("Projects")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
