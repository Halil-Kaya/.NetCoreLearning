using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyIdentityServer.AuthServer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customUsers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    Emai = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customUsers", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "customUsers",
                columns: new[] { "id", "City", "Emai", "Password", "UserName" },
                values: new object[] { 1, "İstanbul", "halil@gmail.com", "password", "halilKaya" });

            migrationBuilder.InsertData(
                table: "customUsers",
                columns: new[] { "id", "City", "Emai", "Password", "UserName" },
                values: new object[] { 2, "Ankara", "ahmet@gmail.com", "password", "ahmetKaya" });

            migrationBuilder.InsertData(
                table: "customUsers",
                columns: new[] { "id", "City", "Emai", "Password", "UserName" },
                values: new object[] { 3, "Mardin", "mehmet@gmail.com", "password", "mehmetKaya" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customUsers");
        }
    }
}
