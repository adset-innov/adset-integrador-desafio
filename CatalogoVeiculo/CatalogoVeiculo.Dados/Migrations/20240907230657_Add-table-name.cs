using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogoVeiculo.Dados.Migrations
{
    /// <inheritdoc />
    public partial class Addtablename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fotos_Veiculos_VeiculoId",
                table: "Fotos");

            migrationBuilder.DropForeignKey(
                name: "FK_Opcionais_Veiculos_VeiculoId",
                table: "Opcionais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Veiculos",
                table: "Veiculos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Opcionais",
                table: "Opcionais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fotos",
                table: "Fotos");

            migrationBuilder.RenameTable(
                name: "Veiculos",
                newName: "cad_veiculos");

            migrationBuilder.RenameTable(
                name: "Opcionais",
                newName: "cad_opcionais");

            migrationBuilder.RenameTable(
                name: "Fotos",
                newName: "cad_fotos");

            migrationBuilder.RenameIndex(
                name: "IX_Opcionais_VeiculoId",
                table: "cad_opcionais",
                newName: "IX_cad_opcionais_VeiculoId");

            migrationBuilder.RenameIndex(
                name: "IX_Fotos_VeiculoId",
                table: "cad_fotos",
                newName: "IX_cad_fotos_VeiculoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cad_veiculos",
                table: "cad_veiculos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cad_opcionais",
                table: "cad_opcionais",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cad_fotos",
                table: "cad_fotos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_cad_fotos_cad_veiculos_VeiculoId",
                table: "cad_fotos",
                column: "VeiculoId",
                principalTable: "cad_veiculos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_cad_opcionais_cad_veiculos_VeiculoId",
                table: "cad_opcionais",
                column: "VeiculoId",
                principalTable: "cad_veiculos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cad_fotos_cad_veiculos_VeiculoId",
                table: "cad_fotos");

            migrationBuilder.DropForeignKey(
                name: "FK_cad_opcionais_cad_veiculos_VeiculoId",
                table: "cad_opcionais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cad_veiculos",
                table: "cad_veiculos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cad_opcionais",
                table: "cad_opcionais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cad_fotos",
                table: "cad_fotos");

            migrationBuilder.RenameTable(
                name: "cad_veiculos",
                newName: "Veiculos");

            migrationBuilder.RenameTable(
                name: "cad_opcionais",
                newName: "Opcionais");

            migrationBuilder.RenameTable(
                name: "cad_fotos",
                newName: "Fotos");

            migrationBuilder.RenameIndex(
                name: "IX_cad_opcionais_VeiculoId",
                table: "Opcionais",
                newName: "IX_Opcionais_VeiculoId");

            migrationBuilder.RenameIndex(
                name: "IX_cad_fotos_VeiculoId",
                table: "Fotos",
                newName: "IX_Fotos_VeiculoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Veiculos",
                table: "Veiculos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Opcionais",
                table: "Opcionais",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fotos",
                table: "Fotos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fotos_Veiculos_VeiculoId",
                table: "Fotos",
                column: "VeiculoId",
                principalTable: "Veiculos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Opcionais_Veiculos_VeiculoId",
                table: "Opcionais",
                column: "VeiculoId",
                principalTable: "Veiculos",
                principalColumn: "Id");
        }
    }
}
