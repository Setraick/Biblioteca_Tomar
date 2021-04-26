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
        /// A referencia ao requesitante
        /// </summary>
        [ForeignKey(nameof(Requesitante))]
        public int RequesitanteFK { get; set; }
        public Utilizadores Requesitante { get; set; }   // atributo para ser usado no C#. Representa a FK para o numero do Funcionário

        /// <summary>
        /// FK para guardar o  Num do Funcionário
        /// </summary>
        [ForeignKey(nameof(FunE))]  
        public int NFunEnt { get; set; }   // atributo para ser usado no SGBD e no C#. Representa a FK para o numero do Funcionário
        public Utilizadores FunE { get; set; }   // atributo para ser usado no C#. Representa a FK para o numero do Funcionário

        [ForeignKey(nameof(FunS))]
        public int NFunSaida { get; set; } // atributo para ser usado no SGBD e no C#. Representa a FK para o numero do Funcionário
        public Utilizadores FunS { get; set; }   // atributo para ser usado no C#. Representa a FK para o numero do Funcionário

        /// <summary>
        /// Data da requesiçao dos livros
        /// </summary>
        public DateTime Data { get; set; }

        /// <summary>
        /// Data limite da devolução para não apanhar multa
        /// </summary>
        public DateTime DataDevol { get; set; }

        /// <summary>
        /// Multa já acumulada neste requesito
        /// </summary>
        public Decimal Multa { get; set; }

        public ICollection<ReqLivros> ListaLivros { get; set; }

    }
}
