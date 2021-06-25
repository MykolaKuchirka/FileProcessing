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
                    min = table.Column<float>(type: "real", nullable: false),
                    max = table.Column<float>(type: "real", nullable: false)
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
                    min = table.Column<int>(type: "int", nullable: false),
                    max = table.Column<int>(type: "int", nullable: false)
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
                    min = table.Column<float>(type: "real", nullable: false),
                    max = table.Column<float>(type: "real", nullable: false)
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
                    IDl = table.Column<int>(type: "int", nullable: false),
                    IDPr = table.Column<int>(type: "int", nullable: false),
                    IDSt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseRates_Advertisers_IDAdv",
                        column: x => x.IDAdv,
                        principalTable: "Advertisers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseRates_Amounts_IDAm",
                        column: x => x.IDAm,
                        principalTable: "Amounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseRates_CreditScores_IDCr",
                        column: x => x.IDCr,
                        principalTable: "CreditScores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseRates_ltvs_IDl",
                        column: x => x.IDl,
                        principalTable: "ltvs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseRates_ProductTypes_IDPr",
                        column: x => x.IDPr,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseRates_States_IDSt",
                        column: x => x.IDSt,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseRates_IDAdv",
                table: "BaseRates",
                column: "IDAdv");

            migrationBuilder.CreateIndex(
                name: "IX_BaseRates_IDAm",
                table: "BaseRates",
                column: "IDAm");

            migrationBuilder.CreateIndex(
                name: "IX_BaseRates_IDCr",
                table: "BaseRates",
                column: "IDCr");

            migrationBuilder.CreateIndex(
                name: "IX_BaseRates_IDl",
                table: "BaseRates",
                column: "IDl");

            migrationBuilder.CreateIndex(
                name: "IX_BaseRates_IDPr",
                table: "BaseRates",
                column: "IDPr");

            migrationBuilder.CreateIndex(
                name: "IX_BaseRates_IDSt",
                table: "BaseRates",
                column: "IDSt");
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
