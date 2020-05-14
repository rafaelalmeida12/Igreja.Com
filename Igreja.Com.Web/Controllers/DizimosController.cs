using Igreja.Com.Aplicacao.InterfaceApp;
using Igreja.Com.Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Igreja.Com.Web.Controllers
{
    [Authorize]
    public class DizimosController : Controller
    {
        private readonly InterfaceDizimoApp _interfaceDizimo;
        private readonly InterfaceMembroApp _interfaceMembro;
        private readonly InterfaceCultoApp _interfaceCulto;

        public DizimosController(InterfaceDizimoApp interfaceDizimo,InterfaceMembroApp interfaceMembro, InterfaceCultoApp interfaceCulto)
        {
           _interfaceDizimo = interfaceDizimo;
           _interfaceMembro = interfaceMembro;
           _interfaceCulto = interfaceCulto;
        }

        // GET: Dizimos
        public ActionResult Index()
        {
            return View(_interfaceDizimo.ListDizimo());
        }

        // GET: Dizimos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dizimos/Create
        public ActionResult Create()
        {
            CarregarViewBags();
            return View();
        }
        // POST: Dizimos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dizimo objeto)
        {
            try
            {
                //  objeto.dateTime = DateTime.Now;
                _interfaceDizimo.Add(objeto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Dizimos/Edit/5
        public ActionResult Edit(int id)
        {
            CarregarViewBags();
            var dizimos= _interfaceDizimo.GetEntityById(id);
            return View(dizimos);
        }

        // POST: Dizimos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Dizimo dizimo)
        {
            try
            {
                // TODO: Add update logic here
                _interfaceDizimo.Update(dizimo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Dizimos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dizimos/Delete/5
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
        private void CarregarViewBags()
        {
            //var user = await _userManager.GetUserAsync(this.User);
            int igrejaId=0;
            ViewBag.Membro = new SelectList(_interfaceMembro.GetAll(igrejaId), "Id", "Nome");
            ViewBag.Culto = new SelectList(_interfaceCulto.GetAll(), "Id", "Nome");
        }
    }
}