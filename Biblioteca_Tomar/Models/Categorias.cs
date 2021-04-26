using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca_Tomar.Models
{
    public class Categorias
    {
        public Categorias()
        {
            ListaDeLivros = new HashSet<Livros>();
        }

        /// <summary>
        /// Identificador de cada uma das Categorias
        /// </summary>
        [Key] 
        public int Id { get; set; }

        /// <summary>
        /// identifica o nome da categoria
        /// </summary>
        public string Designacao { get; set; }

        /// <summary>
        /// Secção ou estante em que a categoria está colocada 
        /// </summary>
        public int Seccao { get; set; }

        /// <summary>
        /// Lista dos Livros que são da Categoria
        /// </summary>
        public ICollection<Livros> ListaDeLivros { get; set; }

    }
}
