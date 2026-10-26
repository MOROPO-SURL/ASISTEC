using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ASISTEC.Web.Olupin.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExtendPlus2SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "representativeimageid",
                table: "testimonials",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "featureimageid",
                table: "services",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "priority",
                table: "services",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_testimonials_representativeimageid",
                table: "testimonials",
                column: "representativeimageid");

            migrationBuilder.CreateIndex(
                name: "ix_services_featureimageid",
                table: "services",
                column: "featureimageid");

            migrationBuilder.AddForeignKey(
                name: "fk_services_images_featureimageid",
                table: "services",
                column: "featureimageid",
                principalSchema: "guamaframework_media",
                principalTable: "images",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_testimonials_images_representativeimageid",
                table: "testimonials",
                column: "representativeimageid",
                principalSchema: "guamaframework_media",
                principalTable: "images",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_services_images_featureimageid",
                table: "services");

            migrationBuilder.DropForeignKey(
                name: "fk_testimonials_images_representativeimageid",
                table: "testimonials");

            migrationBuilder.DropIndex(
                name: "ix_testimonials_representativeimageid",
                table: "testimonials");

            migrationBuilder.DropIndex(
                name: "ix_services_featureimageid",
                table: "services");

            migrationBuilder.DropColumn(
                name: "representativeimageid",
                table: "testimonials");

            migrationBuilder.DropColumn(
                name: "featureimageid",
                table: "services");

            migrationBuilder.DropColumn(
                name: "priority",
                table: "services");
        }
    }
}
