using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirBnb.DAL.Migrations
{
    public partial class addProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2022, 11, 3, 19, 14, 9, 27, DateTimeKind.Utc).AddTicks(8747), "d3755ee0-da64-4f93-831e-784a0742d555", "AQAAAAEAACcQAAAAELv3c0eOQw1TStfjcsJVqxvIsyXsyw3B9fq7Xvq78ObQjSJgI28T3w66J2htYtkbbg==", "4f86a14f-c6ef-4ef5-b181-f9324481936b" });

            migrationBuilder.InsertData(
              table: "Properties",
              columns: new[] { "Id", "Description","Location", "Price", "Rating", "PropertyType",
              "MaxNumberOfUsers" ,"NumberOfRooms" ,"Wifi" ,"Parking","Tv" ,"Washer","Elevator","Generator","PrivateRoom",
              "SmokeAlarm","SeaView","HosterId","CategoryId"
              },
              values: new object[] {"0d76d426-f102-4353-8a0d-81516557724b", "Located in the Limanagzi region of Kaş, which is very rare in the world, our villa, which is surrounded by the sea, has 4 bedrooms, a private pool, a private chef and a waiter. In our villa, which is not on the road, our private captain boat is available 24 hours a day to bring our guests to and from Kaş. Our guests are included in the prices. Our chef and waiter will prepare and serve you only when you receive your food and drinks"
              , "Alexandria",1500,0,"Shaleet",5,3,false,true,true,true,true,false,true,
              false,true,"b74ddd14-6340-4840-95c2-db12554843e5","82d6712c-aa66-436a-8000-9424ecb6cdb0"
              }
              );
            //second
               migrationBuilder.InsertData(
              table: "Properties",
              columns: new[] { "Id", "Description","Location", "Price", "Rating", "PropertyType",
              "MaxNumberOfUsers" ,"NumberOfRooms" ,"Wifi" ,"Parking","Tv" ,"Washer","Elevator","Generator","PrivateRoom",
              "SmokeAlarm","SeaView","HosterId","CategoryId"
              },
              values: new object[] { "7a3ee77c-ab68-45ce-98ef-8d7541e92741", "Located in the Limanagzi region of Kaş, which is very rare in the world, our villa, which is surrounded by the sea, has 4 bedrooms, a private pool, a private chef and a waiter. In our villa, which is not on the road, our private captain boat is available 24 hours a day to bring our guests to and from Kaş. Our guests are included in the prices. Our chef and waiter will prepare and serve you only when you receive your food and drinks"
              , "Cairo",3000,0,"Apartment",8,4,true,true,true,true,true,true,true,
              false,true,"b74ddd14-6340-4840-95c2-db12554843e5","82d6712c-aa66-436a-8000-9424ecb6cdb0"
              }
              );
            //third
            migrationBuilder.InsertData(
           table: "Properties",
           columns: new[] { "Id", "Description","Location", "Price", "Rating", "PropertyType",
              "MaxNumberOfUsers" ,"NumberOfRooms" ,"Wifi" ,"Parking","Tv" ,"Washer","Elevator","Generator","PrivateRoom",
              "SmokeAlarm","SeaView","HosterId","CategoryId"
           },
           values: new object[] { "bdc1e617-c7d1-4e71-afe4-cea166aa31b5", "Located in the Limanagzi region of Kaş, which is very rare in the world, our villa, which is surrounded by the sea, has 4 bedrooms, a private pool, a private chef and a waiter. In our villa, which is not on the road, our private captain boat is available 24 hours a day to bring our guests to and from Kaş. Our guests are included in the prices. Our chef and waiter will prepare and serve you only when you receive your food and drinks"
              , "Suez",500,0,"House",8,4,false,false,false,false,true,false,true,
              false,true,"b74ddd14-6340-4840-95c2-db12554843e5","bdbf25ed-dffe-4aed-b247-abf40602debf"
           }
           );

            //fourth
            migrationBuilder.InsertData(
           table: "Properties",
           columns: new[] { "Id", "Description","Location", "Price", "Rating", "PropertyType",
              "MaxNumberOfUsers" ,"NumberOfRooms" ,"Wifi" ,"Parking","Tv" ,"Washer","Elevator","Generator","PrivateRoom",
              "SmokeAlarm","SeaView","HosterId","CategoryId"
           },
           values: new object[] { "cc47a618-a2bb-4d9f-909d-99833f70f616", "Located in the Limanagzi region of Kaş, which is very rare in the world, our villa, which is surrounded by the sea, has 4 bedrooms, a private pool, a private chef and a waiter. In our villa, which is not on the road, our private captain boat is available 24 hours a day to bring our guests to and from Kaş. Our guests are included in the prices. Our chef and waiter will prepare and serve you only when you receive your food and drinks"
              , "Tanta",300,0,"Apartment",8,4,true,false,true,false,true,true,false,
              false,true,"b74ddd14-6340-4840-95c2-db12554843e5","99268a74-cf34-4eb3-a6eb-f51715b9dae5"
           }
           );
            //fifth
            migrationBuilder.InsertData(
           table: "Properties",
           columns: new[] { "Id", "Description","Location", "Price", "Rating", "PropertyType",
              "MaxNumberOfUsers" ,"NumberOfRooms" ,"Wifi" ,"Parking","Tv" ,"Washer","Elevator","Generator","PrivateRoom",
              "SmokeAlarm","SeaView","HosterId","CategoryId"
           },
           values: new object[] { "8c78f74e-ae33-4856-bdfd-c5babad229c1", "Located in the Limanagzi region of Kaş, which is very rare in the world, our villa, which is surrounded by the sea, has 4 bedrooms, a private pool, a private chef and a waiter. In our villa, which is not on the road, our private captain boat is available 24 hours a day to bring our guests to and from Kaş. Our guests are included in the prices. Our chef and waiter will prepare and serve you only when you receive your food and drinks"
              , "Tanta",600,0,"House",3,1,true,true,true,true,true,true,false,
              true,true,"b74ddd14-6340-4840-95c2-db12554843e5","99268a74-cf34-4eb3-a6eb-f51715b9dae5"
           }
           );
            //sixth
            migrationBuilder.InsertData(
           table: "Properties",
           columns: new[] { "Id", "Description","Location", "Price", "Rating", "PropertyType",
              "MaxNumberOfUsers" ,"NumberOfRooms" ,"Wifi" ,"Parking","Tv" ,"Washer","Elevator","Generator","PrivateRoom",
              "SmokeAlarm","SeaView","HosterId","CategoryId"
           },
           values: new object[] { "4bca07b0-2fce-4cba-88b9-d98fa370c1d1", "Located in the Limanagzi region of Kaş, which is very rare in the world, our villa, which is surrounded by the sea, has 4 bedrooms, a private pool, a private chef and a waiter. In our villa, which is not on the road, our private captain boat is available 24 hours a day to bring our guests to and from Kaş. Our guests are included in the prices. Our chef and waiter will prepare and serve you only when you receive your food and drinks"
              , "Tanta",600,0,"House",3,1,true,true,true,true,true,true,false,
              true,true,"b74ddd14-6340-4840-95c2-db12554843e5","99268a74-cf34-4eb3-a6eb-f51715b9dae5"
           }
           );
            //seventh
            migrationBuilder.InsertData(
           table: "Properties",
           columns: new[] { "Id", "Description","Location", "Price", "Rating", "PropertyType",
              "MaxNumberOfUsers" ,"NumberOfRooms" ,"Wifi" ,"Parking","Tv" ,"Washer","Elevator","Generator","PrivateRoom",
              "SmokeAlarm","SeaView","HosterId","CategoryId"
           },
           values: new object[] { "277aac3a-3413-426c-8d83-6e3ce8391d51", "Located in the Limanagzi region of Kaş, which is very rare in the world, our villa, which is surrounded by the sea, has 4 bedrooms, a private pool, a private chef and a waiter. In our villa, which is not on the road, our private captain boat is available 24 hours a day to bring our guests to and from Kaş. Our guests are included in the prices. Our chef and waiter will prepare and serve you only when you receive your food and drinks"
              , "Alexandria",1000,0,"House",3,1,true,true,true,true,true,true,false,
              true,true,"b74ddd14-6340-4840-95c2-db12554843e5","bc9fdfee-016f-4b3b-9374-eeeeb115c41b"
           }
           );
            //eigth
            migrationBuilder.InsertData(
           table: "Properties",
           columns: new[] { "Id", "Description","Location", "Price", "Rating", "PropertyType",
              "MaxNumberOfUsers" ,"NumberOfRooms" ,"Wifi" ,"Parking","Tv" ,"Washer","Elevator","Generator","PrivateRoom",
              "SmokeAlarm","SeaView","HosterId","CategoryId"
           },
           values: new object[] { "592a8272-118b-4895-ac4e-63d99deef7ad", "Located in the Limanagzi region of Kaş, which is very rare in the world, our villa, which is surrounded by the sea, has 4 bedrooms, a private pool, a private chef and a waiter. In our villa, which is not on the road, our private captain boat is available 24 hours a day to bring our guests to and from Kaş. Our guests are included in the prices. Our chef and waiter will prepare and serve you only when you receive your food and drinks"
              , "Cairo",2000,0,"House",2,3,true,true,true,true,true,true,true,
              true,true,"b74ddd14-6340-4840-95c2-db12554843e5","bc9fdfee-016f-4b3b-9374-eeeeb115c41b"
           }
           );
            //ninth
            migrationBuilder.InsertData(
           table: "Properties",
           columns: new[] { "Id", "Description","Location", "Price", "Rating", "PropertyType",
              "MaxNumberOfUsers" ,"NumberOfRooms" ,"Wifi" ,"Parking","Tv" ,"Washer","Elevator","Generator","PrivateRoom",
              "SmokeAlarm","SeaView","HosterId","CategoryId"
           },
           values: new object[] { "142e3697-6657-4909-8c1a-1150ca7a2965", "Located in the Limanagzi region of Kaş, which is very rare in the world, our villa, which is surrounded by the sea, has 4 bedrooms, a private pool, a private chef and a waiter. In our villa, which is not on the road, our private captain boat is available 24 hours a day to bring our guests to and from Kaş. Our guests are included in the prices. Our chef and waiter will prepare and serve you only when you receive your food and drinks"
              , "Sinai",400,0,"Shaleet",1,2,false,false,false,false,false,false,false,
              false,false,"b74ddd14-6340-4840-95c2-db12554843e5","8e71765f-1312-4e8f-8626-b0e3f5909929"
           }
           );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2022, 11, 3, 17, 40, 24, 797, DateTimeKind.Utc).AddTicks(2118), "7a58b0eb-c499-43d9-b714-267650c020b2", "AQAAAAEAACcQAAAAEPGb7C7nJDXwPXDyg0aiYjkoZbK8fzEYIp89PIL0NWeW4VC9OwrwvzfS2P+KPZltlA==", "3cca7ede-d5c7-41c5-949c-cadfbd5c8b9a" });
        }
    }
}
