using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ranes.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Files : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgEight",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "ImgFive",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "ImgFour",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "ImgNine",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "ImgOne",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "ImgPrimary",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "ImgSeven",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "ImgSix",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "ImgTen",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "ImgThree",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "ImgTwo",
                table: "Buildings");

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ContentType = table.Column<string>(type: "text", nullable: false),
                    Data = table.Column<byte[]>(type: "bytea", nullable: false),
                    BuildingId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.AddColumn<string>(
                name: "ImgEight",
                table: "Buildings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImgFive",
                table: "Buildings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgFour",
                table: "Buildings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgNine",
                table: "Buildings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgOne",
                table: "Buildings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgPrimary",
                table: "Buildings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImgSeven",
                table: "Buildings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgSix",
                table: "Buildings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgTen",
                table: "Buildings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgThree",
                table: "Buildings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgTwo",
                table: "Buildings",
                type: "text",
                nullable: true);
        }
    }
}
