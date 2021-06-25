using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca_Tomar.Data.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requisicoes_Utilizadores_FuncionarioInicioRequisicaoFK",
                table: "Requisicoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Requisicoes_Utilizadores_RequisitanteFK",
                table: "Requisicoes");

            migrationBuilder.AlterColumn<long>(
                name: "ISBN",
                table: "Livros",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                    { 1, "Marisa Vieira", 1, "LivroCapa.jpg", 467891231231L, "Aguia da Quinta do Conde" },
                    { 11, "Marisa Vieira", 3, "LivroCapa.jpg", 456789231231L, "Garnet do Quintal de Cima" },
                    { 8, "Marisa Vieira", 3, "LivroCapa.jpg", 456789123121L, "Forte da Flecha do Indio" },
                    { 10, "Marisa Vieira", 2, "LivroCapa.jpg", 456789131231L, "Garfunkle da Quinta do Lordy" },
                    { 7, "Marisa Vieira", 2, "LivroCapa.jpg", 567894123131L, "Gardenia da Tapada de Cima" },
                    { 9, "Marisa Vieira", 3, "LivroCapa.jpg", 456789123231L, "Garbo da Flecha do Indio" },
                    { 5, "Marisa Vieira", 2, "LivroCapa.jpg", 456789231231L, "Alabaster da Casa do Sobreiral" },
                    { 4, "Marisa Vieira", 2, "LivroCapa.jpg", 456891231231L, "Albert do Canto do Bairro Pimenta" },
                    { 3, "Marisa Vieira", 1, "LivroCapa.jpg", 456781231231L, "Aladim do Canto do Bairro Pimenta" },
                    { 2, "Marisa Vieira", 1, "LivroCapa.jpg", 456891231231L, "Aileen da Quinta do Lordy" },
                    { 6, "Marisa Vieira", 2, "LivroCapa.jpg", 456789123123L, "Gannett do Quintal de Cima" }
                });

            migrationBuilder.InsertData(
                table: "Requisicoes",
                columns: new[] { "Id", "Data", "DataDevol", "FuncionarioFimRequisicaoFK", "FuncionarioInicioRequisicaoFK", "Multa", "RequisitanteFK" },
                values: new object[,]
                {
                    { 8, new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1m, 8 },
                    { 1, new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 0m, 5 },
                    { 2, new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 0m, 5 },
                    { 5, new DateTime(2019, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 0m, 5 },
                    { 6, new DateTime(2013, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 0m, 6 },
                    { 3, new DateTime(2019, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 0m, 7 },
                    { 7, new DateTime(2012, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 0m, 7 },
                    { 4, new DateTime(2021, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 0m, 9 }
                });

            migrationBuilder.InsertData(
                table: "ReqLivros",
                columns: new[] { "Id", "LivroFK", "ReqFK" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 10, 5, 1 },
                    { 2, 2, 2 },
                    { 5, 6, 5 },
                    { 11, 8, 5 },
                    { 6, 7, 6 },
                    { 3, 4, 3 },
                    { 7, 8, 7 },
                    { 8, 9, 8 },
                    { 9, 10, 8 },
                    { 4, 5, 4 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Requisicoes_Utilizadores_FuncionarioInicioRequisicaoFK",
                table: "Requisicoes",
                column: "FuncionarioInicioRequisicaoFK",
                principalTable: "Utilizadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requisicoes_Utilizadores_RequisitanteFK",
                table: "Requisicoes",
                column: "RequisitanteFK",
                principalTable: "Utilizadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requisicoes_Utilizadores_FuncionarioInicioRequisicaoFK",
                table: "Requisicoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Requisicoes_Utilizadores_RequisitanteFK",
                table: "Requisicoes");

            migrationBuilder.DeleteData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ReqLivros",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReqLivros",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ReqLivros",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ReqLivros",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ReqLivros",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ReqLivros",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ReqLivros",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ReqLivros",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ReqLivros",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ReqLivros",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ReqLivros",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Requisicoes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Requisicoes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Requisicoes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Requisicoes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Requisicoes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Requisicoes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Requisicoes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Requisicoes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Livros",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Requisicoes_Utilizadores_FuncionarioInicioRequisicaoFK",
                table: "Requisicoes",
                column: "FuncionarioInicioRequisicaoFK",
                principalTable: "Utilizadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requisicoes_Utilizadores_RequisitanteFK",
                table: "Requisicoes",
                column: "RequisitanteFK",
                principalTable: "Utilizadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
