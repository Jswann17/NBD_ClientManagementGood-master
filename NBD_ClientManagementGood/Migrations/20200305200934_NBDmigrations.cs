using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBD_ClientManagementGood.Migrations
{
    public partial class NBDmigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CMO");

            migrationBuilder.CreateTable(
                name: "BidLBs",
                schema: "CMO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BidID = table.Column<int>(nullable: false),
                    LabourUnitID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidLBs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "CMO",
                columns: table => new
                {
                    CountryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "InvBids",
                schema: "CMO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvBids", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LabourDepartments",
                schema: "CMO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentDescription = table.Column<string>(maxLength: 250, nullable: false),
                    DepartmentTotalHours = table.Column<int>(nullable: false),
                    LabourUnitID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabourDepartments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "CMO",
                columns: table => new
                {
                    CityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    State = table.Column<string>(maxLength: 30, nullable: false),
                    CountryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityID);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryID",
                        column: x => x.CountryID,
                        principalSchema: "CMO",
                        principalTable: "Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LabourUnits",
                schema: "CMO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LabourUnitDescription = table.Column<string>(maxLength: 250, nullable: false),
                    LabourUnitHours = table.Column<int>(nullable: false),
                    LabourUnitCost = table.Column<int>(nullable: false),
                    LabourUnitEstCost = table.Column<int>(nullable: false),
                    LabourUnitTaskName = table.Column<string>(maxLength: 100, nullable: false),
                    LabourUnitTask = table.Column<string>(maxLength: 1000, nullable: false),
                    LabourDepartmentID = table.Column<int>(nullable: false),
                    HeadStaffID = table.Column<int>(nullable: false),
                    BidLBID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabourUnits", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LabourUnits_BidLBs_BidLBID",
                        column: x => x.BidLBID,
                        principalSchema: "CMO",
                        principalTable: "BidLBs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabourUnits_LabourDepartments_LabourDepartmentID",
                        column: x => x.LabourDepartmentID,
                        principalSchema: "CMO",
                        principalTable: "LabourDepartments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "CMO",
                columns: table => new
                {
                    ClientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FormalName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Address = table.Column<string>(maxLength: 255, nullable: false),
                    eMail = table.Column<string>(maxLength: 255, nullable: false),
                    PostalCode = table.Column<string>(maxLength: 255, nullable: false),
                    Phone = table.Column<long>(nullable: false),
                    CityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientID);
                    table.ForeignKey(
                        name: "FK_Clients_Cities_CityID",
                        column: x => x.CityID,
                        principalSchema: "CMO",
                        principalTable: "Cities",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HeadStaff",
                schema: "CMO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StaffName = table.Column<string>(maxLength: 50, nullable: false),
                    StaffPhone = table.Column<long>(nullable: false),
                    LabourUnitID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadStaff", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HeadStaff_LabourUnits_LabourUnitID",
                        column: x => x.LabourUnitID,
                        principalSchema: "CMO",
                        principalTable: "LabourUnits",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                schema: "CMO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    ClientID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Projects_Clients_ClientID",
                        column: x => x.ClientID,
                        principalSchema: "CMO",
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                schema: "CMO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlueprintCode = table.Column<string>(maxLength: 12, nullable: false),
                    EstStart = table.Column<DateTime>(nullable: false),
                    EstEnd = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    ProjectID = table.Column<int>(nullable: false),
                    BidLBID = table.Column<int>(nullable: true),
                    InvBidID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bids_BidLBs_BidLBID",
                        column: x => x.BidLBID,
                        principalSchema: "CMO",
                        principalTable: "BidLBs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bids_InvBids_InvBidID",
                        column: x => x.InvBidID,
                        principalSchema: "CMO",
                        principalTable: "InvBids",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bids_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalSchema: "CMO",
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productions",
                schema: "CMO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    BidID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Productions_Bids_BidID",
                        column: x => x.BidID,
                        principalSchema: "CMO",
                        principalTable: "Bids",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bids_BidLBID",
                schema: "CMO",
                table: "Bids",
                column: "BidLBID");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_InvBidID",
                schema: "CMO",
                table: "Bids",
                column: "InvBidID");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_ProjectID",
                schema: "CMO",
                table: "Bids",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryID",
                schema: "CMO",
                table: "Cities",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CityID",
                schema: "CMO",
                table: "Clients",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Phone",
                schema: "CMO",
                table: "Clients",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_eMail",
                schema: "CMO",
                table: "Clients",
                column: "eMail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HeadStaff_LabourUnitID",
                schema: "CMO",
                table: "HeadStaff",
                column: "LabourUnitID");

            migrationBuilder.CreateIndex(
                name: "IX_LabourUnits_BidLBID",
                schema: "CMO",
                table: "LabourUnits",
                column: "BidLBID");

            migrationBuilder.CreateIndex(
                name: "IX_LabourUnits_LabourDepartmentID",
                schema: "CMO",
                table: "LabourUnits",
                column: "LabourDepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Productions_BidID",
                schema: "CMO",
                table: "Productions",
                column: "BidID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientID",
                schema: "CMO",
                table: "Projects",
                column: "ClientID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeadStaff",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "Productions",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "LabourUnits",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "Bids",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "LabourDepartments",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "BidLBs",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "InvBids",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "Projects",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "Clients",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "CMO");
        }
    }
}
