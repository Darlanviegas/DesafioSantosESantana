using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestePlan.Darlan.Models
{
    public class ClienteViewModel
    {

        public ClienteViewModel(string nome, TipoCliente tipoCliente, DateTime dateTime)
        {
            this.Nome = nome;
            this.TipoCliente = tipoCliente;
            this.DataCadastro = dateTime;
            this.Inativo = false;
        }

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
        public string DocumentoCNPJ { get; private set; }
        /// <summary>
        /// numero do documento quando é pessoal física
        /// </summary>
        public string DocumentoCPF { get; private set; }
        /// <summary>
        /// Dada inical de cadastro
        /// </summary>
        public DateTime DataCadastro { get; private set; }

        public bool Inativo { get; set; }

        /// <summary>
        /// Insere o numero de documento
        /// </summary>
        /// <param name="numeroDocumento"></param>
        public void InserirDocumento(string numeroDocumento)
        {
            if (TipoCliente == TipoCliente.PessoaFisica)
                if (!ValidaCPF(numeroDocumento))
                    throw new ArgumentException(numeroDocumento + " não é um CPF válido");

        }
        /// <summary>
        /// Remove caracteres não numéricos
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static string RemoveNaoNumericos(string text)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"[^0-9]");
            string ret = reg.Replace(text, string.Empty);
            return ret;
        }

        /// <summary>
        /// Valida se um cpf é válido
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        private static bool ValidaCPF(string cpf)
        {
            //Remove formatação do número, ex: "123.456.789-01" vira: "12345678901"
            cpf = RemoveNaoNumericos(cpf);

            if (cpf.Length > 11)
                return false;

            while (cpf.Length != 11)
                cpf = '0' + cpf;

            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (cpf[i] != cpf[0])
                    igual = false;

            if (igual || cpf == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(cpf[i].ToString());

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
                if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }
    }


}