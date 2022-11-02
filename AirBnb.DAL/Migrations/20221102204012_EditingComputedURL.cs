using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirBnb.DAL.Migrations
{
    public partial class EditingComputedURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "URL",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "CONCAT(TRIM(Name),'.jpg') ",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComputedColumnSql: "CONCAT(Name,'.jpg') ");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("3a8fcd42-79b5-4866-945a-c41bff55b7ad"), "Boatsairbnb", "Boats" },
                    { new Guid("4caa1440-4694-4840-848e-d57f91e7fb0c"), "Shared Homesairbnb", "Shared Homes" },
                    { new Guid("4d426a09-edaf-4089-a3fa-bdbeae999770"), "seaviewairbnb", "Amazing Pools" },
                    { new Guid("6209bb3d-15f1-4746-be55-e1120ed2f502"), "Lakeairbnb", "Lake" },
                    { new Guid("6a1bec58-38ac-41ca-be93-ffdb1055e809"), "Golfing airbnb", "Golfing" },
                    { new Guid("7ecaddc7-7563-4101-851f-bc9b9f799b69"), "Countrysideairbnb", "Countryside" },
                    { new Guid("b3acd953-2e69-4748-bafa-0438f77cb965"), "Earth homesairbnb", "Earth homes" },
                    { new Guid("c97eef28-bfd2-4ff6-a538-b757a60a9ed0"), "Farmsairbnb", "Farms" },
                    { new Guid("e7e106e1-7996-4a89-b1a9-0912af450740"), "Amazing Viewsairbnb", "Amazing Views" },
                    { new Guid("ed8159f7-0b0f-4bd0-b33d-8ab4832040c5"), "Bed & breakfastsairbnb", "Bed & breakfasts" },
                    { new Guid("fb7944e8-71f6-4654-8d86-d912062e3ec6"), "Nationalparksairbnb", "National Parks" },
                    { new Guid("fc45bdfb-a1b5-4f8a-af39-a0c1b482df48"), "Desertsairbnb", "Deserts" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3a8fcd42-79b5-4866-945a-c41bff55b7ad"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4caa1440-4694-4840-848e-d57f91e7fb0c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4d426a09-edaf-4089-a3fa-bdbeae999770"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6209bb3d-15f1-4746-be55-e1120ed2f502"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6a1bec58-38ac-41ca-be93-ffdb1055e809"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7ecaddc7-7563-4101-851f-bc9b9f799b69"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b3acd953-2e69-4748-bafa-0438f77cb965"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c97eef28-bfd2-4ff6-a538-b757a60a9ed0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e7e106e1-7996-4a89-b1a9-0912af450740"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ed8159f7-0b0f-4bd0-b33d-8ab4832040c5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fb7944e8-71f6-4654-8d86-d912062e3ec6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fc45bdfb-a1b5-4f8a-af39-a0c1b482df48"));

            migrationBuilder.AlterColumn<string>(
                name: "URL",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "CONCAT(Name,'.jpg') ",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComputedColumnSql: "CONCAT(TRIM(Name),'.jpg') ");

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
    }
}
