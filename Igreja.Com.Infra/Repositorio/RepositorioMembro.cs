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
        public List<Membro> GetAll()
        {
             using (var busca = new Contexto(dbContextOptions))
            {
                return busca.Membro
                    .AsNoTracking()
                    .Include(C=>C.Endereco)
                    .ToList();
            }
        }
    }
}
