using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestePlan.Darlan.Models
{
    public class Cliente
    {
        [Key]
        public int IDCliente { get; set; } 
        [Required]
        public string Nome { get; set; }
        /// <summary>
        /// Tipo do cliente que defini o numero de documento
        /// </summary>

        [Required]
        public TipoCliente TipoCliente { get; set; }
        /// <summary>
        /// numero do documento quando é pessoal Jurídica
        /// </summary>
        
        public string DocumentoCNPJ { get; set ; }
        /// <summary>
        /// numero do documento quando é pessoal física
        /// </summary>
        
        public string DocumentoCPF { get; set; }
        /// <summary>
        /// Dada inical de cadastro
        /// </summary>
        public DateTime DataCadastro { get; set; }

        public bool Inativo { get; set; }

       
    }

}