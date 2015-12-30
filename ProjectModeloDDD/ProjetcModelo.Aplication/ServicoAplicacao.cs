using System;
using System.Collections.Generic;
using ProjectModeloDDD.Domain.Interfaces.Servicos;
using ProjetcModelo.Aplication.Interface;

namespace ProjetcModelo.Aplication
{
    public class ServicoAplicacao<T> : IDisposable, IServicosBase<T> where T : class
    {
        private readonly IServicosBase<T> _servicosBase;

        public ServicoAplicacao(IServicosBase<T> servicosBase)
        {
            _servicosBase = servicosBase;
        }


        public void Adiciona(T obj)
        {
            _servicosBase.Adiciona(obj);
        }

        public T PegarPorId(int id)
        {
            return _servicosBase.PegarPorId(id);
        }

        public IEnumerable<T> PegaTodos()
        {
            return _servicosBase.PegaTodos();
        }

        public void Alterar(T obj)
        {
            _servicosBase.Alterar(obj);
        }

        public void Remove(T obj)
        {
            _servicosBase.Remove(obj);
        }

        void IServicosBase<T>.Dispose()
        {
             _servicosBase.Dispose();
        }

        void IDisposable.Dispose()
        {
            _servicosBase.Dispose();
        }
    }
}