using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TrainTracker.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainStations",
                columns: table => new
                {
                    TrainStationId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Blue = table.Column<bool>(nullable: false),
                    Brown = table.Column<bool>(nullable: false),
                    DescStationName = table.Column<string>(nullable: true),
                    Direction = table.Column<string>(nullable: true),
                    Green = table.Column<bool>(nullable: false),
                    Latitude = table.Column<float>(nullable: false),
                    Longitude = table.Column<float>(nullable: false),
                    MapId = table.Column<string>(nullable: true),
                    Orange = table.Column<bool>(nullable: false),
                    Pink = table.Column<bool>(nullable: false),
                    Purple = table.Column<bool>(nullable: false),
                    PurpleExpress = table.Column<bool>(nullable: false),
                    Red = table.Column<bool>(nullable: false),
                    StationName = table.Column<string>(nullable: true),
                    StopId = table.Column<string>(nullable: true),
                    StopName = table.Column<string>(nullable: true),
                    Yellow = table.Column<bool>(nullable: false),
                    ada = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainStations", x => x.TrainStationId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainStations");
        }
    }
}
