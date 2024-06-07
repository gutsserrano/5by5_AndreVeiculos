using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjAPICarro.Migrations
{
    public partial class pixPaymentMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BankSlipId = table.Column<int>(type: "int", nullable: true),
                    PixId = table.Column<int>(type: "int", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_BankSlips_BankSlipId",
                        column: x => x.BankSlipId,
                        principalTable: "BankSlips",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payments_Card_CardNumber",
                        column: x => x.CardNumber,
                        principalTable: "Card",
                        principalColumn: "CardNumber");
                    table.ForeignKey(
                        name: "FK_Payments_Pixes_PixId",
                        column: x => x.PixId,
                        principalTable: "Pixes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BankSlipId",
                table: "Payments",
                column: "BankSlipId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CardNumber",
                table: "Payments",
                column: "CardNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PixId",
                table: "Payments",
                column: "PixId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");
        }
    }
}
