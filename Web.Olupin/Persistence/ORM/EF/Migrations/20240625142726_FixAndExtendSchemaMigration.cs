using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ASISTEC.Web.Olupin.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class FixAndExtendSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "about",
                table: "references",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "references",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "about",
                table: "references");

            migrationBuilder.DropColumn(
                name: "name",
                table: "references");
        }
    }
}
