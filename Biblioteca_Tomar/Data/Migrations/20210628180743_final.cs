using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca_Tomar.Data.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "c4694a13-45af-484a-b525-a79e9bc180f3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "u",
                column: "ConcurrencyStamp",
                value: "7044d260-f842-46d0-93c0-ec735dfa3ca9");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "fc8bcf3f-356e-4b56-9eb8-ff3e92ef56fd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "u",
                column: "ConcurrencyStamp",
                value: "d5461a67-f1df-459f-ba17-218a0d2d8edb");
        }
    }
}
