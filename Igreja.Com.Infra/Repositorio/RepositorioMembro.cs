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
    public class RepositorioMembro : RepositorioBase<Membro>, InterfaceMembro
    {
        private readonly DbContextOptions<Contexto> dbContextOptions;
        public RepositorioMembro()
        {
            dbContextOptions = new DbContextOptions<Contexto>();
        }
        public List<Membro> GetAll(int IgrejaId)
        {
            using (var busca = new Contexto(dbContextOptions))
            {
                var resultado = busca.Membro
                    .AsNoTracking()
                    .Include(C => C.Endereco)
                    .Include(d => d.DadosMinisteriais)
                    .Include(d => d.Cargos)
                    .Where(c => c.IgrejaId == IgrejaId)
                    .ToList();


                return resultado;
            }
        }
        public int BuscarTotalMembros(int IgrejaId)
        {
            using (var busca = new Contexto(dbContextOptions))
            {

                var resultado1= (from s in busca.Membro
                                 where s.IgrejaId == IgrejaId
                                 select s).AsNoTracking().Count();

              var   resultado2= (from s in busca.Membro
                        where s.IgrejaSede == IgrejaId
                        select s).AsNoTracking().Count();

                return resultado1 + resultado2;
            }
        }
        public Membro BuscarPorId(int Id)
        {
            using (var data = new Contexto(dbContextOptions))
            {
                return data.Membro
                    .Include(c => c.Endereco)
                    .Where(c => c.Id == Id)
                    .FirstOrDefault();
            }
        }

        public IList<Membro> BuscarAniversariantes(DateTime dateTime)
        {
            using (var data = new Contexto(dbContextOptions))
            {
                return data.Membro
                   .Where(c => c.DataNascimento.Month == dateTime.Month)
                   .AsNoTracking()
                   .ToList();

            }
        }
    }
}
