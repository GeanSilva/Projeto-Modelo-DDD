using System;
using System.Collections.Generic;
using ProjectModeloDDD.Domain.Interfaces.Repositorio;
using ProjectModeloDDD.Domain.Interfaces.Servicos;

namespace ProjectModeloDDD.Domain.Servicos
{
    public class ServicoBase<T> :IDisposable,IServicosBase<T> where T : class
    {
        private readonly IRepositorio<T> _repositorio;

        public ServicoBase(IRepositorio<T> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Adiciona(T obj)
        {
           _repositorio.Adiciona(obj);
        }

        public T PegarPorId(int id)
        {
           return _repositorio.PegarPorId(id);
        }

        public IEnumerable<T> PegaTodos()
        {
           return _repositorio.PegaTodos();
        }

        public void Alterar(T obj)
        {
            _repositorio.Alterar(obj);
        }

        public void Remove(T obj)
        {
            _repositorio.Remove(obj);
        }

        void IServicosBase<T>.Dispose()
        {
            _repositorio.Dispose();
        }

        void IDisposable.Dispose()
        {
            _repositorio.Dispose();
        }
    }
}