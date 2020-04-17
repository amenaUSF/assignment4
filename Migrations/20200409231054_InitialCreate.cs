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
                    veh_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehicleDescription = table.Column<string>(nullable: false),
                    VehicleId = table.Column<int>(nullable: false)
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
                    Make = table.Column<string>(nullable: false)
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
                    Make = table.Column<string>(nullable: false),
                    model_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Model = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_models", x => x.model_id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle_Makes",
                columns: table => new
                {
                    make_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Make = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle_Makes", x => x.make_id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle_Models",
                columns: table => new
                {
                    model_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Model = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle_Models", x => x.model_id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle_Years",
                columns: table => new
                {
                    year_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModelYear = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle_Years", x => x.year_id);
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

            migrationBuilder.CreateTable(
    name: "UserReviews",
    columns: table => new
    {
        Id = table.Column<int>(nullable: false)
            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        name = table.Column<string>(nullable: false),
        email = table.Column<string>(nullable: false),
        comments = table.Column<string>(nullable: false)

    },
    constraints: table =>
    {
        table.PrimaryKey("PK_UserReviews", x => x.Id);
    });


            migrationBuilder.CreateTable(
                name: "Vehicle_Safetyratings",
                columns: table => new
                {
                    veh_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<int>(nullable: false),
                    VehicleDescription = table.Column<string>(nullable: false),
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
                    year_id = table.Column<int>(nullable: false),
                    make_id = table.Column<int>(nullable: false),
                    model_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle_Safetyratings", x => x.veh_id);
                    table.ForeignKey(
                        name: "FK_Vehicle_Safetyratings_Vehicle_Makes_make_id",
                        column: x => x.make_id,
                        principalTable: "Vehicle_Makes",
                        principalColumn: "make_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_Safetyratings_Vehicle_Models_model_id",
                        column: x => x.model_id,
                        principalTable: "Vehicle_Models",
                        principalColumn: "model_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_Safetyratings_Vehicle_Years_year_id",
                        column: x => x.year_id,
                        principalTable: "Vehicle_Years",
                        principalColumn: "year_id",
                        onDelete: ReferentialAction.Cascade);
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
                    VehicleDescription = table.Column<string>(nullable: true),
                    year_id = table.Column<int>(nullable: false),
                    make_id = table.Column<int>(nullable: false),
                    model_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_safety", x => x.veh_id);
                    table.ForeignKey(
                        name: "FK_safety_makes_make_id",
                        column: x => x.make_id,
                        principalTable: "makes",
                        principalColumn: "make_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_safety_models_model_id",
                        column: x => x.model_id,
                        principalTable: "models",
                        principalColumn: "model_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_safety_years_year_id",
                        column: x => x.year_id,
                        principalTable: "years",
                        principalColumn: "year_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_safety_make_id",
                table: "safety",
                column: "make_id");

            migrationBuilder.CreateIndex(
                name: "IX_safety_model_id",
                table: "safety",
                column: "model_id");

            migrationBuilder.CreateIndex(
                name: "IX_safety_year_id",
                table: "safety",
                column: "year_id");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Safetyratings_make_id",
                table: "Vehicle_Safetyratings",
                column: "make_id");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Safetyratings_model_id",
                table: "Vehicle_Safetyratings",
                column: "model_id");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Safetyratings_year_id",
                table: "Vehicle_Safetyratings",
                column: "year_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ids");

            migrationBuilder.DropTable(
                name: "safety");

            migrationBuilder.DropTable(
                name: "Vehicle_Safetyratings");

            migrationBuilder.DropTable(
                name: "makes");

            migrationBuilder.DropTable(
                name: "models");

            migrationBuilder.DropTable(
                name: "years");

            migrationBuilder.DropTable(
                name: "Vehicle_Makes");

            migrationBuilder.DropTable(
                name: "Vehicle_Models");

            migrationBuilder.DropTable(
                name: "Vehicle_Years");
        }
    }
}
