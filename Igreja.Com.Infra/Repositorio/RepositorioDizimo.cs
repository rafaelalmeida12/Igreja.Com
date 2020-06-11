using Igreja.Com.Dominio.Entidades;
using Igreja.Com.Dominio.Interface;
using Igreja.Com.Infra.Configuracao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Igreja.Com.Infra.Repositorio
{
    public class RepositorioDizimo : RepositorioBase<Dizimo>, InterfaceDizimo
    {
        private readonly DbContextOptions<Contexto> dbContextOptions;

        public RepositorioDizimo()
        {
            this.dbContextOptions = new DbContextOptions<Contexto>();
        }

        public List<Dizimo> ListDizimo()
        {
            using (var data = new Contexto(dbContextOptions))
            {
                return data.Set<Dizimo>()
                    .AsNoTracking()
                    .Include(c => c.Membro)
                    .ToList();
            }
        }

        public int AddRetornoDizimo(Dizimo Objeto)
        {

            using (var data = new Contexto(dbContextOptions))
            {
                data.Dizimo.Add(Objeto);
                data.SaveChanges();

                int id = Objeto.Id;
                return id;
            }
        }


    }
}
