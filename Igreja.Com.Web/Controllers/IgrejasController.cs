using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Igreja.Com.Aplicacao.InterfaceApp;
using Igreja.Com.Dominio.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Igreja.Com.Web.Controllers
{
    public class IgrejasController : Controller
    {
        #region Construtores
      
        private readonly InterfaceIgrejasApp _interfaceIgrejas;

        // GET: Igrejas

        public IgrejasController(InterfaceIgrejasApp interfaceIgrejas)
        {
            _interfaceIgrejas = interfaceIgrejas;
        }
        #endregion
        public ActionResult Index()
        {
            return View(_interfaceIgrejas.List());
        }

        // GET: Igrejas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Igrejas/Create
        public ActionResult Create()
        {
            ViewBag.Igrejas = new SelectList(_interfaceIgrejas.BuscarCedes(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Igrejas igrejas)
        {

            _interfaceIgrejas.Add(igrejas);
            return RedirectToAction(nameof(Index));

        }

        // GET: Igrejas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Igrejas/Edit/5
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

        // GET: Igrejas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Igrejas/Delete/5
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