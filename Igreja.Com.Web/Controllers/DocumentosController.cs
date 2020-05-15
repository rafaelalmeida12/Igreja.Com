using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Igreja.Com.Aplicacao.InterfaceApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Igreja.Com.Web.Controllers
{
    public class DocumentosController : Controller
    {
        #region Construtores
      
        private readonly InterfaceMembroApp _interfaceMembro;

        public DocumentosController(InterfaceMembroApp interfaceMembro)
        {
            _interfaceMembro = interfaceMembro;
        }
        #endregion
        // GET: Documentos
        public ActionResult Index()
        {
            return View();
        }

        // GET: Documentos/Details/5
        public ActionResult Carta()
        {
            return View();
        }

    // GET: Documentos/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Documentos/Create
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

    // GET: Documentos/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: Documentos/Edit/5
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

    // GET: Documentos/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: Documentos/Delete/5
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