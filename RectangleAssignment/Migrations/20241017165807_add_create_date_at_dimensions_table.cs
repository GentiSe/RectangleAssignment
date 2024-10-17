using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RectangleAssignment.Migrations
{
    /// <inheritdoc />
    public partial class add_create_date_at_dimensions_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "RectangleDimensions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "RectangleDimensions");
        }
    }
}
