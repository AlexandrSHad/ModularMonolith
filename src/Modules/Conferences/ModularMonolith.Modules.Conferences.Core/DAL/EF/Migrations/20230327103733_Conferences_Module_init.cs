using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModularMonolith.Modules.Conferences.Core.DAL.EF.Migrations
{
    /// <inheritdoc />
    public partial class Conferences_Module_init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "conferences");

            migrationBuilder.CreateTable(
                name: "Conferences",
                schema: "conferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    HostId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    From = table.Column<DateTime>(type: "TEXT", nullable: false),
                    To = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ParticipantsLimit = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hosts",
                schema: "conferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hosts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conferences",
                schema: "conferences");

            migrationBuilder.DropTable(
                name: "Hosts",
                schema: "conferences");
        }
    }
}
