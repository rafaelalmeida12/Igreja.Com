using Igreja.Com.Aplicacao.InterfaceApp;
using Igreja.Com.Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Igreja.Com.Web.Controllers
{
    [Authorize]
    public class CultoController : Controller
    {
        #region Construtores

        private readonly InterfaceCultoApp _interfaceCulto;
        private readonly InterfaceMembroApp _interfaceMembro;
        private readonly InterfaceCategoriaCultoApp _interfaceCategoriaCultoApp;

        public CultoController(InterfaceCultoApp interfaceCulto, InterfaceMembroApp interfaceMembro,
            InterfaceCategoriaCultoApp interfaceCategoriaCultoApp)
        {
            _interfaceCulto = interfaceCulto;
            _interfaceMembro = interfaceMembro;
            _interfaceCategoriaCultoApp = interfaceCategoriaCultoApp;
        }
        #endregion
        // GET: Culto
        public ActionResult Index()
        {
            return View(_interfaceCulto.List());
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

        public ActionResult Criar()
        {
            ViewBag.Membros = new SelectList(_interfaceMembro.List(), "Id", "Nome");
            ViewBag.CategoriaCulto = new SelectList(_interfaceCategoriaCultoApp.List(), "Id", "Nome");
            return PartialView("_Create");
        }

        // POST: Culto/Create
        [HttpPost]
        public ActionResult Create(Culto culto)
        {
            _interfaceCulto.Add(culto);
            var lista = _interfaceCulto.List();
            TempData["CultoId"] = lista[0].Id;
            return PartialView("_Listar",lista);

        }

        // GET: Culto/Edit/5
        public ActionResult Edit(int id)
        {
            var culto = _interfaceCulto.GetEntityById(id);
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
                _interfaceCulto.Update(objeto);
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