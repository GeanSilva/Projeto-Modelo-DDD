

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProjectModelo.Infra.Contexto;
using ProjectModeloDDD.Domain.Interfaces.Repositorio;

namespace ProjectModelo.Infra.Repositorios
{
    public class Repositorio<T> : IDisposable, IRepositorio<T> where T : class
    {
        protected ProjectModeloContexto DbContexto = new ProjectModeloContexto();
        public void Adiciona(T obj)
        {
            DbContexto.Set<T>().Add(obj);
            DbContexto.SaveChanges();
        }

        public void Alterar(T obj)
        {
            DbContexto.Entry(obj).State = EntityState.Modified;
            DbContexto.SaveChanges();
        }

        public void Dispose()
        {
           DbContexto.Dispose();
        }

        public T PegarPorId(int id)
        {
            return DbContexto.Set<T>().Find(id);
        }

        public IEnumerable<T> PegaTodos()
        {
            return DbContexto.Set<T>().ToList();
        }

        public void Remove(T obj)
        {
            DbContexto.Set<T>().Remove(obj);
            DbContexto.SaveChanges();
        }
    }
}
