using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketingSystem.Entities.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0378ef66-3332-4860-ad38-773ed8c0594a"), "b832276f-ec40-4348-95c3-a49808529b84", "Мaintenance", "МAINTENANCE" },
                    { new Guid("6c508509-7dd9-44c3-9597-8c14c65e661b"), "b6d65614-7c33-46b0-aecc-ebe78d0f9d7d", "Administrator", "ADMINISTRATOR" },
                    { new Guid("7062d4a3-203f-4375-aaef-4918dcfcef04"), "bdea90a1-4ea6-4db7-acc6-c5dd6a18bb07", "User", "NAME" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1456c79b-7080-4586-8467-900a3cb033fe"), 0, "69c70b23-b9d7-4a99-8ec9-4deb4e60a30c", "user2@gmail.com", false, "Georgi", "Georgiev", false, null, "USER2@GMAIL.COM", "USER2", null, null, false, null, false, "User2" },
                    { new Guid("62448744-4356-44dc-a005-0bfb6ba9e8b2"), 0, "0d2e0f5c-4ef8-46b9-951d-34c1cc129034", "user@mail.com", false, "Ivan", "Ivanov", false, null, "USER@MAIL.COM", "USER", null, null, false, null, false, "User" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0c1b871b-4ed5-4299-aec4-d59054b07c54"), "Luchezar's project for SoftUni.", "LAAuto" },
                    { new Guid("83da1e75-3b7d-4a37-a33d-ba8cf149acb8"), "Shows weather analysis.", "Weather forecasting system" },
                    { new Guid("8c97398e-09d8-4823-a82d-343619758e81"), null, "Instagram" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Description", "Files", "ProjectId", "ReleaseDate", "SenderId", "State", "Title", "Type" },
                values: new object[] { new Guid("543ff3e3-5ac4-45ca-8cd4-f8d942548c7e"), "I need help with finding my login activity.", null, new Guid("8c97398e-09d8-4823-a82d-343619758e81"), new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1456c79b-7080-4586-8467-900a3cb033fe"), 1, "Help for account activity.", 2 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Description", "Files", "ProjectId", "ReleaseDate", "SenderId", "State", "Title", "Type" },
                values: new object[] { new Guid("ad90a67e-02be-4f9a-9fa8-74d5abcc2b4b"), "The app doesn't recognize my identity, when I try to log in.", null, new Guid("8c97398e-09d8-4823-a82d-343619758e81"), new DateTime(2022, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("62448744-4356-44dc-a005-0bfb6ba9e8b2"), 0, "Login issue.", 0 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Description", "Files", "ProjectId", "ReleaseDate", "SenderId", "State", "Title", "Type" },
                values: new object[] { new Guid("d385bf53-6e41-4ea3-8c7f-729c6893466f"), "It would be nice, when deleting any kind of data, a window to pop up for reassurance of my action.", null, new Guid("0c1b871b-4ed5-4299-aec4-d59054b07c54"), new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1456c79b-7080-4586-8467-900a3cb033fe"), 1, "A user-friendly request.", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0378ef66-3332-4860-ad38-773ed8c0594a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6c508509-7dd9-44c3-9597-8c14c65e661b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7062d4a3-203f-4375-aaef-4918dcfcef04"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("83da1e75-3b7d-4a37-a33d-ba8cf149acb8"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("543ff3e3-5ac4-45ca-8cd4-f8d942548c7e"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("ad90a67e-02be-4f9a-9fa8-74d5abcc2b4b"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("d385bf53-6e41-4ea3-8c7f-729c6893466f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1456c79b-7080-4586-8467-900a3cb033fe"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("62448744-4356-44dc-a005-0bfb6ba9e8b2"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("0c1b871b-4ed5-4299-aec4-d59054b07c54"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("8c97398e-09d8-4823-a82d-343619758e81"));
        }
    }
}
