﻿// <auto-generated />
using System;
using Biblioteca_Tomar.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Biblioteca_Tomar.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Biblioteca_Tomar.Models.Categorias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Designacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Seccao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Designacao = "Ação",
                            Seccao = 0
                        },
                        new
                        {
                            Id = 2,
                            Designacao = "Autobiografia",
                            Seccao = 0
                        },
                        new
                        {
                            Id = 3,
                            Designacao = "Artbook",
                            Seccao = 0
                        });
                });

            modelBuilder.Entity("Biblioteca_Tomar.Models.Livros", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("CategoriaFK")
                        .HasColumnType("int");

                    b.Property<string>("FotoCapa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaFK");

                    b.ToTable("Livros");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Autor = "Marisa Vieira",
                            CategoriaFK = 1,
                            Titulo = "Aguia da Quinta do Conde"
                        },
                        new
                        {
                            Id = 2,
                            Autor = "Marisa Vieira",
                            CategoriaFK = 1,
                            Titulo = "Aileen da Quinta do Lordy"
                        },
                        new
                        {
                            Id = 3,
                            Autor = "Marisa Vieira",
                            CategoriaFK = 1,
                            Titulo = "Aladim do Canto do Bairro Pimenta"
                        },
                        new
                        {
                            Id = 4,
                            Autor = "Marisa Vieira",
                            CategoriaFK = 2,
                            Titulo = "Albert do Canto do Bairro Pimenta"
                        },
                        new
                        {
                            Id = 5,
                            Autor = "Marisa Vieira",
                            CategoriaFK = 2,
                            Titulo = "Alabaster da Casa do Sobreiral"
                        },
                        new
                        {
                            Id = 6,
                            Autor = "Marisa Vieira",
                            CategoriaFK = 2,
                            Titulo = "Gannett do Quintal de Cima"
                        },
                        new
                        {
                            Id = 7,
                            Autor = "Marisa Vieira",
                            CategoriaFK = 2,
                            Titulo = "Gardenia da Tapada de Cima"
                        },
                        new
                        {
                            Id = 8,
                            Autor = "Marisa Vieira",
                            CategoriaFK = 3,
                            Titulo = "Forte da Flecha do Indio"
                        },
                        new
                        {
                            Id = 9,
                            Autor = "Marisa Vieira",
                            CategoriaFK = 3,
                            Titulo = "Garbo da Flecha do Indio"
                        },
                        new
                        {
                            Id = 10,
                            Autor = "Marisa Vieira",
                            CategoriaFK = 2,
                            Titulo = "Garfunkle da Quinta do Lordy"
                        },
                        new
                        {
                            Id = 11,
                            Autor = "Marisa Vieira",
                            CategoriaFK = 3,
                            Titulo = "Garnet do Quintal de Cima"
                        });
                });

            modelBuilder.Entity("Biblioteca_Tomar.Models.ReqLivros", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LivroFK")
                        .HasColumnType("int");

                    b.Property<int>("ReqFK")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LivroFK");

                    b.HasIndex("ReqFK");

                    b.ToTable("ReqLivros");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LivroFK = 1,
                            ReqFK = 1
                        },
                        new
                        {
                            Id = 2,
                            LivroFK = 2,
                            ReqFK = 2
                        },
                        new
                        {
                            Id = 3,
                            LivroFK = 4,
                            ReqFK = 3
                        },
                        new
                        {
                            Id = 4,
                            LivroFK = 5,
                            ReqFK = 4
                        },
                        new
                        {
                            Id = 5,
                            LivroFK = 6,
                            ReqFK = 5
                        },
                        new
                        {
                            Id = 6,
                            LivroFK = 7,
                            ReqFK = 6
                        },
                        new
                        {
                            Id = 7,
                            LivroFK = 8,
                            ReqFK = 7
                        },
                        new
                        {
                            Id = 8,
                            LivroFK = 9,
                            ReqFK = 8
                        },
                        new
                        {
                            Id = 9,
                            LivroFK = 10,
                            ReqFK = 8
                        },
                        new
                        {
                            Id = 10,
                            LivroFK = 5,
                            ReqFK = 1
                        },
                        new
                        {
                            Id = 11,
                            LivroFK = 8,
                            ReqFK = 5
                        });
                });

            modelBuilder.Entity("Biblioteca_Tomar.Models.Requisicoes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDevol")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FuncionarioFimRequisicaoFK")
                        .HasColumnType("int");

                    b.Property<int>("FuncionarioInicioRequisicaoFK")
                        .HasColumnType("int");

                    b.Property<decimal>("Multa")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RequisitanteFK")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioFimRequisicaoFK");

                    b.HasIndex("FuncionarioInicioRequisicaoFK");

                    b.HasIndex("RequisitanteFK");

                    b.ToTable("Requisicoes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Data = new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataDevol = new DateTime(2019, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FuncionarioFimRequisicaoFK = 1,
                            FuncionarioInicioRequisicaoFK = 1,
                            Multa = 0m,
                            RequisitanteFK = 5
                        },
                        new
                        {
                            Id = 2,
                            Data = new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataDevol = new DateTime(2019, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FuncionarioFimRequisicaoFK = 1,
                            FuncionarioInicioRequisicaoFK = 1,
                            Multa = 0m,
                            RequisitanteFK = 5
                        },
                        new
                        {
                            Id = 3,
                            Data = new DateTime(2019, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataDevol = new DateTime(2019, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FuncionarioFimRequisicaoFK = 1,
                            FuncionarioInicioRequisicaoFK = 1,
                            Multa = 0m,
                            RequisitanteFK = 7
                        },
                        new
                        {
                            Id = 4,
                            Data = new DateTime(2021, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataDevol = new DateTime(2021, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FuncionarioFimRequisicaoFK = 2,
                            FuncionarioInicioRequisicaoFK = 2,
                            Multa = 0m,
                            RequisitanteFK = 9
                        },
                        new
                        {
                            Id = 5,
                            Data = new DateTime(2019, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataDevol = new DateTime(2019, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FuncionarioFimRequisicaoFK = 2,
                            FuncionarioInicioRequisicaoFK = 1,
                            Multa = 0m,
                            RequisitanteFK = 5
                        },
                        new
                        {
                            Id = 6,
                            Data = new DateTime(2013, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataDevol = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FuncionarioInicioRequisicaoFK = 1,
                            Multa = 0m,
                            RequisitanteFK = 6
                        },
                        new
                        {
                            Id = 7,
                            Data = new DateTime(2012, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataDevol = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FuncionarioInicioRequisicaoFK = 2,
                            Multa = 0m,
                            RequisitanteFK = 7
                        },
                        new
                        {
                            Id = 8,
                            Data = new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataDevol = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FuncionarioInicioRequisicaoFK = 1,
                            Multa = 1m,
                            RequisitanteFK = 8
                        });
                });

            modelBuilder.Entity("Biblioteca_Tomar.Models.Utilizadores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Telemovel")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.HasKey("Id");

                    b.ToTable("Utilizadores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Marisa.Freitas@iol.pt",
                            Nome = "Marisa Vieira",
                            Telemovel = "967197885"
                        },
                        new
                        {
                            Id = 2,
                            Email = "Fátima.Machado@gmail.com",
                            Nome = "Fátima Ribeiro",
                            Telemovel = "963737476"
                        },
                        new
                        {
                            Id = 4,
                            Email = "Paula.Lopes@iol.pt",
                            Nome = "Paula Silva",
                            Telemovel = "967517256"
                        },
                        new
                        {
                            Id = 5,
                            Email = "Mariline.Martins@sapo.pt",
                            Nome = "Mariline Marques",
                            Telemovel = "967212144"
                        },
                        new
                        {
                            Id = 6,
                            Email = "Marcos.Rocha@sapo.pt",
                            Nome = "Marcos Rocha",
                            Telemovel = "962125638"
                        },
                        new
                        {
                            Id = 7,
                            Email = "Alexandre.Dias@hotmail.com",
                            Nome = "Alexandre Vieira",
                            Telemovel = "961493756"
                        },
                        new
                        {
                            Id = 8,
                            Email = "Paula.Vieira@clix.pt",
                            Nome = "Paula Soares",
                            Telemovel = "961937768"
                        },
                        new
                        {
                            Id = 9,
                            Email = "Mariline.Ribeiro@iol.pt",
                            Nome = "Mariline Santos",
                            Telemovel = "964106478"
                        },
                        new
                        {
                            Id = 10,
                            Email = "Roberto.Vieira@sapo.pt",
                            Nome = "Roberto Pinto",
                            Telemovel = "964685937"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Biblioteca_Tomar.Models.Livros", b =>
                {
                    b.HasOne("Biblioteca_Tomar.Models.Categorias", "Categoria")
                        .WithMany("ListaDeLivros")
                        .HasForeignKey("CategoriaFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Biblioteca_Tomar.Models.ReqLivros", b =>
                {
                    b.HasOne("Biblioteca_Tomar.Models.Livros", "Livro")
                        .WithMany("ListaRequisicoes")
                        .HasForeignKey("LivroFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca_Tomar.Models.Requisicoes", "Req")
                        .WithMany("ListaLivros")
                        .HasForeignKey("ReqFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Livro");

                    b.Navigation("Req");
                });

            modelBuilder.Entity("Biblioteca_Tomar.Models.Requisicoes", b =>
                {
                    b.HasOne("Biblioteca_Tomar.Models.Utilizadores", "FuncionarioFimRequisicao")
                        .WithMany()
                        .HasForeignKey("FuncionarioFimRequisicaoFK");

                    b.HasOne("Biblioteca_Tomar.Models.Utilizadores", "FuncionarioInicioRequisicao")
                        .WithMany()
                        .HasForeignKey("FuncionarioInicioRequisicaoFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca_Tomar.Models.Utilizadores", "Requisitante")
                        .WithMany()
                        .HasForeignKey("RequisitanteFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FuncionarioFimRequisicao");

                    b.Navigation("FuncionarioInicioRequisicao");

                    b.Navigation("Requisitante");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Biblioteca_Tomar.Models.Categorias", b =>
                {
                    b.Navigation("ListaDeLivros");
                });

            modelBuilder.Entity("Biblioteca_Tomar.Models.Livros", b =>
                {
                    b.Navigation("ListaRequisicoes");
                });

            modelBuilder.Entity("Biblioteca_Tomar.Models.Requisicoes", b =>
                {
                    b.Navigation("ListaLivros");
                });
#pragma warning restore 612, 618
        }
    }
}
