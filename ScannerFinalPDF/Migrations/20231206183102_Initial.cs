using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScannerFinalPDF.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sroki",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Coldn = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sroki", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(nullable: true),
                    Pass = table.Column<string>(nullable: true),
                    Fio = table.Column<string>(nullable: true),
                    PositionId = table.Column<int>(nullable: false),
                    Date_create = table.Column<DateTime>(nullable: false),
                    Date_rozh = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zayvka",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RsId = table.Column<int>(nullable: false),
                    NameRequest = table.Column<string>(nullable: true),
                    SrokiId = table.Column<int>(nullable: false),
                    NShop = table.Column<int>(nullable: false),
                    DatePriem = table.Column<DateTime>(nullable: false),
                    DateDostav = table.Column<DateTime>(nullable: true),
                    DateClose = table.Column<DateTime>(nullable: true),
                    DatePlanov = table.Column<DateTime>(nullable: false),
                    NumberTruck = table.Column<int>(nullable: true),
                    SotrId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Commentz = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zayvka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zayvka_RS_RsId",
                        column: x => x.RsId,
                        principalTable: "RS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zayvka_Users_SotrId",
                        column: x => x.SotrId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zayvka_Sroki_SrokiId",
                        column: x => x.SrokiId,
                        principalTable: "Sroki",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maket",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Length = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Colstr = table.Column<int>(nullable: false),
                    Colotp = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    Fill = table.Column<int>(nullable: false),
                    Kvadr = table.Column<double>(nullable: false),
                    ZayvkaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maket_Zayvka_ZayvkaId",
                        column: x => x.ZayvkaId,
                        principalTable: "Zayvka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maket_ZayvkaId",
                table: "Maket",
                column: "ZayvkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PositionId",
                table: "Users",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Zayvka_RsId",
                table: "Zayvka",
                column: "RsId");

            migrationBuilder.CreateIndex(
                name: "IX_Zayvka_SotrId",
                table: "Zayvka",
                column: "SotrId");

            migrationBuilder.CreateIndex(
                name: "IX_Zayvka_SrokiId",
                table: "Zayvka",
                column: "SrokiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maket");

            migrationBuilder.DropTable(
                name: "Zayvka");

            migrationBuilder.DropTable(
                name: "RS");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Sroki");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
