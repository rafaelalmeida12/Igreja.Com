using Igreja.Com.Dominio.Interface;
using Igreja.Com.Infra.Configuracao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Igreja.Com.Infra.Repositorio
{
    public class RepositorioBase<T> : InterfaceBase<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<Contexto> optionsBuilder;

        public RepositorioBase()
        {
            optionsBuilder = new DbContextOptions<Contexto>();
        }

        public void Add(T Objeto)
        {
            using (var data = new Contexto(optionsBuilder))
            {
                data.Set<T>().Add(Objeto);
                data.SaveChanges();
            }
        }

        public int AddRetorno(T Objeto)
        {

            using (var data = new Contexto(optionsBuilder))
            {
               data.Set<T>().Add(Objeto);
              return data.SaveChanges();
            }
        }

        public void Delete(T Objeto)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T GetEntityById(int Id)
        {
            using (var data = new Contexto(optionsBuilder))
            {
                return data.Set<T>()
                    .Find(Id);
            }
        }

        public List<T> List()
        {
            using (var data = new Contexto(optionsBuilder))
            {
                return data.Set<T>()
                    .AsNoTracking()
                    .ToList();
            }
        }

        public List<T> ListAsync()
        {
            using (var data = new Contexto(optionsBuilder))
            {
                return data.Set<T>()
                    .AsNoTracking()
                    .ToList();
            }
        }

        public void Update(T Objeto)
        {
            using (var banco = new Contexto(optionsBuilder))
            {
                banco.Set<T>().Update(Objeto);
                banco.SaveChanges();
            }
        }
    }
}
