

using System.Collections.Generic;
using System.Linq;
using ProjectModeloDDD.Domain.Entidades;
using ProjectModeloDDD.Domain.Interfaces;
using ProjectModeloDDD.Domain.Interfaces.Repositorio;

namespace ProjectModelo.Infra.Repositorios
{
    public class ProdutoRepositorio : Repositorio<Produto>, IProdutoRepositorio
    {

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return DbContexto.Produtos.Where(p => p.Nome == nome);
        }
    }
}

