using System.Collections.Generic;

namespace ProjectModeloDDD.Domain.Interfaces.Servicos
{
    public interface IServicosBase<T> where T : class 
    {
        void Adiciona(T obj);
        T PegarPorId(int id);
        IEnumerable<T> PegaTodos();
        void Alterar(T obj);
        void Remove(T obj);
        void Dispose();
    }
}