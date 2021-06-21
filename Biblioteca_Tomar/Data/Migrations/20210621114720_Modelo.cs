using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca_Tomar.Data.Migrations
{
    public partial class Modelo : Migration
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
                    RequisitanteFK = table.Column<int>(type: "int", nullable: false),
                    FuncionarioInicioRequisicaoFK = table.Column<int>(type: "int", nullable: false),
                    FuncionarioFimRequisicaoFK = table.Column<int>(type: "int", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDevol = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Multa = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisicoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requisicoes_Utilizadores_FuncionarioFimRequisicaoFK",
                        column: x => x.FuncionarioFimRequisicaoFK,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requisicoes_Utilizadores_FuncionarioInicioRequisicaoFK",
                        column: x => x.FuncionarioInicioRequisicaoFK,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requisicoes_Utilizadores_RequisitanteFK",
                        column: x => x.RequisitanteFK,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Requisicoes_FuncionarioFimRequisicaoFK",
                table: "Requisicoes",
                column: "FuncionarioFimRequisicaoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Requisicoes_FuncionarioInicioRequisicaoFK",
                table: "Requisicoes",
                column: "FuncionarioInicioRequisicaoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Requisicoes_RequisitanteFK",
                table: "Requisicoes",
                column: "RequisitanteFK");
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
