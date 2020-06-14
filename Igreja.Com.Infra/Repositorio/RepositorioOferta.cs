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
    public class RepositorioOferta:RepositorioBase<Oferta>,InterfaceOferta
    {
        private readonly DbContextOptions<Contexto> dbContextOptions;
        public RepositorioOferta()
        {
            dbContextOptions = new DbContextOptions<Contexto>();
        }

        public decimal CalculaSaldo()
        {
            using (var busca = new Contexto(dbContextOptions))
            {
                return busca.Oferta.Sum(m => m.Valor);
            }
        }

        public decimal DescontarDespesa(decimal valor)
        {
            using (var busca = new Contexto(dbContextOptions))
            {
                var resultado= busca.Oferta.Sum(m => m.Valor);
                var novoResultado= resultado - valor;
                return novoResultado;
            }
        }

        public int AddRetornoOferta(Oferta Objeto)
        {

            using (var data = new Contexto(dbContextOptions))
            {
                data.Oferta.Add(Objeto);
                data.SaveChanges();

                int id = Objeto.Id;
                return id;
            }
        }
    }
}