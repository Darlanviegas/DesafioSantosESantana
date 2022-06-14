using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TestePlan.Darlan.Helper;

namespace TestePlan.Darlan.Models.ViewModels
{
    public class ClienteViewModel
    {
     /// <summary>
     /// id do cliente
     /// </summary>
        public int IDCliente { get; set; }

        /// <summary>
        /// nome do cliente
        /// </summary>

        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// Tipo do cliente que defini o numero de documento
        /// </summary>

        [Required]
        public TipoCliente TipoCliente { get; set; }

        /// <summary>
        /// Numero do documento 
        /// </summary>
        [Required]
        public string Documento { get; set; }

        /// <summary>
        /// Dada inicial de cadastro
        /// </summary>
        [Required]
        public DateTime DataCadastro { get; set; }
        /// <summary>
        /// Cliente está inativo
        /// </summary>
        public bool Inativo { get; set; }
        /// <summary>
        /// Valida documento
        /// </summary>
        /// <returns>retorna se é um numero de documento valido</returns>
        public bool ValidarDocumento()
        {
            ValidarDocumentoCNPJ();
            ValidarDocumentoCPF();
            if (MensagemErro.Any())
            {
                return false;
            }
            return true;

        }

        /// <summary>
        /// Valida se o documento é um CPF Válido
        /// </summary>
        private void ValidarDocumentoCPF()
        {
            MensagemErro = new List<string>();
            if (this.Documento == null)
            {
                MensagemErro.Add("Documento não pode ser nulo.");
            }
            if (TipoCliente != TipoCliente.PessoaFisica)
            {
                MensagemErro.Add("Para inserir um CPF é necessário ser tipo pessoa física.");
            }
            if (!CpfCnpjUtils.IsValidCNPJ(this.Documento))
            {
                MensagemErro.Add("Numero de Documento Inválido");
            }
            Documento = this.Documento;

        }
        /// <summary>
        /// Valida se é um documento de CNPJ valido
        /// </summary>

        private void ValidarDocumentoCNPJ()
        {
            MensagemErro = new List<string>();
            if (this.Documento == null)
            {
                MensagemErro.Add("Documento não pode ser nulo.");
            }
            if (TipoCliente != TipoCliente.PessoaJuridica)
            {
                MensagemErro.Add("Para inserir um CNPJ é necessário ser tipo pessoa Jurídica.");
            }

            if (!CpfCnpjUtils.IsValidCNPJ(this.Documento))
            {
                MensagemErro.Add("Numero de Documento Inválido");
            }
            Documento = this.Documento;

        }
        /// <summary>
        /// Lista os erros
        /// </summary>
        public List<string> MensagemErro { get; private set; }

    }


}