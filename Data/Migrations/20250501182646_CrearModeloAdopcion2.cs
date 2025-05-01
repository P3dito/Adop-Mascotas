using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Adop_mascotas.Data.Migrations
{
    /// <inheritdoc />
    public partial class CrearModeloAdopcion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_adoptante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_adoptante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_mascota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Edad = table.Column<int>(type: "integer", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    EstaAdoptada = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_mascota", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_adopcion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MascotaId = table.Column<int>(type: "integer", nullable: false),
                    AdoptanteId = table.Column<int>(type: "integer", nullable: false),
                    FechaAdopcion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_adopcion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_adopcion_t_adoptante_AdoptanteId",
                        column: x => x.AdoptanteId,
                        principalTable: "t_adoptante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_adopcion_t_mascota_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "t_mascota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_adopcion_AdoptanteId",
                table: "t_adopcion",
                column: "AdoptanteId");

            migrationBuilder.CreateIndex(
                name: "IX_t_adopcion_MascotaId",
                table: "t_adopcion",
                column: "MascotaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_adopcion");

            migrationBuilder.DropTable(
                name: "t_adoptante");

            migrationBuilder.DropTable(
                name: "t_mascota");
        }
    }
}
