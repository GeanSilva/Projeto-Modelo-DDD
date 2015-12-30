using System.Collections.Generic;
using ProjectModeloDDD.Domain.Entidades;

namespace ProjectModeloDDD.Domain.Interfaces.Servicos
{
    public interface IProdutoServico : IServicosBase<Produto>
    {
        IEnumerable<Produto> BuscarPorProduto(string nome);
    }
}