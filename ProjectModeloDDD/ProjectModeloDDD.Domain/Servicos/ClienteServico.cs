using System.Collections.Generic;
using System.Linq;
using ProjectModeloDDD.Domain.Entidades;
using ProjectModeloDDD.Domain.Interfaces.Repositorio;
using ProjectModeloDDD.Domain.Interfaces.Servicos;

namespace ProjectModeloDDD.Domain.Servicos
{
    public class ClienteServico : ServicoBase<Cliente> ,IClienteServico
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteServico(IClienteRepositorio clienteRepositorio) 
            : base(clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> clientes)
        {
            return clientes.Where(c => c.ClienteEspecial(c));
        }
    }
}