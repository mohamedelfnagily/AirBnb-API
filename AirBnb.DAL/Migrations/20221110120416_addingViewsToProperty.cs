using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirBnb.DAL.Migrations
{
    public partial class addingViewsToProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2022, 11, 10, 12, 4, 16, 314, DateTimeKind.Utc).AddTicks(1701), "15f90ae1-f476-41ae-9f2b-d30be8a83c07", "AQAAAAEAACcQAAAAEON01OiD5Waj1ijsodtO3nRQdDdMTv/CCow75oSyCjl1xXLSoLrLpGiEEiXbcSPRBw==", "6decda4e-a2b8-4f62-b9db-33a2c9490bdd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Views",
                table: "Properties");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2022, 11, 10, 10, 13, 33, 559, DateTimeKind.Utc).AddTicks(5773), "35596a8d-4606-46f7-b181-d2b0f2222de9", "AQAAAAEAACcQAAAAELgvi//87QjShN+1wLBEEACG+Gkb1YkEClKJ1lUiDkRml8DWRi/s+IE7S4B8byyv7Q==", "8f6bc9b7-c5cc-4737-b26a-84fcec14bb4b" });
        }
    }
}
