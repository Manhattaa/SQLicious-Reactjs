using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SQLicious.Server.Migrations
{
    /// <inheritdoc />
    public partial class MenuType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenuType",
                table: "MenuItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuType",
                table: "MenuItems");
        }
    }
}
