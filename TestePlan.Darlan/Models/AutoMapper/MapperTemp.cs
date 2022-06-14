using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestePlan.Darlan.Models.ViewModels;

namespace TestePlan.Darlan.Models.AutoMapper
{
    public class MapperTemp
    {

        public static Cliente MapeamentoView_EntidadeCliente(ClienteViewModel clienteViewModel)
        {
            var cliente = new Cliente();
            cliente.IDCliente = clienteViewModel.IDCliente;
            cliente.Nome = clienteViewModel.Nome;
            cliente.TipoCliente = clienteViewModel.TipoCliente;
            cliente.Inativo = clienteViewModel.Inativo;
            if (clienteViewModel.TipoCliente == TipoCliente.PessoaJuridica)
            {
                cliente.DocumentoCNPJ = clienteViewModel.Documento;
            }
            else
            {
                cliente.DocumentoCPF = clienteViewModel.Documento;

            }
            cliente.DataCadastro = clienteViewModel.DataCadastro;
            return cliente;
        }

        public static ClienteViewModel MapeamentoEntidade_ViewCliente(Cliente clienteEntity)
        {
            var cliente = new ClienteViewModel();
            cliente.IDCliente = clienteEntity.IDCliente;
            cliente.Nome = clienteEntity.Nome;
            cliente.TipoCliente = clienteEntity.TipoCliente;
            cliente.Documento = clienteEntity.TipoCliente == TipoCliente.PessoaJuridica ? clienteEntity.DocumentoCNPJ : clienteEntity.DocumentoCPF;
            cliente.DataCadastro = clienteEntity.DataCadastro;
            return cliente;
        }
     

    }
}