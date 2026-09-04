using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.Migrations
{
    /// <inheritdoc />
    public partial class seedingDiffucultyandRegion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: new Guid("64017304-958c-4207-bcc8-9a98342d2d65"));

            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: new Guid("9e766682-82ce-4d62-91c4-5b77626eefc3"));

            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: new Guid("ad25263b-512b-4469-adb2-ee9df3fd7689"));

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: new Guid("bd05dce6-63ce-42a3-8003-aac54b6f026d"));

            migrationBuilder.InsertData(
                table: "Difficulty",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0f4d67e6-a993-487b-852b-5c8e41c2621b"), "Easy" },
                    { new Guid("427a22f7-cceb-48ac-b381-529d46b7d35c"), "Medium" },
                    { new Guid("9f259eff-19a9-4937-a63d-9c9cc86716ed"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[] { new Guid("41f97f75-a7b9-4b31-ad86-d5a1926e6a5b"), "AKL", "Auckland", "auckland image" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: new Guid("0f4d67e6-a993-487b-852b-5c8e41c2621b"));

            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: new Guid("427a22f7-cceb-48ac-b381-529d46b7d35c"));

            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: new Guid("9f259eff-19a9-4937-a63d-9c9cc86716ed"));

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: new Guid("41f97f75-a7b9-4b31-ad86-d5a1926e6a5b"));

            migrationBuilder.InsertData(
                table: "Difficulty",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("64017304-958c-4207-bcc8-9a98342d2d65"), "Medium" },
                    { new Guid("9e766682-82ce-4d62-91c4-5b77626eefc3"), "Hard" },
                    { new Guid("ad25263b-512b-4469-adb2-ee9df3fd7689"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[] { new Guid("bd05dce6-63ce-42a3-8003-aac54b6f026d"), "AKL", "Auckland", "auckland image" });
        }
    }
}
