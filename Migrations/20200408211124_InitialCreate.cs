using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace assignment4.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ids",
                columns: table => new
                {
                    VehicleDescription = table.Column<string>(nullable: true),
                    VehicleId = table.Column<int>(nullable: false),
                    veh_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ids", x => x.veh_id);
                });

            migrationBuilder.CreateTable(
                name: "makes",
                columns: table => new
                {
                    ModelYear = table.Column<int>(nullable: false),
                    make_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Make = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_makes", x => x.make_id);
                });

            migrationBuilder.CreateTable(
                name: "models",
                columns: table => new
                {
                    ModelYear = table.Column<int>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    model_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Model = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_models", x => x.model_id);
                });

            migrationBuilder.CreateTable(
                name: "safety",
                columns: table => new
                {
                    veh_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<int>(nullable: false),
                    OverallRating = table.Column<string>(nullable: true),
                    OverallFrontCrashRating = table.Column<string>(nullable: true),
                    FrontCrashDriversideRating = table.Column<string>(nullable: true),
                    FrontCrashPassengersideRating = table.Column<string>(nullable: true),
                    OverallSideCrashRating = table.Column<string>(nullable: true),
                    SideCrashDriversideRating = table.Column<string>(nullable: true),
                    SideCrashPassengersideRating = table.Column<string>(nullable: true),
                    RolloverRating = table.Column<string>(nullable: true),
                    RolloverPossibility = table.Column<string>(nullable: true),
                    SidePoleCrashRating = table.Column<string>(nullable: true),
                    ComplaintsCount = table.Column<string>(nullable: true),
                    RecallsCount = table.Column<string>(nullable: true),
                    ModelYear = table.Column<int>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    VehicleDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_safety", x => x.veh_id);
                });

            migrationBuilder.CreateTable(
                name: "years",
                columns: table => new
                {
                    year_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModelYear = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_years", x => x.year_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ids");

            migrationBuilder.DropTable(
                name: "makes");

            migrationBuilder.DropTable(
                name: "models");

            migrationBuilder.DropTable(
                name: "safety");

            migrationBuilder.DropTable(
                name: "years");
        }
    }
}
