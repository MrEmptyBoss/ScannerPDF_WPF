using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScannerFinalPDF.Migrations
{
    public partial class Step2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_RS_RSId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_RS_RS_RSId",
                table: "RS");

            migrationBuilder.DropForeignKey(
                name: "FK_Sroki_RS_RSId",
                table: "Sroki");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Positions_PositionId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_RS_RSId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RSId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Sroki_RSId",
                table: "Sroki");

            migrationBuilder.DropIndex(
                name: "IX_RS_RSId",
                table: "RS");

            migrationBuilder.DropIndex(
                name: "IX_Positions_RSId",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "RSId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RSId",
                table: "Sroki");

            migrationBuilder.DropColumn(
                name: "RSId",
                table: "RS");

            migrationBuilder.DropColumn(
                name: "RSId",
                table: "Positions");

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRozhUser",
                table: "Maket",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Maket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FioUser",
                table: "Maket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoginUser",
                table: "Maket",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NameRS",
                table: "Maket",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PassUser",
                table: "Maket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PosName",
                table: "Maket",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionUserId",
                table: "Maket",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SrokiColdn",
                table: "Maket",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SrokiName",
                table: "Maket",
                nullable: true);

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
                name: "FK_Users_Positions_PositionId",
                table: "Users",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maket_Positions_PositionUserId",
                table: "Maket");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Positions_PositionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Maket_PositionUserId",
                table: "Maket");

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

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "RSId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RSId",
                table: "Sroki",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RSId",
                table: "RS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RSId",
                table: "Positions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RSId",
                table: "Users",
                column: "RSId");

            migrationBuilder.CreateIndex(
                name: "IX_Sroki_RSId",
                table: "Sroki",
                column: "RSId");

            migrationBuilder.CreateIndex(
                name: "IX_RS_RSId",
                table: "RS",
                column: "RSId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_RSId",
                table: "Positions",
                column: "RSId");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_RS_RSId",
                table: "Positions",
                column: "RSId",
                principalTable: "RS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RS_RS_RSId",
                table: "RS",
                column: "RSId",
                principalTable: "RS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sroki_RS_RSId",
                table: "Sroki",
                column: "RSId",
                principalTable: "RS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Positions_PositionId",
                table: "Users",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_RS_RSId",
                table: "Users",
                column: "RSId",
                principalTable: "RS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
