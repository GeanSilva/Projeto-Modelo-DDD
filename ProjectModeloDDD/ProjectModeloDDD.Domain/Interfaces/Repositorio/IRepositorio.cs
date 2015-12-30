
using System.Collections.Generic;

namespace ProjectModeloDDD.Domain.Interfaces.Repositorio
{
   public interface IRepositorio<T> where T : class
   {
       void Adiciona(T obj);
       T PegarPorId(int id);
       IEnumerable<T> PegaTodos();
       void Alterar(T obj);
       void Remove(T obj);
       void Dispose();
   }
}
