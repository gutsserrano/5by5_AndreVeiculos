using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjAPICarro.Migrations
{
    public partial class operationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarOperations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarPlate = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OperationId = table.Column<int>(type: "int", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    CarPlate1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OperationId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarOperations_Car_CarPlate",
                        column: x => x.CarPlate,
                        principalTable: "Car",
                        principalColumn: "Plate");
                    table.ForeignKey(
                        name: "FK_CarOperations_Car_CarPlate1",
                        column: x => x.CarPlate1,
                        principalTable: "Car",
                        principalColumn: "Plate");
                    table.ForeignKey(
                        name: "FK_CarOperations_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarOperations_Operations_OperationId1",
                        column: x => x.OperationId1,
                        principalTable: "Operations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarOperations_CarPlate",
                table: "CarOperations",
                column: "CarPlate");

            migrationBuilder.CreateIndex(
                name: "IX_CarOperations_CarPlate1",
                table: "CarOperations",
                column: "CarPlate1");

            migrationBuilder.CreateIndex(
                name: "IX_CarOperations_OperationId",
                table: "CarOperations",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_CarOperations_OperationId1",
                table: "CarOperations",
                column: "OperationId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarOperations");

            migrationBuilder.DropTable(
                name: "Operations");
        }
    }
}
