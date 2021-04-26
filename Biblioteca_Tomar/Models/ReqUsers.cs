using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca_Tomar.Models
{
    public class ReqUsers
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
        public Requesitos Req { get; set; }


        /// <summary>
        /// FK para o User
        /// </summary>
        [ForeignKey("User")]  
        public int UserFK { get; set; }
        public Users User { get; set; }

    }
}
