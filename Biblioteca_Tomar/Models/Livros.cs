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
        public Livros()
        {
            // inicializar a lista de Requisições
            ListaRequisicoes = new HashSet<ReqLivros>();
        }
        /// <summary>
        /// Identificador de cada Livro
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome do utilizador
        /// </summary>
        [Required(ErrorMessage = "O Titulo é de preenchimento obrigatório")]
        [StringLength(60, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        public string Titulo { get; set; }

        /// <summary>
        /// FK para a Categoria do livro
        /// </summary>
        [ForeignKey("Categoria")]
        [Display(Name = "Categorias")]
        public int CategoriaFK { get; set; }   // atributo para ser usado no SGBD e no C#. Representa a FK para a Raça do cão
        public Categorias Categoria { get; set; }   // atributo para ser usado no C#. Representa a FK para a Raça do cão

        /// <summary>
        /// Nome do Autor
        /// </summary>
        [Required(ErrorMessage = "O Autor é de preenchimento obrigatório")]
        [StringLength(60, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        public string Autor { get; set; }

        /// <summary>
        /// O numero internacional do livro
        /// </summary>
        [Required(ErrorMessage = "O ISBM é de preenchimento obrigatório")]
        [RegularExpression("[0-9Xx-]{9,13}", ErrorMessage = "Escreva, por favor, um nº entre 9 a 13 digitos. ")]
        public string ISBN { get; set; }

        /// <summary>
        /// A foto da capa
        /// </summary>
        [Display(Name = "Foto da capa")]
        public String FotoCapa { get; set; }

        public ICollection<ReqLivros> ListaRequisicoes { get; set; }

    }
}
