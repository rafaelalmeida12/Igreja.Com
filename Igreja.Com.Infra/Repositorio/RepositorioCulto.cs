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
    public class RepositorioCulto : RepositorioBase<Culto>, InterfaceCulto
    {
        private readonly DbContextOptions<Contexto> dbContextOptions;

        public RepositorioCulto()
        {
            this.dbContextOptions = new DbContextOptions<Contexto>();
        }

        public List<Culto> GetAll()
        {
            using (var busca = new Contexto(dbContextOptions))
            {
                return busca.Culto
                    .AsNoTracking()
                    .ToList();
            }
        }
    }
}
