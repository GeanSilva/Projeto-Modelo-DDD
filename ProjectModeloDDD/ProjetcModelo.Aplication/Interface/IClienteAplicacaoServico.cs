using System.Collections.Generic;
using ProjectModeloDDD.Domain.Entidades;

namespace ProjetcModelo.Aplication.Interface
{
    public interface IClienteAplicacaoServico : IServicoAplicacaoBase<Cliente>
    {
        IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> clientes );
    }
}