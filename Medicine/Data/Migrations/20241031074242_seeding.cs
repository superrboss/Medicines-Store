﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medicine.Data.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), "User", "User", Guid.NewGuid().ToString() }
                );
            migrationBuilder.InsertData(
             table: "AspNetRoles",
             columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
             values: new object[] { Guid.NewGuid().ToString(), "Admin", "Admin", Guid.NewGuid().ToString() }
             );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM[AspNetRoles]");
        }
    }
}
