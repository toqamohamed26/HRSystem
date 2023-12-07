using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class De : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GeneralSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GeneralSettings");
        }
    }
}
