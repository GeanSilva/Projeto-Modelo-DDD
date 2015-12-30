using System.Collections.Generic;
using ProjectModeloDDD.Domain.Entidades;

namespace ProjectModeloDDD.Domain.Interfaces.Repositorio
{
  public interface IProdutoRepositorio : IRepositorio<Produto>
  {
      IEnumerable<Produto> BuscarPorNome(string nome);
  }
}
