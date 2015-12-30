using System.Collections.Generic;
using ProjectModeloDDD.Domain.Entidades;

namespace ProjectModeloDDD.Domain.Interfaces.Servicos
{
    public interface IClienteServico  : IServicosBase<Cliente>
    {
        IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> clientes);
    }
}
