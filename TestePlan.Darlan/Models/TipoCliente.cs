using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TestePlan.Darlan.Models
{
    public enum TipoCliente
    {
       [Description("Pessoa Juridica")]
        PessoaJuridica,
       [Description("Pessoa Fisica")]
        PessoaFisica
    }
}