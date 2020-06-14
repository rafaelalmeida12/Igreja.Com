using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Igreja.Com.Aplicacao.InterfaceApp;
using Igreja.Com.Dominio.Entidades;
using Igreja.Com.Dominio.Entidades.Enum;
using Igreja.Com.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Igreja.Com.Web.Controllers
{
    public class DespesaController : Controller
    {
        #region Construtores
        private readonly InterfaceDespesaApp _interfaceDespesaApp;
        private readonly InterfaceMovimentacaoApp _interfaceMovimentacao;
        private readonly UserManager<AppIdentityUser> _userManager;

        public DespesaController(InterfaceDespesaApp interfaceDespesaApp, UserManager<AppIdentityUser> userManager,
            InterfaceMovimentacaoApp interfaceMovimentacao)
        {
            _interfaceDespesaApp = interfaceDespesaApp;
            _userManager = userManager;
            _interfaceMovimentacao = interfaceMovimentacao;
        }
        #endregion
        // GET: Despesa
        public ActionResult Index()
        {
            return View(_interfaceDespesaApp.List());
        }

        // GET: Despesa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Despesa/Create
        public ActionResult Create()
        {
            ViewBag.Categoria = null;
            return View();
        }

        // POST: Despesa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Despesa despesa)
        {
            try
            {
                int id = _interfaceDespesaApp.AddRetornoDespesa(despesa);
                string user = _userManager.GetUserName(this.User);
                AdicionarMovimentacao(despesa.Valor, id, user);
                return RedirectToAction("Index", "Caixa");
            }
            catch
            {
                return View();
            }
        }

        private void AdicionarMovimentacao(decimal valor, int idDizimo, string user)
        {
            Movimentacao movi = new Movimentacao
            {
                Valor = valor,
                Id_Movimentacoes = idDizimo,
                Pessoa = user,
                Data = DateTime.Now,
                TipoDespesa = TipoDespesa.saida

            };
            _interfaceMovimentacao.Add(movi);
        }

        // GET: Despesa/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Despesa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Despesa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Despesa/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}