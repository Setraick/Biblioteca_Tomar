using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca_Tomar.Models
{
    public class Requisicoes
    {
        public Requisicoes()
        {
            // inicializar a lista de Requisições
            ListaLivros = new HashSet<ReqLivros>();
        }
        /// <summary>
        /// Identificador de cada requesito
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// A referencia ao requisitante
        /// </summary>
        [ForeignKey(nameof(Requisitante))]
        [Display(Name = "Requisitante")]
        public int RequisitanteFK { get; set; }
        public Utilizadores Requisitante { get; set; }   // atributo para ser usado no C#. Representa a FK para o numero do Funcionário

        /// <summary>
        /// Referencia ao funcionario que entrega o livro
        /// </summary>
        [ForeignKey(nameof(FuncionarioInicioRequisicao))]
        [Display(Name = "Funcionário que criou a requisição")]
        public int FuncionarioInicioRequisicaoFK { get; set; }   // atributo para ser usado no SGBD e no C#. Representa a FK para o numero do Funcionário
        public Utilizadores FuncionarioInicioRequisicao { get; set; }   // atributo para ser usado no C#. Representa a FK para o numero do Funcionário

        /// <summary>
        /// Referencia ao funcionario que recebe o livro
        /// </summary>
        [ForeignKey(nameof(FuncionarioFimRequisicao))]
        [Display(Name = "Funcionário que terminou a requisição")]
        public int? FuncionarioFimRequisicaoFK { get; set; } // atributo para ser usado no SGBD e no C#. Representa a FK para o numero do Funcionário
        public Utilizadores FuncionarioFimRequisicao { get; set; }   // atributo para ser usado no C#. Representa a FK para o numero do Funcionário

        /// <summary>
        /// Data da requesiçao dos livros
        /// </summary>
        [Display(Name = "Data da requisição")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        /// <summary>
        /// Data limite da devolução para não apanhar multa
        /// </summary>
        [Display(Name = "Data da Devolução")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataDevol { get; set; }

        /// <summary>
        /// Multa já acumulada neste requesito
        /// </summary>
        public Decimal Multa { get; set; }

        public ICollection<ReqLivros> ListaLivros { get; set; }

    }
}
