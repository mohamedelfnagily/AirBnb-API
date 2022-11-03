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
                values: new object[] { Guid.NewGuid(), "Amazing Pools", "seaviewairbnb" }
            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { Guid.NewGuid(), "National Parks", "Nationalparksairbnb" }
            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { Guid.NewGuid(), "Shared Homes", "Shared Homesairbnb" }
            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { Guid.NewGuid(), "Amazing Views", "Amazing Viewsairbnb" }
            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { Guid.NewGuid(), "Bed & breakfasts", "Bed & breakfastsairbnb" }
            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { Guid.NewGuid(), "Lake", "Lakeairbnb" }
            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { Guid.NewGuid(), "Farms", "Farmsairbnb" }
            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { Guid.NewGuid(), "Boats", "Boatsairbnb" }
            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { Guid.NewGuid(), "Deserts", "Desertsairbnb" }
            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { Guid.NewGuid(), "Countryside", "Countrysideairbnb" }
            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { Guid.NewGuid(), "Earth homes", "Earth homesairbnb" }
            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { Guid.NewGuid(), "Golfing", "Golfing Golfingairbnb" }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categories");
        }
    }
}
