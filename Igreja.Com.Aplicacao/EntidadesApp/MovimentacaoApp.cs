using Igreja.Com.Aplicacao.InterfaceApp;
using Igreja.Com.Dominio.Entidades;
using Igreja.Com.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Aplicacao.EntidadesApp
{
    public class MovimentacaoApp : InterfaceMovimentacaoApp
    {
        InterfaceMovimentacao _interfaceMovimentacao;

        public MovimentacaoApp(InterfaceMovimentacao interfaceMovimentacao)
        {
            _interfaceMovimentacao = interfaceMovimentacao;
        }
        public void Add(Movimentacao Objeto)
        {
            _interfaceMovimentacao.Add(Objeto);
        }

        public int AddRetorno(Movimentacao Objeto)
        {
            throw new NotImplementedException();
        }

        public decimal BuscarEntradasDoMes(int month)
        {
            return _interfaceMovimentacao.BuscarEntradasDoMes(month);
        }

        public IList<Movimentacao> BuscarEntreDatas(DateTime data1, DateTime data2)
        {
            return _interfaceMovimentacao.BuscarEntreDatas(data1, data2);
        }

        public decimal BuscarSaidaDoMes(int month)
        {
            return _interfaceMovimentacao.BuscarSaidaDoMes(month);
        }

        public void Delete(Movimentacao Objeto)
        {
            _interfaceMovimentacao.Delete(Objeto);
        }

        public Movimentacao GetEntityById(int Id)
        {
            return _interfaceMovimentacao.GetEntityById(Id);
        }

        public List<Movimentacao> List()
        {
            return _interfaceMovimentacao.List();
        }

        public IList<Movimentacao> ListarMes(int month)
        {
            return _interfaceMovimentacao.ListarMes(month);
        }

        public void Update(Movimentacao Objeto)
        {
            _interfaceMovimentacao.Update(Objeto);
        }
    }
}
