using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca_Tomar.Data.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seccao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilizadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Telemovel = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CategoriaFK = table.Column<int>(type: "int", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoCapa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livros_Categorias_CategoriaFK",
                        column: x => x.CategoriaFK,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requisicoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequesitanteFK = table.Column<int>(type: "int", nullable: false),
                    NFunEnt = table.Column<int>(type: "int", nullable: false),
                    NFunSaida = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDevol = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Multa = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisicoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requisicoes_Utilizadores_NFunEnt",
                        column: x => x.NFunEnt,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requisicoes_Utilizadores_NFunSaida",
                        column: x => x.NFunSaida,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requisicoes_Utilizadores_RequesitanteFK",
                        column: x => x.RequesitanteFK,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReqLivros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReqFK = table.Column<int>(type: "int", nullable: false),
                    LivroFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReqLivros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReqLivros_Livros_LivroFK",
                        column: x => x.LivroFK,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReqLivros_Requisicoes_ReqFK",
                        column: x => x.ReqFK,
                        principalTable: "Requisicoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Designacao", "Seccao" },
                values: new object[,]
                {
                    { 1, "Ação", 0 },
                    { 2, "Autobiografia", 0 },
                    { 3, "Artbook", 0 }
                });

            migrationBuilder.InsertData(
                table: "Utilizadores",
                columns: new[] { "Id", "Email", "Nome", "Telemovel" },
                values: new object[,]
                {
                    { 1, "Marisa.Freitas@iol.pt", "Marisa Vieira", "967197885" },
                    { 2, "Fátima.Machado@gmail.com", "Fátima Ribeiro", "963737476" },
                    { 4, "Paula.Lopes@iol.pt", "Paula Silva", "967517256" },
                    { 5, "Mariline.Martins@sapo.pt", "Mariline Marques", "967212144" },
                    { 6, "Marcos.Rocha@sapo.pt", "Marcos Rocha", "962125638" },
                    { 7, "Alexandre.Dias@hotmail.com", "Alexandre Vieira", "961493756" },
                    { 8, "Paula.Vieira@clix.pt", "Paula Soares", "961937768" },
                    { 9, "Mariline.Ribeiro@iol.pt", "Mariline Santos", "964106478" },
                    { 10, "Roberto.Vieira@sapo.pt", "Roberto Pinto", "964685937" }
                });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "Id", "Autor", "CategoriaFK", "FotoCapa", "ISBN", "Titulo" },
                values: new object[,]
                {
                    { 1, "Marisa Vieira", 1, null, null, "Aguia da Quinta do Conde" },
                    { 11, "Marisa Vieira", 3, null, null, "Garnet do Quintal de Cima" },
                    { 8, "Marisa Vieira", 3, null, null, "Forte da Flecha do Indio" },
                    { 10, "Marisa Vieira", 2, null, null, "Garfunkle da Quinta do Lordy" },
                    { 7, "Marisa Vieira", 2, null, null, "Gardenia da Tapada de Cima" },
                    { 9, "Marisa Vieira", 3, null, null, "Garbo da Flecha do Indio" },
                    { 5, "Marisa Vieira", 2, null, null, "Alabaster da Casa do Sobreiral" },
                    { 4, "Marisa Vieira", 2, null, null, "Albert do Canto do Bairro Pimenta" },
                    { 3, "Marisa Vieira", 1, null, null, "Aladim do Canto do Bairro Pimenta" },
                    { 2, "Marisa Vieira", 1, null, null, "Aileen da Quinta do Lordy" },
                    { 6, "Marisa Vieira", 2, null, null, "Gannett do Quintal de Cima" }
                });

            migrationBuilder.InsertData(
                table: "Requisicoes",
                columns: new[] { "Id", "Data", "DataDevol", "Multa", "NFunEnt", "NFunSaida", "RequesitanteFK" },
                values: new object[,]
                {
                    { 5, new DateTime(2019, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 1, 2, 0 },
                    { 1, new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 1, 1, 0 },
                    { 2, new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 1, 1, 0 },
                    { 3, new DateTime(2019, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 1, 1, 0 },
                    { 6, new DateTime(2013, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 1, 0, 0 },
                    { 8, new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 1, 0, 0 },
                    { 4, new DateTime(2021, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 2, 2, 0 },
                    { 7, new DateTime(2012, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 2, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "ReqLivros",
                columns: new[] { "Id", "LivroFK", "ReqFK" },
                values: new object[,]
                {
                    { 10, 5, 10 },
                    { 9, 10, 9 },
                    { 11, 8, 11 },
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 4, 3 },
                    { 6, 7, 6 },
                    { 8, 9, 8 },
                    { 4, 5, 4 },
                    { 5, 6, 5 },
                    { 7, 8, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livros_CategoriaFK",
                table: "Livros",
                column: "CategoriaFK");

            migrationBuilder.CreateIndex(
                name: "IX_ReqLivros_LivroFK",
                table: "ReqLivros",
                column: "LivroFK");

            migrationBuilder.CreateIndex(
                name: "IX_ReqLivros_ReqFK",
                table: "ReqLivros",
                column: "ReqFK");

            migrationBuilder.CreateIndex(
                name: "IX_Requisicoes_NFunEnt",
                table: "Requisicoes",
                column: "NFunEnt");

            migrationBuilder.CreateIndex(
                name: "IX_Requisicoes_NFunSaida",
                table: "Requisicoes",
                column: "NFunSaida");

            migrationBuilder.CreateIndex(
                name: "IX_Requisicoes_RequesitanteFK",
                table: "Requisicoes",
                column: "RequesitanteFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReqLivros");

            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Requisicoes");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Utilizadores");
        }
    }
}
