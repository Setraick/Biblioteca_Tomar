using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca_Tomar.Data.Migrations
{
    public partial class ApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Livros",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataRegisto",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Autor", "FotoCapa", "ISBN", "Titulo" },
                values: new object[] { "Filipe Melo", "Balada_para_Sophie.jpg", "9789897842825", "Balada para Sophie" });

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Autor", "FotoCapa", "ISBN", "Titulo" },
                values: new object[] { "Âncora Editora", "A_Minha_Terra_e_Linda.jpg", "9789727807673", "A Minha Terra é Linda" });

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Autor", "FotoCapa", "ISBN", "Titulo" },
                values: new object[] { "Hervé Le Tellier", "A_Anomalia.jpg", "9789722367165", "A Anomalia" });

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Autor", "FotoCapa", "ISBN", "Titulo" },
                values: new object[] { "João Tordo", "Aguas_Passadas.jpg", "9789897841071", "Águas Passadas" });

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Autor", "FotoCapa", "ISBN", "Titulo" },
                values: new object[] { "Louise Erdrich", "The_Night_Watchman.jpg", "9781472155368", "The Night Watchman" });

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Autor", "FotoCapa", "ISBN", "Titulo" },
                values: new object[] { "Cassandra Clare", "The_Last_Hours_Chain_of_Iron.jpg", "9781406358100", "The Last Hours: Chain of Iron" });

            migrationBuilder.UpdateData(
                table: "ReqLivros",
                keyColumn: "Id",
                keyValue: 6,
                column: "LivroFK",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ReqLivros",
                keyColumn: "Id",
                keyValue: 7,
                column: "LivroFK",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ReqLivros",
                keyColumn: "Id",
                keyValue: 8,
                column: "LivroFK",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ReqLivros",
                keyColumn: "Id",
                keyValue: 9,
                column: "LivroFK",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ReqLivros",
                keyColumn: "Id",
                keyValue: 10,
                column: "LivroFK",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ReqLivros",
                keyColumn: "Id",
                keyValue: 11,
                column: "LivroFK",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataRegisto",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Autor", "FotoCapa", "ISBN", "Titulo" },
                values: new object[] { "Marisa Vieira", "LivroCapa.jpg", "467-91231231", "Aguia da Quinta do Conde" });

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Autor", "FotoCapa", "ISBN", "Titulo" },
                values: new object[] { "Marisa Vieira", "LivroCapa.jpg", "456-91231231", "Aileen da Quinta do Lordy" });

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Autor", "FotoCapa", "ISBN", "Titulo" },
                values: new object[] { "Marisa Vieira", "LivroCapa.jpg", "456-81231231", "Aladim do Canto do Bairro Pimenta" });

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Autor", "FotoCapa", "ISBN", "Titulo" },
                values: new object[] { "Marisa Vieira", "LivroCapa.jpg", "456-91231231", "Albert do Canto do Bairro Pimenta" });

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Autor", "FotoCapa", "ISBN", "Titulo" },
                values: new object[] { "Marisa Vieira", "LivroCapa.jpg", "456-89231231", "Alabaster da Casa do Sobreiral" });

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Autor", "FotoCapa", "ISBN", "Titulo" },
                values: new object[] { "Marisa Vieira", "LivroCapa.jpg", "456-89123123", "Gannett do Quintal de Cima" });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "Id", "Autor", "CategoriaFK", "FotoCapa", "ISBN", "Titulo" },
                values: new object[,]
                {
                    { 7, "Marisa Vieira", 2, "LivroCapa.jpg", "567-94123131", "Gardenia da Tapada de Cima" },
                    { 8, "Marisa Vieira", 3, "LivroCapa.jpg", "456-89123121", "Forte da Flecha do Indio" },
                    { 9, "Marisa Vieira", 3, "LivroCapa.jpg", "456-89123231", "Garbo da Flecha do Indio" },
                    { 10, "Marisa Vieira", 2, "LivroCapa.jpg", "456-89131231", "Garfunkle da Quinta do Lordy" },
                    { 11, "Marisa Vieira", 3, "LivroCapa.jpg", "456-89231231", "Garnet do Quintal de Cima" }
                });

            migrationBuilder.UpdateData(
                table: "ReqLivros",
                keyColumn: "Id",
                keyValue: 10,
                column: "LivroFK",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ReqLivros",
                keyColumn: "Id",
                keyValue: 6,
                column: "LivroFK",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ReqLivros",
                keyColumn: "Id",
                keyValue: 7,
                column: "LivroFK",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ReqLivros",
                keyColumn: "Id",
                keyValue: 8,
                column: "LivroFK",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ReqLivros",
                keyColumn: "Id",
                keyValue: 9,
                column: "LivroFK",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ReqLivros",
                keyColumn: "Id",
                keyValue: 11,
                column: "LivroFK",
                value: 8);
        }
    }
}
