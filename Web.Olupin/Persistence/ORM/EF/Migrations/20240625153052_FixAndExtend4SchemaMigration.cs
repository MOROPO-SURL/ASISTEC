using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MOROPO.ASISTEC.Web.Olupin.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class FixAndExtend4SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_references_organizationidentities_identityid",
                table: "references");

            migrationBuilder.DropPrimaryKey(
                name: "pk_references",
                table: "references");

            migrationBuilder.RenameTable(
                name: "references",
                newName: "partners");

            migrationBuilder.RenameIndex(
                name: "ix_references_identityid",
                table: "partners",
                newName: "ix_partners_identityid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_partners",
                table: "partners",
                column: "id");

            migrationBuilder.CreateTable(
                name: "blogentries",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    label = table.Column<string>(type: "text", nullable: true),
                    context = table.Column<string>(type: "text", nullable: true),
                    summary = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    featureimageid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_blogentries", x => x.id);
                    table.ForeignKey(
                        name: "fk_blogentries_images_featureimageid",
                        column: x => x.featureimageid,
                        principalSchema: "guamaframework_media",
                        principalTable: "images",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "solutions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    summary = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    featureimageid = table.Column<Guid>(type: "uuid", nullable: true),
                    serviceid = table.Column<Guid>(type: "uuid", nullable: false),
                    partnerid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_solutions", x => x.id);
                    table.ForeignKey(
                        name: "fk_solutions_images_featureimageid",
                        column: x => x.featureimageid,
                        principalSchema: "guamaframework_media",
                        principalTable: "images",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_solutions_partners_partnerid",
                        column: x => x.partnerid,
                        principalTable: "partners",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_solutions_services_serviceid",
                        column: x => x.serviceid,
                        principalTable: "services",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_blogentries_featureimageid",
                table: "blogentries",
                column: "featureimageid");

            migrationBuilder.CreateIndex(
                name: "ix_solutions_featureimageid",
                table: "solutions",
                column: "featureimageid");

            migrationBuilder.CreateIndex(
                name: "ix_solutions_partnerid",
                table: "solutions",
                column: "partnerid");

            migrationBuilder.CreateIndex(
                name: "ix_solutions_serviceid",
                table: "solutions",
                column: "serviceid");

            migrationBuilder.AddForeignKey(
                name: "fk_partners_organizationidentities_identityid",
                table: "partners",
                column: "identityid",
                principalSchema: "guamaframework_identity",
                principalTable: "organizationidentities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_partners_organizationidentities_identityid",
                table: "partners");

            migrationBuilder.DropTable(
                name: "blogentries");

            migrationBuilder.DropTable(
                name: "solutions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_partners",
                table: "partners");

            migrationBuilder.RenameTable(
                name: "partners",
                newName: "references");

            migrationBuilder.RenameIndex(
                name: "ix_partners_identityid",
                table: "references",
                newName: "ix_references_identityid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_references",
                table: "references",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_references_organizationidentities_identityid",
                table: "references",
                column: "identityid",
                principalSchema: "guamaframework_identity",
                principalTable: "organizationidentities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
