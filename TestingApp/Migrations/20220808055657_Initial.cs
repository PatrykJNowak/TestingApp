using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestingApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropColumn(
                name: "SellDate",
                table: "SellData");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "SellData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SellData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SurName",
                table: "SellData",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "SellData");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SellData");

            migrationBuilder.DropColumn(
                name: "SurName",
                table: "SellData");

            migrationBuilder.AddColumn<DateTime>(
                name: "SellDate",
                table: "SellData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirthInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellDataId = table.Column<int>(type: "int", nullable: true),
                    SureName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_SellData_SellDataId",
                        column: x => x.SellDataId,
                        principalTable: "SellData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellDataId = table.Column<int>(type: "int", nullable: true),
                    Win = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearOfProduction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_SellData_SellDataId",
                        column: x => x.SellDataId,
                        principalTable: "SellData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SellDataId",
                table: "Customers",
                column: "SellDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_SellDataId",
                table: "Vehicle",
                column: "SellDataId");
        }
    }
}
