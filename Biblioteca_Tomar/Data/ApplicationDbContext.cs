using Biblioteca_Tomar.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Tomar.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            // insert DB seed

            modelBuilder.Entity<Categorias>().HasData(
               new Categorias { Id = 1, Designacao = "Ação" },
               new Categorias { Id = 2, Designacao = "Autobiografia" },
               new Categorias { Id = 3, Designacao = "Artbook" }
            );

            modelBuilder.Entity<Utilizadores>().HasData(
               new Utilizadores { Id = 1, Nome = "Marisa Vieira", Email = "Marisa.Freitas@iol.pt", Telemovel = "967197885" },
               new Utilizadores { Id = 2, Nome = "Fátima Ribeiro", Email = "Fátima.Machado@gmail.com", Telemovel = "963737476" },
               new Utilizadores { Id = 4, Nome = "Paula Silva", Email = "Paula.Lopes@iol.pt", Telemovel = "967517256" },
               new Utilizadores { Id = 5, Nome = "Mariline Marques", Email = "Mariline.Martins@sapo.pt", Telemovel = "967212144" },
               new Utilizadores { Id = 6, Nome = "Marcos Rocha", Email = "Marcos.Rocha@sapo.pt", Telemovel = "962125638" },
               new Utilizadores { Id = 7, Nome = "Alexandre Vieira", Email = "Alexandre.Dias@hotmail.com", Telemovel = "961493756" },
               new Utilizadores { Id = 8, Nome = "Paula Soares", Email = "Paula.Vieira@clix.pt", Telemovel = "961937768" },
               new Utilizadores { Id = 9, Nome = "Mariline Santos", Email = "Mariline.Ribeiro@iol.pt", Telemovel = "964106478" },
               new Utilizadores { Id = 10, Nome = "Roberto Pinto", Email = "Roberto.Vieira@sapo.pt", Telemovel = "964685937" }
            );

            modelBuilder.Entity<Livros>().HasData(
               new Livros { Id = 1, Titulo = "Aguia da Quinta do Conde", Autor = "Marisa Vieira", CategoriaFK = 1 },
               new Livros { Id = 2, Titulo = "Aileen da Quinta do Lordy", Autor = "Marisa Vieira", CategoriaFK = 1 },
               new Livros { Id = 3, Titulo = "Aladim do Canto do Bairro Pimenta", Autor = "Marisa Vieira", CategoriaFK = 1 },
               new Livros { Id = 4, Titulo = "Albert do Canto do Bairro Pimenta", Autor = "Marisa Vieira", CategoriaFK = 2 },
               new Livros { Id = 5, Titulo = "Alabaster da Casa do Sobreiral", Autor = "Marisa Vieira", CategoriaFK = 2 },
               new Livros { Id = 6, Titulo = "Gannett do Quintal de Cima", Autor = "Marisa Vieira", CategoriaFK = 2 },
               new Livros { Id = 7, Titulo = "Gardenia da Tapada de Cima", Autor = "Marisa Vieira", CategoriaFK = 2 },
               new Livros { Id = 8, Titulo = "Forte da Flecha do Indio", Autor = "Marisa Vieira", CategoriaFK = 3 },
               new Livros { Id = 9, Titulo = "Garbo da Flecha do Indio", Autor = "Marisa Vieira", CategoriaFK = 3 },
               new Livros { Id = 10, Titulo = "Garfunkle da Quinta do Lordy", Autor = "Marisa Vieira", CategoriaFK = 2 },
               new Livros { Id = 11, Titulo = "Garnet do Quintal de Cima", Autor = "Marisa Vieira", CategoriaFK = 3 }
            );

            modelBuilder.Entity<Requisicoes>().HasData(
               new Requisicoes { Id = 1, NFunEnt = 1, NFunSaida = 1, Data = new DateTime(2019, 5, 20), DataDevol = new DateTime(2019, 5, 21), Multa = 0M },
               new Requisicoes { Id = 2, NFunEnt = 1, NFunSaida = 1, Data = new DateTime(2019, 5, 20), DataDevol = new DateTime(2019, 5, 21), Multa = 0M },
               new Requisicoes { Id = 3, NFunEnt = 1, NFunSaida = 1, Data = new DateTime(2019, 11, 18), DataDevol = new DateTime(2019, 11, 19), Multa = 0M },
               new Requisicoes { Id = 4, NFunEnt = 2, NFunSaida = 2, Data = new DateTime(2021, 1, 17), DataDevol = new DateTime(2021, 1, 18), Multa = 0M },
               new Requisicoes { Id = 5, NFunEnt = 1, NFunSaida = 2, Data = new DateTime(2019, 3, 7), DataDevol = new DateTime(2019, 3, 8), Multa = 0M },
               new Requisicoes { Id = 6, NFunEnt = 1, Data = new DateTime(2013, 10, 21), Multa = 0M },
               new Requisicoes { Id = 7, NFunEnt = 2, Data = new DateTime(2012, 10, 1), Multa = 0M },
               new Requisicoes { Id = 8, NFunEnt = 1, Data = new DateTime(2020, 10, 1), Multa = 1M }
            );

            modelBuilder.Entity<ReqLivros>().HasData(
               new ReqLivros { Id = 1, ReqFK = 1, LivroFK = 1 },
               new ReqLivros { Id = 2, ReqFK = 2, LivroFK = 2 },
               new ReqLivros { Id = 3, ReqFK = 3, LivroFK = 4 },
               new ReqLivros { Id = 4, ReqFK = 4, LivroFK = 5 },
               new ReqLivros { Id = 5, ReqFK = 5, LivroFK = 6 },
               new ReqLivros { Id = 6, ReqFK = 6, LivroFK = 7 },
               new ReqLivros { Id = 7, ReqFK = 7, LivroFK = 8 },
               new ReqLivros { Id = 8, ReqFK = 8, LivroFK = 9 },
               new ReqLivros { Id = 9, ReqFK = 9, LivroFK = 10 },
               new ReqLivros { Id = 10, ReqFK = 10, LivroFK = 5 },
               new ReqLivros { Id = 11, ReqFK = 11, LivroFK = 8 }
            );

        }
        //Representar as Tabelas da BD
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Utilizadores> Utilizadores { get; set; }
        public DbSet<Livros> Livros { get; set; }
        public DbSet<Requisicoes> Requisicoes { get; set; }
        public DbSet<ReqLivros> ReqLivros { get; set; }




    }
}
