using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.Migrations
{
    /// <inheritdoc />
    public partial class seedingDifficultyandRegion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
