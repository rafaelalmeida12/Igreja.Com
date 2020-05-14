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
    public class RepositorioIgrejas : RepositorioBase<Igrejas>, InterfaceIgrejas
    {
        private readonly DbContextOptions<Contexto> dbContextOptions;
        public RepositorioIgrejas()
        {
            dbContextOptions = new DbContextOptions<Contexto>();
        }

        public IList<Igrejas> BuscarCedes()
        {
            using (var data = new Contexto(dbContextOptions))
            {
                return data.Igrejas
                    .Where(c => c.IgrejasId == null).ToList();
            }
        }

        public IList<Igrejas> BuscarFilialPorIgrejaID(int igrejasId)
        {
            using (var data = new Contexto(dbContextOptions))
            {
                return data.Igrejas
                    .Where(c => c.IgrejasId == igrejasId).ToList();
            }
        }
    }
}
