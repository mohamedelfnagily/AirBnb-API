using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirBnb.DAL.Migrations
{
    public partial class AddingQRCODEtoUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approve",
                table: "Reservations");

            migrationBuilder.AddColumn<byte[]>(
                name: "UserQRCode",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2022, 11, 10, 10, 13, 33, 559, DateTimeKind.Utc).AddTicks(5773), "35596a8d-4606-46f7-b181-d2b0f2222de9", "AQAAAAEAACcQAAAAELgvi//87QjShN+1wLBEEACG+Gkb1YkEClKJ1lUiDkRml8DWRi/s+IE7S4B8byyv7Q==", "8f6bc9b7-c5cc-4737-b26a-84fcec14bb4b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserQRCode",
                table: "Users");

            migrationBuilder.AddColumn<bool>(
                name: "Approve",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2022, 11, 6, 13, 12, 39, 2, DateTimeKind.Utc).AddTicks(7864), "1fe10b57-37bf-484e-bf86-3024c0c71c96", "AQAAAAEAACcQAAAAEC05xh4kBnf2+dvJYJF2D20hoFXuWQV24GYSON4DRjbW2RWUJ/f0se9FxC8tdR43xg==", "1f134ec2-d572-49d9-bdc2-c918fe73d620" });
        }
    }
}
