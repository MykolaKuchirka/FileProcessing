using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FileProcessingDB.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advertisers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Amounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Min = table.Column<float>(type: "real", nullable: false),
                    Max = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Min = table.Column<int>(type: "int", nullable: false),
                    Max = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditScores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ltvs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Min = table.Column<float>(type: "real", nullable: false),
                    Max = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ltvs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<float>(type: "real", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalTerm = table.Column<int>(type: "int", nullable: false),
                    IDAdv = table.Column<int>(type: "int", nullable: false),
                    IDAm = table.Column<int>(type: "int", nullable: false),
                    IDCr = table.Column<int>(type: "int", nullable: false),
                    IDL = table.Column<int>(type: "int", nullable: false),
                    IDPr = table.Column<int>(type: "int", nullable: false),
                    IDSt = table.Column<int>(type: "int", nullable: false),
                    AdvertiserId = table.Column<int>(type: "int", nullable: true),
                    AmountId = table.Column<int>(type: "int", nullable: true),
                    CreditScoreId = table.Column<int>(type: "int", nullable: true),
                    LtvId = table.Column<int>(type: "int", nullable: true),
                    ProductTypeId = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseRates_Advertisers_AdvertiserId",
                        column: x => x.AdvertiserId,
                        principalTable: "Advertisers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseRates_Amounts_AmountId",
                        column: x => x.AmountId,
                        principalTable: "Amounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseRates_CreditScores_CreditScoreId",
                        column: x => x.CreditScoreId,
                        principalTable: "CreditScores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseRates_ltvs_LtvId",
                        column: x => x.LtvId,
                        principalTable: "ltvs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseRates_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseRates_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseRates_AdvertiserId",
                table: "BaseRates",
                column: "AdvertiserId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseRates_AmountId",
                table: "BaseRates",
                column: "AmountId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseRates_CreditScoreId",
                table: "BaseRates",
                column: "CreditScoreId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseRates_LtvId",
                table: "BaseRates",
                column: "LtvId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseRates_ProductTypeId",
                table: "BaseRates",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseRates_StateId",
                table: "BaseRates",
                column: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseRates");

            migrationBuilder.DropTable(
                name: "Advertisers");

            migrationBuilder.DropTable(
                name: "Amounts");

            migrationBuilder.DropTable(
                name: "CreditScores");

            migrationBuilder.DropTable(
                name: "ltvs");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
