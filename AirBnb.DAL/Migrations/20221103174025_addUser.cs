using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirBnb.DAL.Migrations
{
    public partial class addUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b74ddd14-6340-4840-95c2-db12554843e5", 0, new DateTime(2022, 11, 3, 17, 40, 24, 797, DateTimeKind.Utc).AddTicks(2118), "7a58b0eb-c499-43d9-b714-267650c020b2", "user@gmail.com", true, "Ramzy", "Bassem", false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAEAACcQAAAAEPGb7C7nJDXwPXDyg0aiYjkoZbK8fzEYIp89PIL0NWeW4VC9OwrwvzfS2P+KPZltlA==", "1234567890", false, null, "3cca7ede-d5c7-41c5-949c-cadfbd5c8b9a", false, "user@gmail.com" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Balance", "Rating" },
                values: new object[] { "b74ddd14-6340-4840-95c2-db12554843e5", 0.0, 0.0 });
            migrationBuilder.InsertData(
              table: "AspNetUserClaims",
              columns: new[] { "UserId", "ClaimType", "ClaimValue" },
              values: new object[] { "b74ddd14-6340-4840-95c2-db12554843e5", "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "b74ddd14-6340-4840-95c2-db12554843e5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5");
        }
    }
}
