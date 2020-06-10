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
        public void Add(Movimentacao Objeto)
        {
            _interfaceMovimentacao.Add(Objeto);
        }

        public int AddRetorno(Movimentacao Objeto)
        {
            throw new NotImplementedException();
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

        public void Update(Movimentacao Objeto)
        {
            _interfaceMovimentacao.Update(Objeto);
        }
    }
}
