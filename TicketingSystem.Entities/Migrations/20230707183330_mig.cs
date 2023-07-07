using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketingSystem.Entities.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1456c79b-7080-4586-8467-900a3cb033fe"),
                column: "ConcurrencyStamp",
                value: "b1eba4cf-27e0-4fc7-ba5d-d964c00d3387");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("62448744-4356-44dc-a005-0bfb6ba9e8b2"),
                column: "ConcurrencyStamp",
                value: "96fb727c-a842-4642-8b6a-f431dcd2ea01");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1456c79b-7080-4586-8467-900a3cb033fe"),
                column: "ConcurrencyStamp",
                value: "26c3e852-7746-458b-aebb-59aaee789224");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("62448744-4356-44dc-a005-0bfb6ba9e8b2"),
                column: "ConcurrencyStamp",
                value: "cf5e9e7d-4faf-492d-897c-56e747d38746");
        }
    }
}
