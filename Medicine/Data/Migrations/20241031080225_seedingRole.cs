using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medicine.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedingRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [AspNetUserRoles] (UserId,RoleId) SELECT 'b68d1085-ffb8-440b-8d6c-4d79e4277662' , Id FROM [AspNetRoles]");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [AspNetUserRoles] WHERE UserId='b68d1085-ffb8-440b-8d6c-4d79e4277662'");
        }
    }
}
