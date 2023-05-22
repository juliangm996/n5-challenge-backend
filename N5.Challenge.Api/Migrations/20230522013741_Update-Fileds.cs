using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace N5.Challenge.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFileds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaPermio",
                table: "Permissions",
                newName: "FechaPermiso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaPermiso",
                table: "Permissions",
                newName: "FechaPermio");
        }
    }
}
