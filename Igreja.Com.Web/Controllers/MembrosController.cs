using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Igreja.Com.Aplicacao.InterfaceApp;
using Igreja.Com.Dominio.Entidades;
using Igreja.Com.Web.Areas.Identity.Data;
using Igreja.Com.Web.ViewsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Igreja.Com.Web.Controllers
{
    [Authorize]
    public class MembrosController : Controller
    {
        #region Construtores
       
        private readonly InterfaceMembroApp _interfaceMembro;
        private readonly InterfaceCargoApp _interfaceCargos;
        private readonly InterfaceIgrejasApp _interfaceIgrejasApp;
        private readonly UserManager<AppIdentityUser> _userManager;

        public MembrosController(InterfaceMembroApp interfaceMembro, UserManager<AppIdentityUser> userManager,
            InterfaceCargoApp interfaceCargos, InterfaceIgrejasApp interfaceIgrejasApp)
        {
            _interfaceMembro = interfaceMembro;
            _userManager = userManager;
            _interfaceCargos = interfaceCargos;
            _interfaceIgrejasApp = interfaceIgrejasApp;
        }
        #endregion
        public async Task<ActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(this.User);
            return View(_interfaceMembro.GetAll(user.IgrejasId));
        }
        public ActionResult Create()
        {
            ViewBag.Igrejas = new SelectList(_interfaceIgrejasApp.List(), "Id", "Nome");
            return View();
        }
        public ActionResult CriarParcial()
        {
            ViewBag.Igrejas = new SelectList(_interfaceIgrejasApp.List(), "Id", "Nome");
            ViewBag.Cargo = new SelectList(_interfaceCargos.List(), "Id", "Descricao");
            return View();
        }
        [HttpPost]
        public ActionResult CriarParcial(MembroViewModel membroView)
        {
            if (ModelState.IsValid)
            {
                var membro = new Membro();
                var VerificaSede = _interfaceIgrejasApp.GetEntityById(membroView.IgrejaId);
                if (VerificaSede.IgrejasId != null)
                {
                    membro.IgrejaSede = VerificaSede.IgrejasId;
                }
                membro.Nome = membroView.NomeCompleto;
                membro.CargoId = membroView.CargoId;
                membro.DadosMinisteriais = membroView.DadosMinisteriais;
                membro.DataNascimento = membroView.DataNascimento;
                membro.Sexo = membroView.Sexo;
                membro.Telefone = membroView.Telefone;
                membro.IgrejaId = membroView.IgrejaId;

                _interfaceMembro.Add(membro);
                return RedirectToAction("Index");
            }
            return View(membroView);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Membro membro)
        {
            if (ModelState.IsValid)
            {
                var VerificaSede = _interfaceIgrejasApp.GetEntityById(membro.IgrejaId);
                if (VerificaSede.IgrejasId!=null)
                {
                    membro.IgrejaSede = VerificaSede.IgrejasId;
                }
                // membro.dateTime = DateTime.Now;
                _interfaceMembro.Add(membro);
                return RedirectToAction("Index");
            }
            return View(membro);
        }

        public ActionResult Aniversariantes()
        {
            ViewBag.Mes = _interfaceMembro.BuscarAniversariantes(DateTime.Now);
            return View();
        }
        [HttpPost]
        public IList<Membro> TESTE(string nome)
        {
          var membros=  _interfaceMembro.BuscarPorNome(nome);

            return membros;
        }

        public IList<Membro> BuscarAniversariantes()
        {
            return _interfaceMembro.BuscarAniversariantes(DateTime.Now);
        }
        // GET: Membros/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Igrejas = new SelectList(_interfaceIgrejasApp.List(), "Id", "Nome");

            var membro = _interfaceMembro.BuscarPorId(id);
            return View(membro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Membro membro)
        {
            try
            {
                // TODO: Add update logic here
                _interfaceMembro.Update(membro);
                return RedirectToAction("Index");
            }
            catch(ArgumentNullException ex)
            {
                var respota = ex;
                return View();
            }
        }

        // GET: Membros/Delete/5
        public ActionResult Delete(int id)
        {
            var membro = _interfaceMembro.BuscarPorId(id);
            return View(membro);
        }

        // POST: Membros/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Membro membro)
        {
            try
            {
                var membros = _interfaceMembro.BuscarPorId(id);
                _interfaceMembro.Delete(membros);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ResumoMembro()
        {

            return View(_interfaceMembro.List());
        }
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Criar()
        {
            int igrejaId = 0;
            var membro = _interfaceMembro.GetAll(igrejaId);

            return View("ResumoMembro", membro);
        }
    }
}