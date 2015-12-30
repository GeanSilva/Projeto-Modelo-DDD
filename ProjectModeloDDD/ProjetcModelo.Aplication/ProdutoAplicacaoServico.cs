using System.Collections.Generic;
using ProjectModeloDDD.Domain.Entidades;
using ProjectModeloDDD.Domain.Interfaces.Servicos;
using ProjetcModelo.Aplication.Interface;

namespace ProjetcModelo.Aplication
{
    public class ProdutoAplicacaoServico : ServicoAplicacao<Produto>,IProdutoAplicacaoServico
    {
        private readonly IProdutoAplicacaoServico _produtoAplicacaoServico;
        public ProdutoAplicacaoServico(IServicosBase<Produto> servicosBase) 
            : base(servicosBase)
        {
            _produtoAplicacaoServico = servicosBase as IProdutoAplicacaoServico;
        }

        public void Dispose()
        {
            _produtoAplicacaoServico.Dispose();
        }

        public IEnumerable<Produto> BuscaPorProduto(string nome)
        {
            return _produtoAplicacaoServico.BuscaPorProduto(nome);
        }
    }
}