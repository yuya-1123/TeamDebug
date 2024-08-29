using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamD_Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    AssetsNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Maker = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Os = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Memory = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Capacity = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Graphics = table.Column<bool>(type: "bit", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Break = table.Column<bool>(type: "bit", nullable: false),
                    StartleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LimitleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InventoryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.AssetsNo);
                });

            migrationBuilder.CreateTable(
                name: "Rental",
                columns: table => new
                {
                    AssetsNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Maker = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    OS = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Vacant = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LoanDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rental", x => x.AssetsNo);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    EmployeeNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Namekana = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    department = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TelNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MailAdress = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AccountLevel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RetireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.EmployeeNo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Device");

            migrationBuilder.DropTable(
                name: "Rental");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
