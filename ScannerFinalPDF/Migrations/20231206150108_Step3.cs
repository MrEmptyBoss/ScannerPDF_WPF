using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScannerFinalPDF.Migrations
{
    public partial class Step3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maket_Positions_PositionUserId",
                table: "Maket");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Maket_MaketId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_RS_Maket_MaketId",
                table: "RS");

            migrationBuilder.DropForeignKey(
                name: "FK_Sroki_Maket_MaketId",
                table: "Sroki");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Maket_MaketId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Zayvka_Maket_MaketId",
                table: "Zayvka");

            migrationBuilder.DropIndex(
                name: "IX_Zayvka_MaketId",
                table: "Zayvka");

            migrationBuilder.DropIndex(
                name: "IX_Users_MaketId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Sroki_MaketId",
                table: "Sroki");

            migrationBuilder.DropIndex(
                name: "IX_RS_MaketId",
                table: "RS");

            migrationBuilder.DropIndex(
                name: "IX_Positions_MaketId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Maket_PositionUserId",
                table: "Maket");

            migrationBuilder.DropColumn(
                name: "MaketId",
                table: "Zayvka");

            migrationBuilder.DropColumn(
                name: "MaketId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MaketId",
                table: "Sroki");

            migrationBuilder.DropColumn(
                name: "MaketId",
                table: "RS");

            migrationBuilder.DropColumn(
                name: "MaketId",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "DateRozhUser",
                table: "Maket");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Maket");

            migrationBuilder.DropColumn(
                name: "FioUser",
                table: "Maket");

            migrationBuilder.DropColumn(
                name: "LoginUser",
                table: "Maket");

            migrationBuilder.DropColumn(
                name: "NameRS",
                table: "Maket");

            migrationBuilder.DropColumn(
                name: "PassUser",
                table: "Maket");

            migrationBuilder.DropColumn(
                name: "PosName",
                table: "Maket");

            migrationBuilder.DropColumn(
                name: "PositionUserId",
                table: "Maket");

            migrationBuilder.DropColumn(
                name: "SrokiColdn",
                table: "Maket");

            migrationBuilder.DropColumn(
                name: "SrokiName",
                table: "Maket");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaketId",
                table: "Zayvka",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaketId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaketId",
                table: "Sroki",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaketId",
                table: "RS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaketId",
                table: "Positions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRozhUser",
                table: "Maket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Maket",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FioUser",
                table: "Maket",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoginUser",
                table: "Maket",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NameRS",
                table: "Maket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PassUser",
                table: "Maket",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PosName",
                table: "Maket",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionUserId",
                table: "Maket",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SrokiColdn",
                table: "Maket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SrokiName",
                table: "Maket",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zayvka_MaketId",
                table: "Zayvka",
                column: "MaketId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MaketId",
                table: "Users",
                column: "MaketId");

            migrationBuilder.CreateIndex(
                name: "IX_Sroki_MaketId",
                table: "Sroki",
                column: "MaketId");

            migrationBuilder.CreateIndex(
                name: "IX_RS_MaketId",
                table: "RS",
                column: "MaketId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_MaketId",
                table: "Positions",
                column: "MaketId");

            migrationBuilder.CreateIndex(
                name: "IX_Maket_PositionUserId",
                table: "Maket",
                column: "PositionUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Maket_Positions_PositionUserId",
                table: "Maket",
                column: "PositionUserId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Maket_MaketId",
                table: "Positions",
                column: "MaketId",
                principalTable: "Maket",
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
    }
}
