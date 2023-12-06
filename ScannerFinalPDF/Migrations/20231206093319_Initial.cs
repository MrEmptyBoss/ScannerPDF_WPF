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
                    Name = table.Column<string>(nullable: true),
                    MaketId = table.Column<int>(nullable: true),
                    RSId = table.Column<int>(nullable: true)
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
                    Email = table.Column<string>(nullable: true),
                    MaketId = table.Column<int>(nullable: true),
                    RSId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RS_RS_RSId",
                        column: x => x.RSId,
                        principalTable: "RS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sroki",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Coldn = table.Column<int>(nullable: false),
                    MaketId = table.Column<int>(nullable: true),
                    RSId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sroki", x => x.id);
                    table.ForeignKey(
                        name: "FK_Sroki_RS_RSId",
                        column: x => x.RSId,
                        principalTable: "RS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    PositionId = table.Column<int>(nullable: true),
                    Date_create = table.Column<DateTime>(nullable: false),
                    Date_rozh = table.Column<DateTime>(nullable: false),
                    MaketId = table.Column<int>(nullable: true),
                    RSId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_RS_RSId",
                        column: x => x.RSId,
                        principalTable: "RS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zayvka",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RsId = table.Column<int>(nullable: true),
                    Usersid = table.Column<int>(nullable: true),
                    NameRequest = table.Column<string>(nullable: true),
                    Srokiid = table.Column<int>(nullable: true),
                    NShop = table.Column<int>(nullable: false),
                    DatePriem = table.Column<DateTime>(nullable: false),
                    DateDostav = table.Column<DateTime>(nullable: true),
                    DateClose = table.Column<DateTime>(nullable: true),
                    DatePlanov = table.Column<DateTime>(nullable: false),
                    NumberTruck = table.Column<int>(nullable: false),
                    Sotrid = table.Column<int>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Commentz = table.Column<string>(nullable: true),
                    MaketId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zayvka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zayvka_RS_RsId",
                        column: x => x.RsId,
                        principalTable: "RS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zayvka_Users_Sotrid",
                        column: x => x.Sotrid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zayvka_Sroki_Srokiid",
                        column: x => x.Srokiid,
                        principalTable: "Sroki",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zayvka_Users_Usersid",
                        column: x => x.Usersid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                    IdZayvkiId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maket_Zayvka_IdZayvkiId",
                        column: x => x.IdZayvkiId,
                        principalTable: "Zayvka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maket_IdZayvkiId",
                table: "Maket",
                column: "IdZayvkiId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_MaketId",
                table: "Positions",
                column: "MaketId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_RSId",
                table: "Positions",
                column: "RSId");

            migrationBuilder.CreateIndex(
                name: "IX_RS_MaketId",
                table: "RS",
                column: "MaketId");

            migrationBuilder.CreateIndex(
                name: "IX_RS_RSId",
                table: "RS",
                column: "RSId");

            migrationBuilder.CreateIndex(
                name: "IX_Sroki_MaketId",
                table: "Sroki",
                column: "MaketId");

            migrationBuilder.CreateIndex(
                name: "IX_Sroki_RSId",
                table: "Sroki",
                column: "RSId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MaketId",
                table: "Users",
                column: "MaketId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PositionId",
                table: "Users",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RSId",
                table: "Users",
                column: "RSId");

            migrationBuilder.CreateIndex(
                name: "IX_Zayvka_MaketId",
                table: "Zayvka",
                column: "MaketId");

            migrationBuilder.CreateIndex(
                name: "IX_Zayvka_RsId",
                table: "Zayvka",
                column: "RsId");

            migrationBuilder.CreateIndex(
                name: "IX_Zayvka_Sotrid",
                table: "Zayvka",
                column: "Sotrid");

            migrationBuilder.CreateIndex(
                name: "IX_Zayvka_Srokiid",
                table: "Zayvka",
                column: "Srokiid");

            migrationBuilder.CreateIndex(
                name: "IX_Zayvka_Usersid",
                table: "Zayvka",
                column: "Usersid");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Maket_MaketId",
                table: "Positions",
                column: "MaketId",
                principalTable: "Maket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_RS_RSId",
                table: "Positions",
                column: "RSId",
                principalTable: "RS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RS_Maket_MaketId",
                table: "RS",
                column: "MaketId",
                principalTable: "Maket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sroki_Maket_MaketId",
                table: "Sroki",
                column: "MaketId",
                principalTable: "Maket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Maket_MaketId",
                table: "Users",
                column: "MaketId",
                principalTable: "Maket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Zayvka_Maket_MaketId",
                table: "Zayvka",
                column: "MaketId",
                principalTable: "Maket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maket_Zayvka_IdZayvkiId",
                table: "Maket");

            migrationBuilder.DropTable(
                name: "Zayvka");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Sroki");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "RS");

            migrationBuilder.DropTable(
                name: "Maket");
        }
    }
}
