using AirBnb.DAL.Data.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirBnb.DAL.Migrations
{
    public partial class seedingCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { "82d6712c-aa66-436a-8000-9424ecb6cdb0", "Amazing Pools", "seaviewairbnb" }
            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { "bdbf25ed-dffe-4aed-b247-abf40602debf", "National Parks", "Nationalparksairbnb" }
            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { "99268a74-cf34-4eb3-a6eb-f51715b9dae5", "Shared Homes", "Shared Homesairbnb" }
            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { "bc9fdfee-016f-4b3b-9374-eeeeb115c41b", "Amazing Views", "Amazing Viewsairbnb" }
            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { "a7c81d4c-0fcb-46ab-97ee-37ffc60cef90", "Bed & breakfasts", "Bed & breakfastsairbnb" }
            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { "8e71765f-1312-4e8f-8626-b0e3f5909929", "Lake", "Lakeairbnb" }
            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { "cf38632e-a080-470f-8294-e97dc281ced2", "Farms", "Farmsairbnb" }
            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { "2b15de36-b113-488a-8e52-b395e60c2857", "Boats", "Boatsairbnb" }
            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { "c5c87d2d-3b3d-49c7-ac2a-6f8436972837", "Deserts", "Desertsairbnb" }
            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { "bc3d1342-b4df-45c7-b3b3-3d9654fad725", "Countryside", "Countrysideairbnb" }
            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { "113a8e01-97f2-4ff4-8928-ad65e67a468b", "Earth homes", "Earth homesairbnb" }
            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { "7aa352c8-6373-4331-9f1c-117f97085489", "Golfing", "Golfing Golfingairbnb" }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categories");
        }
    }
}
