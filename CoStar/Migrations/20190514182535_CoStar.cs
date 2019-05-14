using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoStar.Migrations
{
    public partial class CoStar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ca2a02c-31cb-4240-bcdb-7cfbc90acab3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5dced4f-2b99-4012-993d-babd57670625");

            migrationBuilder.DropColumn(
                name: "ApplicationUserImage",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b09986ac-4850-4242-8355-f623cc7fbf13", 0, "1386ef4d-b6d4-47d8-82d5-ef5212285ef1", "admin@admin.com", true, "Admin", "Admin", false, null, "admin@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEPR3oZK5PeUFArGFPxCvHjutv7otQA/jodlxisOtsUMgCmxXUpDDPYm8pz1wnFCjEA==", null, false, "66d29ece-79d7-4c18-831f-56ef3561b182", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "146267e3-dab0-46b9-9e76-3f90161825c1", 0, "20aac862-7d8d-4ee4-9252-9ef5536c58f1", "guest@admin.com", true, "Guest", "Guest", false, null, "guest@ADMIN.COM", "GUEST@ADMIN.COM", "AQAAAAEAACcQAAAAEDQd9B7RjYLdfMXqGP2iQ2zOiQqm2R/UQkMvCMYNRZyU4yppBhVkEUD/GJz35EKabw==", null, false, "e066c067-32b9-4d78-b82f-93937d970162", false, "guest@admin.com" });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "HelpfulLinkId",
                keyValue: 1,
                column: "UserId",
                value: "b09986ac-4850-4242-8355-f623cc7fbf13");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "HelpfulLinkId",
                keyValue: 2,
                column: "UserId",
                value: "b09986ac-4850-4242-8355-f623cc7fbf13");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "HelpfulLinkId",
                keyValue: 3,
                column: "UserId",
                value: "b09986ac-4850-4242-8355-f623cc7fbf13");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "146267e3-dab0-46b9-9e76-3f90161825c1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b09986ac-4850-4242-8355-f623cc7fbf13");

            migrationBuilder.AddColumn<byte[]>(
                name: "ApplicationUserImage",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ApplicationUserImage", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d5dced4f-2b99-4012-993d-babd57670625", 0, null, "303917d8-12c7-47f5-93f2-dcbcdea11e32", "admin@admin.com", true, "Admin", "Admin", false, null, "admin@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEKb/YtKzWa9Z2hvpm7j0HfItGXo4deK7HMCzp9QS/+Lk0/b+wHvh2YUy9tC1fKkfVQ==", null, false, "5e1e6bf5-bc33-4cc2-977f-683fafe372c5", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ApplicationUserImage", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9ca2a02c-31cb-4240-bcdb-7cfbc90acab3", 0, null, "290f04c6-3a28-4444-9c5a-3177fc755b72", "guest@admin.com", true, "Guest", "Guest", false, null, "guest@ADMIN.COM", "GUEST@ADMIN.COM", "AQAAAAEAACcQAAAAEAwJmbLHH+XXlVs/NJsjSj0crgYOjtOdySmSR9dlb7k5W4YuDorAQsBtBrCT0/eifQ==", null, false, "b2e71416-6e81-48da-9ba8-606dc5b158fc", false, "guest@admin.com" });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "HelpfulLinkId",
                keyValue: 1,
                column: "UserId",
                value: "d5dced4f-2b99-4012-993d-babd57670625");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "HelpfulLinkId",
                keyValue: 2,
                column: "UserId",
                value: "d5dced4f-2b99-4012-993d-babd57670625");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "HelpfulLinkId",
                keyValue: 3,
                column: "UserId",
                value: "d5dced4f-2b99-4012-993d-babd57670625");
        }
    }
}
