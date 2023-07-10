using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketingSystem.Entities.Migrations
{
    public partial class RegisterRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegisterRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegisterRequest_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1456c79b-7080-4586-8467-900a3cb033fe"),
                column: "ConcurrencyStamp",
                value: "f96aced5-7f37-4ee3-a1c3-b0e155bd35cb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("62448744-4356-44dc-a005-0bfb6ba9e8b2"),
                column: "ConcurrencyStamp",
                value: "05fd7f57-dded-449c-b8b9-5f83b367fe5d");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterRequest_UserId",
                table: "RegisterRequest",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisterRequest");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1456c79b-7080-4586-8467-900a3cb033fe"),
                column: "ConcurrencyStamp",
                value: "43121784-b4f3-4b99-bf3b-bdefd465a6bf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("62448744-4356-44dc-a005-0bfb6ba9e8b2"),
                column: "ConcurrencyStamp",
                value: "9de3f684-103c-4dba-bb6f-2831623a516d");
        }
    }
}
