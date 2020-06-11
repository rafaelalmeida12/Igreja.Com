using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Igreja.Com.Aplicacao.InterfaceApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace Igreja.Com.Web.Controllers
{
    public class CaixaController : Controller
    {

        #region Construtores

        private readonly InterfaceMovimentacaoApp _interfaceMovimentacaoApp;

        public CaixaController(InterfaceMovimentacaoApp interfaceMovimentacaoApp)
        {
            _interfaceMovimentacaoApp = interfaceMovimentacaoApp;
        }
        #endregion

        public ActionResult Index()
        {
            var mes = DateTime.Now;
            ViewBag.Entradas= _interfaceMovimentacaoApp.BuscarEntradasDoMes(mes.Month);
            ViewBag.Saidas= _interfaceMovimentacaoApp.BuscarSaidaDoMes(mes.Month);

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Caixa/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Caixa/Edit/5
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

        // GET: Caixa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Caixa/Delete/5
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