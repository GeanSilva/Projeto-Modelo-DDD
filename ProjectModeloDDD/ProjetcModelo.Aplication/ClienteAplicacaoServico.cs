using System.Collections.Generic;
using ProjectModeloDDD.Domain.Entidades;
using ProjectModeloDDD.Domain.Interfaces.Servicos;
using ProjetcModelo.Aplication.Interface;

namespace ProjetcModelo.Aplication
{
    public class ClienteAplicacaoServico : ServicoAplicacao<Cliente>,IClienteAplicacaoServico
    {
        private readonly IClienteAplicacaoServico _clienteAplicacaoServico;
        public ClienteAplicacaoServico(IServicosBase<Cliente> servicosBase) 
            : base(servicosBase)
        {
            _clienteAplicacaoServico = servicosBase as IClienteAplicacaoServico;
        }

        public void Dispose()
        {
            _clienteAplicacaoServico.Dispose();
        }

        public IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> clientes)
        {
            return _clienteAplicacaoServico.ObterClientesEspeciais(_clienteAplicacaoServico.PegaTodos());
        }
    }
}