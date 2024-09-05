using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdSet.Dados.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cad_veiculos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Km = table.Column<long>(type: "bigint", nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cad_veiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cad_fotos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cad_fotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cad_fotos_cad_veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "cad_veiculos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "cad_opcionais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArCondicionado = table.Column<bool>(type: "bit", nullable: true),
                    Alarme = table.Column<bool>(type: "bit", nullable: true),
                    AirBag = table.Column<bool>(type: "bit", nullable: true),
                    FreioAbs = table.Column<bool>(type: "bit", nullable: true),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cad_opcionais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cad_opcionais_cad_veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "cad_veiculos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cad_fotos_VeiculoId",
                table: "cad_fotos",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_cad_opcionais_VeiculoId",
                table: "cad_opcionais",
                column: "VeiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cad_fotos");

            migrationBuilder.DropTable(
                name: "cad_opcionais");

            migrationBuilder.DropTable(
                name: "cad_veiculos");
        }
    }
}
