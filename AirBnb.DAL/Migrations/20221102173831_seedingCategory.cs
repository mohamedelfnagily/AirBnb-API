using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirBnb.DAL.Migrations
{
    public partial class seedingCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0a3c8e5b-0d1c-42eb-a67c-90537fe825d8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0cd94ca7-6abd-4789-902d-0c82c4a443bc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("322618d4-4a18-4774-bbb7-4c2394fddc41"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3b16b0cd-7e61-43d9-af79-df8ba822812a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9a0b1980-740d-4e33-9b55-2b6738e429cb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b3f3d726-1205-49f0-a101-679fd02af84e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ec021e34-1296-45c1-8b35-437c9a2fe27b"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0767f5fe-131e-4492-96e5-6c781cab1872"), "Countrysideairbnb", "Countryside" },
                    { new Guid("079c1514-36ca-499c-990e-9e7425d46bbf"), "Golfing airbnb", "Golfing" },
                    { new Guid("09bf7a7f-444c-457c-829e-172b7ac1e860"), "Bed & breakfastsairbnb", "Bed & breakfasts" },
                    { new Guid("106e03d7-d135-4b9a-8720-30e8ca6036f2"), "seaviewairbnb", "Amazing Pools" },
                    { new Guid("49c27bbd-6259-494b-8125-f7c47cfa151c"), "Amazing Viewsairbnb", "Amazing Views" },
                    { new Guid("5e3db886-11aa-400a-993f-46f9fb0bad63"), "Nationalparksairbnb", "National Parks" },
                    { new Guid("862e053b-3731-4f26-8fab-03c9097464f4"), "Boatsairbnb", "Boats" },
                    { new Guid("95dc944e-31d3-4ebf-a4da-96ab4cf57704"), "Lakeairbnb", "Lake" },
                    { new Guid("96b89961-54cc-4ee5-af9b-2a039532c6fd"), "Desertsairbnb", "Deserts" },
                    { new Guid("9a7d55b8-3d18-43f5-9b42-9902aea693db"), "Shared Homesairbnb", "Shared Homes" },
                    { new Guid("b8b0c4c4-ee34-46b3-b0f6-df1edcc5f113"), "Farmsairbnb", "Farms" },
                    { new Guid("e0a147e4-1485-4622-b868-da9979145a77"), "Earth homesairbnb", "Earth homes" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0767f5fe-131e-4492-96e5-6c781cab1872"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("079c1514-36ca-499c-990e-9e7425d46bbf"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("09bf7a7f-444c-457c-829e-172b7ac1e860"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("106e03d7-d135-4b9a-8720-30e8ca6036f2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("49c27bbd-6259-494b-8125-f7c47cfa151c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5e3db886-11aa-400a-993f-46f9fb0bad63"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("862e053b-3731-4f26-8fab-03c9097464f4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("95dc944e-31d3-4ebf-a4da-96ab4cf57704"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("96b89961-54cc-4ee5-af9b-2a039532c6fd"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9a7d55b8-3d18-43f5-9b42-9902aea693db"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b8b0c4c4-ee34-46b3-b0f6-df1edcc5f113"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e0a147e4-1485-4622-b868-da9979145a77"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0a3c8e5b-0d1c-42eb-a67c-90537fe825d8"), "apartmentairbnb", "apartment" },
                    { new Guid("0cd94ca7-6abd-4789-902d-0c82c4a443bc"), "seaviewairbnb", "seaview" },
                    { new Guid("322618d4-4a18-4774-bbb7-4c2394fddc41"), "campersairbnb", "campers" },
                    { new Guid("3b16b0cd-7e61-43d9-af79-df8ba822812a"), "seaviewairbnb", "seaview" },
                    { new Guid("9a0b1980-740d-4e33-9b55-2b6738e429cb"), "sharedhomesairbnb", "sharedhomes" },
                    { new Guid("b3f3d726-1205-49f0-a101-679fd02af84e"), "cabinsairbnb", "cabins" },
                    { new Guid("ec021e34-1296-45c1-8b35-437c9a2fe27b"), "castlesairbnb", "castles" }
                });
        }
    }
}
