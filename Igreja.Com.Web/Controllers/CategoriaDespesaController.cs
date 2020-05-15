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
        #region Construtores
      
        private readonly InterfaceCategoriaDespesaApp _interfaceCategoriaDespesa;

        public CategoriaDespesaController(InterfaceCategoriaDespesaApp interfaceCategoriaDespesa)
        {
            _interfaceCategoriaDespesa = interfaceCategoriaDespesa;
        }
        #endregion
        public ActionResult Index()
        {
            return View(_interfaceCategoriaDespesa.List());
        }

        public ActionResult Create()
        {
            return View();
        }

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

        public ActionResult Edit(int id)
        {
            return View();
        }

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

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

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