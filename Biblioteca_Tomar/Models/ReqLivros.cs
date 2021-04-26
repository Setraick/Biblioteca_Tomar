using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca_Tomar.Models
{
    public class ReqLivros
    {
        /// <summary>
        /// PK para a tabela do relacionamento entre Requesitos e Users
        /// </summary>
        [Key]
        public int Id { get; set; }

        //*************************************************************

        /// <summary>
        /// FK para o Requesito
        /// </summary>
        [ForeignKey("Req")]
        public int ReqFK { get; set; }
        public Requisicoes Req { get; set; }


        /// <summary>
        /// FK para o Livro
        /// </summary>
        [ForeignKey("Livro")]  
        public int LivroFK { get; set; }
        public Livros Livro { get; set; }

    }
}
