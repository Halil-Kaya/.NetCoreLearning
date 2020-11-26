using Microsoft.EntityFrameworkCore.Migrations;

namespace identityLearning.Migrations
{
    public partial class roleDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RoleType",
                table: "AspNetRoles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "AspNetUsers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleType",
                table: "AspNetRoles",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
