using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Igreja.Com.Aplicacao.InterfaceApp;
using Igreja.Com.Dominio.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Igreja.Com.Web.Controllers
{
    public class DespesaController : Controller
    {
        private readonly InterfaceDespesaApp _interfaceDespesaApp;
        private readonly InterfaceOfertaApp _interfaceOfertaApp;
        private readonly InterfaceCaixaApp _interfaceCaixaApp;

        public DespesaController(InterfaceDespesaApp interfaceDespesaApp,
            InterfaceOfertaApp interfaceOfertaApp, InterfaceCaixaApp interfaceCaixaApp)
        {
            _interfaceDespesaApp = interfaceDespesaApp;
            _interfaceOfertaApp = interfaceOfertaApp;
            _interfaceCaixaApp = interfaceCaixaApp;
        }
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
            return View();
        }

        // POST: Despesa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Despesa despesa)
        {
            try
            {
                //subtrai do caixa
              

                despesa.dateTime = DateTime.Now;
                _interfaceDespesaApp.Add(despesa);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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