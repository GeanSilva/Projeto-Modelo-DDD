using System.Collections.Generic;
using ProjectModeloDDD.Domain.Entidades;

namespace ProjetcModelo.Aplication.Interface
{
    public interface IProdutoAplicacaoServico: IServicoAplicacaoBase<Produto>
    {
        IEnumerable<Produto> BuscaPorProduto(string nome);
    }
}