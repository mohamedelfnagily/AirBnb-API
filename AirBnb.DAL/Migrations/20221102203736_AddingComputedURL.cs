using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirBnb.DAL.Migrations
{
    public partial class AddingComputedURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "CONCAT(Name,'.jpg') ");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("21e02ac0-2570-4300-bf39-63aced0a988c"), "seaviewairbnb", "Amazing Pools" },
                    { new Guid("344a216c-e4bf-4c9d-ae73-e6951e815c99"), "Farmsairbnb", "Farms" },
                    { new Guid("578a3795-87de-4aee-8b47-910333674365"), "Boatsairbnb", "Boats" },
                    { new Guid("58d0a9a3-53be-4fb9-bd68-52e76fa6feee"), "Nationalparksairbnb", "National Parks" },
                    { new Guid("6a3bf9d1-770e-4626-b876-e7a8afeb5c5b"), "Countrysideairbnb", "Countryside" },
                    { new Guid("7865d847-b2a4-4fed-b2c9-a6a8115130f4"), "Bed & breakfastsairbnb", "Bed & breakfasts" },
                    { new Guid("8dfa37c7-fd86-4d39-85b7-eba5ff6703e6"), "Golfing airbnb", "Golfing" },
                    { new Guid("8eff8bf2-37f3-4eb8-9baa-221cc474ac69"), "Amazing Viewsairbnb", "Amazing Views" },
                    { new Guid("ae2d1a2c-4816-49c4-83b6-f3df97741414"), "Desertsairbnb", "Deserts" },
                    { new Guid("b4b89a41-615b-4cef-8bd8-6e6a1f3e191c"), "Shared Homesairbnb", "Shared Homes" },
                    { new Guid("c41d7604-6bf5-4b60-959d-57a1522628ef"), "Earth homesairbnb", "Earth homes" },
                    { new Guid("df924d0e-c99c-48f4-b77e-b2e876967476"), "Lakeairbnb", "Lake" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("21e02ac0-2570-4300-bf39-63aced0a988c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("344a216c-e4bf-4c9d-ae73-e6951e815c99"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("578a3795-87de-4aee-8b47-910333674365"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("58d0a9a3-53be-4fb9-bd68-52e76fa6feee"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6a3bf9d1-770e-4626-b876-e7a8afeb5c5b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7865d847-b2a4-4fed-b2c9-a6a8115130f4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8dfa37c7-fd86-4d39-85b7-eba5ff6703e6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8eff8bf2-37f3-4eb8-9baa-221cc474ac69"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ae2d1a2c-4816-49c4-83b6-f3df97741414"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b4b89a41-615b-4cef-8bd8-6e6a1f3e191c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c41d7604-6bf5-4b60-959d-57a1522628ef"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("df924d0e-c99c-48f4-b77e-b2e876967476"));

            migrationBuilder.DropColumn(
                name: "URL",
                table: "Categories");

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
    }
}
