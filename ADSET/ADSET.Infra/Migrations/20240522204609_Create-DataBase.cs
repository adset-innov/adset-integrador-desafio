using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ADSET.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CreateDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 22, 17, 46, 9, 98, DateTimeKind.Local).AddTicks(9811)),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Opcionais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(2745)),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opcionais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MarcaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 22, 17, 46, 9, 98, DateTimeKind.Local).AddTicks(8020)),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modelos_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MarcaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModeloId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ano = table.Column<int>(type: "int", maxLength: 9999, nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Km = table.Column<int>(type: "int", maxLength: 9999, nullable: false, defaultValue: 0),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    HaveFoto = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 22, 17, 46, 9, 98, DateTimeKind.Local).AddTicks(5145)),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculos_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Veiculos_Modelos_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fotos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Caminho = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(761)),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fotos_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pacotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(6414)),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacotes_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VeiculoOpcional",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OpcionalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(3776)),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeiculoOpcional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VeiculoOpcional_Opcionais_OpcionalId",
                        column: x => x.OpcionalId,
                        principalTable: "Opcionais",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VeiculoOpcional_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "IsActive", "Nome" },
                values: new object[,]
                {
                    { new Guid("0525e486-1afc-4a3d-9237-3782f0c15adc"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7431), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7432), true, "GMC/Chevrolet" },
                    { new Guid("284399f5-c9a1-4c6e-a475-2214c2cba0d2"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7430), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7430), true, "Ford" },
                    { new Guid("4ed86015-3fdd-4132-a08a-6a0f8d77c136"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7433), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7433), true, "Toyota" },
                    { new Guid("e5013aa0-8e78-403d-a0aa-19cc3678d353"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7425), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7425), true, "Fiat" }
                });

            migrationBuilder.InsertData(
                table: "Opcionais",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "IsActive", "Nome" },
                values: new object[,]
                {
                    { new Guid("11797cce-56fd-4817-841a-e77d45650d4b"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7349), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7349), true, "Teto Solar" },
                    { new Guid("21624df6-bf8a-418c-bfb9-9d25313f6a0b"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7367), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7368), true, "Sensor de Ré" },
                    { new Guid("73edc3c9-6ada-4471-b5c4-248d05e5c4bc"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7342), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7346), true, "Ar Condicionado" },
                    { new Guid("8e0f30ba-4d01-4bd1-bf21-274cdc8902eb"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7366), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7366), true, "Vidro Elétrico" },
                    { new Guid("9445011c-00a2-4d9b-91b8-d3359c3dbc54"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7365), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7365), true, "Trava Elétrica" },
                    { new Guid("c0c42d25-8eae-43c6-a693-04271ac26af6"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7370), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7371), true, "Banco de Couro" },
                    { new Guid("c29799c7-6e6c-493b-95b0-79f6b1af967b"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7361), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7361), true, "Air Bag" },
                    { new Guid("d0ccbcfb-5a52-4590-ad7c-a2bd83348a2d"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7369), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7369), true, "Câmera de Ré" },
                    { new Guid("d53c025d-d6fa-4ec6-9c4e-7d175afae0f5"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7362), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7362), true, "Som" },
                    { new Guid("e420df33-5c78-47a8-85cf-35efcb04f6bd"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7351), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7351), true, "Alarme" }
                });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "IsActive", "MarcaId", "Nome" },
                values: new object[,]
                {
                    { new Guid("0263304b-8d53-4e20-9347-11078b2ae8ac"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7446), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7446), true, new Guid("e5013aa0-8e78-403d-a0aa-19cc3678d353"), "500" },
                    { new Guid("1204b932-4dcf-4478-822f-97885cb35352"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7488), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7489), true, new Guid("4ed86015-3fdd-4132-a08a-6a0f8d77c136"), "Hilux" },
                    { new Guid("133ed150-087d-407a-9606-f91e7ca4a677"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7444), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7444), true, new Guid("e5013aa0-8e78-403d-a0aa-19cc3678d353"), "147" },
                    { new Guid("25204173-5066-4ba1-950e-82397ecf99d9"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7443), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7443), true, new Guid("e5013aa0-8e78-403d-a0aa-19cc3678d353"), "Toro" },
                    { new Guid("25f04d9d-4cd2-4acd-a440-ebea4e4b391d"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7457), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7458), true, new Guid("284399f5-c9a1-4c6e-a475-2214c2cba0d2"), "Mustang" },
                    { new Guid("2cab4a98-69f7-4f1e-9cd6-2d21ea6b0c68"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7491), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7491), true, new Guid("4ed86015-3fdd-4132-a08a-6a0f8d77c136"), "Etios" },
                    { new Guid("2cfde1f1-ec7e-4102-8480-2fe371b6c42c"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7478), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7479), true, new Guid("0525e486-1afc-4a3d-9237-3782f0c15adc"), "Onix" },
                    { new Guid("31b36c71-0254-4be3-a63c-43b26c59831f"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7461), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7462), true, new Guid("284399f5-c9a1-4c6e-a475-2214c2cba0d2"), "Del Rey" },
                    { new Guid("351c0836-30e1-4f59-a0be-0ff7d13e6d1d"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7452), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7452), true, new Guid("e5013aa0-8e78-403d-a0aa-19cc3678d353"), "Marea" },
                    { new Guid("35d033b2-ac66-4af1-af03-dd2991621f48"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7439), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7440), true, new Guid("e5013aa0-8e78-403d-a0aa-19cc3678d353"), "Uno" },
                    { new Guid("39fc282a-90b8-4bea-b42e-41dc5e793367"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7460), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7460), true, new Guid("284399f5-c9a1-4c6e-a475-2214c2cba0d2"), "Belina" },
                    { new Guid("494b7ef3-f475-4869-81e4-bfa561310196"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7497), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7497), true, new Guid("4ed86015-3fdd-4132-a08a-6a0f8d77c136"), "Supra" },
                    { new Guid("5799fd92-34fe-45ec-8005-03f0c479ea63"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7475), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7475), true, new Guid("0525e486-1afc-4a3d-9237-3782f0c15adc"), "Blaze" },
                    { new Guid("5aa778a8-4a52-460f-899e-1b5a20156762"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7466), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7466), true, new Guid("284399f5-c9a1-4c6e-a475-2214c2cba0d2"), "Pampa" },
                    { new Guid("71870142-2205-422b-8c2a-f4508c4bcd33"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7456), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7456), true, new Guid("284399f5-c9a1-4c6e-a475-2214c2cba0d2"), "Ka" },
                    { new Guid("885315fd-a9bf-406a-b5c6-8272e40d9fe3"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7459), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7459), true, new Guid("284399f5-c9a1-4c6e-a475-2214c2cba0d2"), "Range" },
                    { new Guid("8ed910d3-2dc7-4137-9462-bca9ac954b60"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7453), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7454), true, new Guid("e5013aa0-8e78-403d-a0aa-19cc3678d353"), "Tempra" },
                    { new Guid("9277a5ff-d2dc-4bc5-ae60-58b70dc32e3a"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7494), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7494), true, new Guid("4ed86015-3fdd-4132-a08a-6a0f8d77c136"), "RAV4" },
                    { new Guid("95872650-b285-4100-ae76-ee2e315ab566"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7470), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7470), true, new Guid("0525e486-1afc-4a3d-9237-3782f0c15adc"), "S10" },
                    { new Guid("9ba94021-230a-4053-a6ab-80bc6bd986d0"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7486), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7486), true, new Guid("4ed86015-3fdd-4132-a08a-6a0f8d77c136"), "Corolla" },
                    { new Guid("ad9420f5-7a8e-4bb1-80ed-8aa3b23ec56e"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7474), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7474), true, new Guid("0525e486-1afc-4a3d-9237-3782f0c15adc"), "Camaro" },
                    { new Guid("af33c664-645c-4b27-8492-e1702ad70bc1"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7498), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7498), true, new Guid("4ed86015-3fdd-4132-a08a-6a0f8d77c136"), "Yaris" },
                    { new Guid("b153c00c-a6c7-47f2-81f0-2aa4f8af2184"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7450), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7451), true, new Guid("e5013aa0-8e78-403d-a0aa-19cc3678d353"), "Strada" },
                    { new Guid("b427468a-c091-44f4-a245-dd5df450e6d0"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7481), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7481), true, new Guid("0525e486-1afc-4a3d-9237-3782f0c15adc"), "Silverado" },
                    { new Guid("c8c0d2ce-3459-4df5-bc0e-6fc7d9d3754f"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7464), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7465), true, new Guid("284399f5-c9a1-4c6e-a475-2214c2cba0d2"), "Verona" },
                    { new Guid("cae40ea7-3d14-436f-8942-7d91425e4536"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7447), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7447), true, new Guid("e5013aa0-8e78-403d-a0aa-19cc3678d353"), "Bravo" },
                    { new Guid("d7aaa453-216d-409c-899f-1f3ef583e7d5"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7472), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7472), true, new Guid("0525e486-1afc-4a3d-9237-3782f0c15adc"), "C10" },
                    { new Guid("e3156a9f-56cf-4728-ac6c-1cefad127cd2"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7490), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7490), true, new Guid("4ed86015-3fdd-4132-a08a-6a0f8d77c136"), "SW4" },
                    { new Guid("f5180371-7eba-4989-9068-be4581d2a511"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7482), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7483), true, new Guid("0525e486-1afc-4a3d-9237-3782f0c15adc"), "Caravan" },
                    { new Guid("f5cc4b13-8f87-4ca8-aef6-f0a252326e86"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7476), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7477), true, new Guid("0525e486-1afc-4a3d-9237-3782f0c15adc"), "Agile" },
                    { new Guid("f67c0319-0012-4ba2-b444-7d52ecadf14d"), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7492), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7493), true, new Guid("4ed86015-3fdd-4132-a08a-6a0f8d77c136"), "Camry" }
                });

            migrationBuilder.InsertData(
                table: "Veiculos",
                columns: new[] { "Id", "Ano", "Cor", "DateCreated", "DateUpdated", "IsActive", "Km", "MarcaId", "ModeloId", "Placa", "Preco" },
                values: new object[,]
                {
                    { new Guid("1c652922-0df7-4f05-891d-0134fbd0dec8"), 2012, "Prata", new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7674), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7675), true, 35000, new Guid("e5013aa0-8e78-403d-a0aa-19cc3678d353"), new Guid("0263304b-8d53-4e20-9347-11078b2ae8ac"), "CNH1D34", 49999m },
                    { new Guid("1e6b5639-a70f-4b19-8ffa-ba3d21ee154c"), 2020, "Azul", new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7710), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7710), true, 150000, new Guid("e5013aa0-8e78-403d-a0aa-19cc3678d353"), new Guid("b153c00c-a6c7-47f2-81f0-2aa4f8af2184"), "DCA1D34", 109999m },
                    { new Guid("5bea5b84-3f27-47cc-8045-a227583287bf"), 2011, "Branco", new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7631), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7631), true, 15000, new Guid("e5013aa0-8e78-403d-a0aa-19cc3678d353"), new Guid("133ed150-087d-407a-9606-f91e7ca4a677"), "CBD1D34", 59999m },
                    { new Guid("7f4e2c53-be06-4d17-af32-002f4c05265d"), 2019, "Vermelho", new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7692), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7692), true, 90000, new Guid("e5013aa0-8e78-403d-a0aa-19cc3678d353"), new Guid("cae40ea7-3d14-436f-8942-7d91425e4536"), "CAB1D34", 99999m },
                    { new Guid("b481e3aa-cf21-4c52-a10c-d412a376d19c"), 2015, "Preto", new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7593), new DateTime(2024, 5, 22, 17, 46, 9, 99, DateTimeKind.Local).AddTicks(7593), true, 10000, new Guid("e5013aa0-8e78-403d-a0aa-19cc3678d353"), new Guid("25204173-5066-4ba1-950e-82397ecf99d9"), "ABC1D34", 89999m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fotos_VeiculoId",
                table: "Fotos",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_MarcaId",
                table: "Modelos",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacotes_VeiculoId",
                table: "Pacotes",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_VeiculoOpcional_OpcionalId",
                table: "VeiculoOpcional",
                column: "OpcionalId");

            migrationBuilder.CreateIndex(
                name: "IX_VeiculoOpcional_VeiculoId",
                table: "VeiculoOpcional",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_MarcaId",
                table: "Veiculos",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_ModeloId",
                table: "Veiculos",
                column: "ModeloId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fotos");

            migrationBuilder.DropTable(
                name: "Pacotes");

            migrationBuilder.DropTable(
                name: "VeiculoOpcional");

            migrationBuilder.DropTable(
                name: "Opcionais");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
