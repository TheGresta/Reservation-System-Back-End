using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RezervationSystem.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Descripton = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReserRents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    ReserId = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReserRents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReserRents_Resers_ReserId",
                        column: x => x.ReserId,
                        principalTable: "Resers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Resers",
                columns: new[] { "Id", "Address", "CreateDate", "DeletedDate", "Descripton", "Name", "Price", "UpdateDate", "UserId" },
                values: new object[,]
                {
                    { 1, "Address line", null, null, "description", "Halısaha", 1m, null, 1 },
                    { 2, "Address line", null, null, "description", "Halısaha 2", 1m, null, 1 },
                    { 3, "Address line", null, null, "description", "Halısaha 3", 1m, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "ReserRents",
                columns: new[] { "Id", "CreateDate", "CustomerId", "DeletedDate", "EndDate", "ReserId", "StartDate", "UpdateDate", "UserId" },
                values: new object[,]
                {
                    { 1, null, 0, null, new DateTime(2022, 9, 2, 17, 1, 18, 321, DateTimeKind.Local).AddTicks(5968), 1, new DateTime(2022, 8, 30, 17, 1, 18, 321, DateTimeKind.Local).AddTicks(5957), null, null },
                    { 2, null, 0, null, new DateTime(2022, 9, 2, 17, 1, 18, 321, DateTimeKind.Local).AddTicks(5972), 2, new DateTime(2022, 8, 30, 17, 1, 18, 321, DateTimeKind.Local).AddTicks(5971), null, null },
                    { 3, null, 0, null, new DateTime(2022, 9, 2, 17, 1, 18, 321, DateTimeKind.Local).AddTicks(5973), 3, new DateTime(2022, 8, 30, 17, 1, 18, 321, DateTimeKind.Local).AddTicks(5972), null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReserRents_ReserId",
                table: "ReserRents",
                column: "ReserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReserRents");

            migrationBuilder.DropTable(
                name: "Resers");
        }
    }
}
