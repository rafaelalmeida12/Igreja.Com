using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Igreja.Com.Aplicacao.InterfaceApp;
using Igreja.Com.Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Igreja.Com.Web.Controllers
{
    [Authorize]
    public class CultoController : Controller
    {
        private readonly InterfaceCultoApp interfaceCulto;

        public CultoController(InterfaceCultoApp interfaceCulto)
        {
            this.interfaceCulto = interfaceCulto;
        }

        // GET: Culto
        public ActionResult Index()
        {
            return View(interfaceCulto.List());
        }

        // GET: Culto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Culto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Culto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Culto culto)
        {
            try
            { 

                culto.dateTime = DateTime.Now;
                interfaceCulto.Add(culto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Culto/Edit/5
        public ActionResult Edit(int id)
        {
          var culto= interfaceCulto.GetEntityById(id);
            return View(culto);
        }

        // POST: Culto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Culto objeto)
        {
            try
            {
                // TODO: Add update logic here
                interfaceCulto.Update(objeto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Culto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Culto/Delete/5
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