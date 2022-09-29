using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMCS.Manager.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MinerTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Config = table.Column<string>(type: "text", nullable: false),
                    Miner = table.Column<string>(type: "text", nullable: false),
                    CryptoCoin = table.Column<string>(type: "text", nullable: false),
                    Algorithm = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastUpdateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinerTasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MiningStatus = table.Column<string>(type: "text", nullable: false),
                    CurrentMiner = table.Column<string>(type: "text", nullable: false),
                    CurrentHashrate = table.Column<decimal>(type: "numeric", nullable: false),
                    CurrentTemperature = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastUpdateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MinerTasks_Id",
                table: "MinerTasks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_Id",
                table: "Nodes",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MinerTasks");

            migrationBuilder.DropTable(
                name: "Nodes");
        }
    }
}
