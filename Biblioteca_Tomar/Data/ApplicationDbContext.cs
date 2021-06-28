using Biblioteca_Tomar.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Biblioteca_Tomar.Data
{
        /// <summary>
        /// classe para recolher os dados particulares dos utilizadores
        /// </summary>
        public class ApplicationUser : IdentityUser
        {
            //recolhe a data de registo de um utilizador
            public DateTime DataRegisto { get; set; }
        }
        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        { 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            // dados para definição dos roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "a", Name = "Admninistrador", NormalizedName = "ADMINISTRADOR" },
                new IdentityRole { Id = "u", Name = "Utilizador", NormalizedName = "UTILIZADOR" }
                );
           

            // insert DB seed

            ///dados para testes durante o desenvolvimento
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
               new Livros { Id = 1, FotoCapa = "Balada_para_Sophie.jpg", ISBN = "9789897842825", Titulo = "Balada para Sophie", Autor = "Filipe Melo", CategoriaFK = 1 },
               new Livros { Id = 2, FotoCapa = "A_Minha_Terra_e_Linda.jpg", ISBN = "9789727807673", Titulo = "A Minha Terra é Linda", Autor = "Âncora Editora", CategoriaFK = 1 },
               new Livros { Id = 3, FotoCapa = "A_Anomalia.jpg", ISBN = "9789722367165", Titulo = "A Anomalia", Autor = "Hervé Le Tellier", CategoriaFK = 1 },
               new Livros { Id = 4, FotoCapa = "Aguas_Passadas.jpg", ISBN = "9789897841071", Titulo = "Águas Passadas", Autor = "João Tordo", CategoriaFK = 2 },
               new Livros { Id = 5, FotoCapa = "The_Night_Watchman.jpg", ISBN = "9781472155368", Titulo = "The Night Watchman", Autor = "Louise Erdrich", CategoriaFK = 2 },
               new Livros { Id = 6, FotoCapa = "The_Last_Hours_Chain_of_Iron.jpg", ISBN = "9781406358100", Titulo = "The Last Hours: Chain of Iron", Autor = "Cassandra Clare", CategoriaFK = 2 }
            );

            modelBuilder.Entity<Requisicoes>().HasData(
               new Requisicoes { Id = 1, RequisitanteFK = 5, FuncionarioInicioRequisicaoFK = 1, FuncionarioFimRequisicaoFK = 1, Data = new DateTime(2019, 5, 20), DataDevol = new DateTime(2019, 5, 21), Multa = 0M },
               new Requisicoes { Id = 2, RequisitanteFK = 5, FuncionarioInicioRequisicaoFK = 1, FuncionarioFimRequisicaoFK = 1, Data = new DateTime(2019, 5, 20), DataDevol = new DateTime(2019, 5, 21), Multa = 0M },
               new Requisicoes { Id = 3, RequisitanteFK = 7, FuncionarioInicioRequisicaoFK = 1, FuncionarioFimRequisicaoFK = 1, Data = new DateTime(2019, 11, 18), DataDevol = new DateTime(2019, 11, 19), Multa = 0M },
               new Requisicoes { Id = 4, RequisitanteFK = 9, FuncionarioInicioRequisicaoFK = 2, FuncionarioFimRequisicaoFK = 2, Data = new DateTime(2021, 1, 17), DataDevol = new DateTime(2021, 1, 18), Multa = 0M },
               new Requisicoes { Id = 5, RequisitanteFK = 5, FuncionarioInicioRequisicaoFK = 1, FuncionarioFimRequisicaoFK = 2, Data = new DateTime(2019, 3, 7), DataDevol = new DateTime(2019, 3, 8), Multa = 0M },
               new Requisicoes { Id = 6, RequisitanteFK = 6, FuncionarioInicioRequisicaoFK = 1, Data = new DateTime(2013, 10, 21), Multa = 0M },
               new Requisicoes { Id = 7, RequisitanteFK = 7, FuncionarioInicioRequisicaoFK = 2, Data = new DateTime(2012, 10, 1), Multa = 0M },
               new Requisicoes { Id = 8, RequisitanteFK = 8, FuncionarioInicioRequisicaoFK = 1, Data = new DateTime(2020, 10, 1), Multa = 1M }
            );

            modelBuilder.Entity<ReqLivros>().HasData(
               new ReqLivros { Id = 1, ReqFK = 1, LivroFK = 1 },
               new ReqLivros { Id = 2, ReqFK = 2, LivroFK = 2 },
               new ReqLivros { Id = 3, ReqFK = 3, LivroFK = 4 },
               new ReqLivros { Id = 4, ReqFK = 4, LivroFK = 5 },
               new ReqLivros { Id = 5, ReqFK = 5, LivroFK = 6 },
               new ReqLivros { Id = 6, ReqFK = 6, LivroFK = 1 },
               new ReqLivros { Id = 7, ReqFK = 7, LivroFK = 3 },
               new ReqLivros { Id = 8, ReqFK = 8, LivroFK = 4 },
               new ReqLivros { Id = 9, ReqFK = 8, LivroFK = 5 },
               new ReqLivros { Id = 10, ReqFK = 1, LivroFK = 2 },
               new ReqLivros { Id = 11, ReqFK = 5, LivroFK = 3 }
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
