using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RectangleAssignment.Migrations
{
    /// <inheritdoc />
    public partial class save_perimeter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Perimeter",
                table: "RectangleDimensions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Perimeter",
                table: "RectangleDimensions");
        }
    }
}
