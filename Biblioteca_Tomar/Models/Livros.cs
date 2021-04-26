using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca_Tomar.Models
{
    public class Livros
    {
        /// <summary>
        /// Identificador de cada Livro
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// FK para a Raça do Cão
        /// </summary>
        [ForeignKey("Cate")] 
        public int CategoriaFK { get; set; }   // atributo para ser usado no SGBD e no C#. Representa a FK para a Raça do cão
        public Categorias Cate { get; set; }   // atributo para ser usado no C#. Representa a FK para a Raça do cão


        [Required(ErrorMessage = "O Autor é de preenchimento obrigatório")]
        [StringLength(60, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        public string Autor { get; set; }

        /// <summary>
        /// FK para o Requesito
        /// </summary>
        [ForeignKey("Req")]
        public int ReqFK { get; set; }
        public Requesitos Req { get; set; }

    }
}
