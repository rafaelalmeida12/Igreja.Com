using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Igreja.Com.Aplicacao.InterfaceApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Igreja.Com.Web.Controllers
{
    public class MovimentacaoController : Controller
    {
        private readonly InterfaceMovimentacaoApp _movimentacaoApp;

        public MovimentacaoController(InterfaceMovimentacaoApp movimentacaoApp)
        {
            _movimentacaoApp = movimentacaoApp;
        }
        public ActionResult Index()
        {
         DateTime   data = DateTime.Now;
            return View(_movimentacaoApp.ListarMes(data.Month));
        }

        // GET: Movimentacao/Details/5
        public ActionResult Pesquisar(DateTime data1, DateTime data2)
        {
            var movimentacoes = _movimentacaoApp.BuscarEntreDatas(data1, data2);
            return PartialView("Index",movimentacoes);
        }

        // GET: Movimentacao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movimentacao/Create
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

        // GET: Movimentacao/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Movimentacao/Edit/5
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

        // GET: Movimentacao/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Movimentacao/Delete/5
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