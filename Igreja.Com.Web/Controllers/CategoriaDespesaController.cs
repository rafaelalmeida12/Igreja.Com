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
    public class CategoriaDespesaController : Controller
    {
        private readonly InterfaceCategoriaDespesaApp _interfaceCategoriaDespesa;

        public CategoriaDespesaController(InterfaceCategoriaDespesaApp interfaceCategoriaDespesa)
        {
            _interfaceCategoriaDespesa = interfaceCategoriaDespesa;
        }
        public ActionResult Index()
        {
            return View(_interfaceCategoriaDespesa.List());
        }

        // GET: CategoriaDespesa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoriaDespesa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaDespesa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaDespesa Objeto)
        {
            try
            {
                // TODO: Add insert logic here
                _interfaceCategoriaDespesa.Add(Objeto);
               
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaDespesa/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoriaDespesa/Edit/5
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

        // GET: CategoriaDespesa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoriaDespesa/Delete/5
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