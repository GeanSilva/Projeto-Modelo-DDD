using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using ProjectModeloDDD.Domain.Entidades;
using ProjectModeloDDD.Domain.Interfaces.Repositorio;
using ProjectModeloDDD.Domain.Interfaces.Servicos;

namespace ProjectModeloDDD.Domain.Servicos
{
    public class ProdutoSevico : ServicoBase<Produto>, IProdutoServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutoSevico(IProdutoRepositorio produtoRepositorio) 
            : base(produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public IEnumerable<Produto> BuscarPorProduto(string nome)
        {
            return _produtoRepositorio.BuscarPorNome(nome);
        }
    }
}