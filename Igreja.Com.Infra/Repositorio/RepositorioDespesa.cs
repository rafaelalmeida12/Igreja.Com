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
    public class RepositorioDespesa : RepositorioBase<Despesa>, InterfaceDespesa
    {
        private readonly DbContextOptions<Contexto> dbContextOptions;
        public RepositorioDespesa()
        {
            dbContextOptions = new DbContextOptions<Contexto>();
        }

        public int AddRetornoDespesa(Despesa Objeto)
        {
            using (var data = new Contexto(dbContextOptions))
            {
                data.Despesa.Add(Objeto);
                data.SaveChanges();

                int id = Objeto.Id;
                return id;
            }
        }

        public decimal CalculaSaldo()
        {
            using (var busca = new Contexto(dbContextOptions))
            {
                return busca.Despesa.Sum(m => m.Valor);
            }
        }
    }
}
 