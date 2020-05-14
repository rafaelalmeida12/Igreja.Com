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
        public ActionResult TESTE(string mes)
        {
            ViewBag.Mes = _interfaceMembro.BuscarAniversariantes(DateTime.Now);
            return View();
        }

        public IList<Membro> BuscarAniversariantes()
        {
            return _interfaceMembro.BuscarAniversariantes(DateTime.Now);
        }
        // GET: Membros/Edit/5
        public ActionResult Edit(int id)
        {
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
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Membros/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Membros/Delete/5
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
        public ActionResult ResumoMembro()
        {

            return View(_interfaceMembro.List());
        }
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Teste()
        {
            //var resultado = 0;
            //List<int> digits = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
            //                                  11, 12, 13, 14, 15, 16, 17, 18, 19,20};
            //var contasQuantidadePorThread = digits.Count() / 4;

            //var contas_parte1 = digits.Take(contasQuantidadePorThread);
            //var contas_parte2 = digits.Skip(contasQuantidadePorThread).Take(contasQuantidadePorThread);
            //var contas_parte3 = digits.Skip(contasQuantidadePorThread * 2).Take(contasQuantidadePorThread);
            //var contas_parte4 = digits.Skip(contasQuantidadePorThread * 3);
            //var inico = DateTime.Now;

            //Thread thread_parte1 = new Thread(() =>
            //{
            //    foreach (var item in contas_parte1)
            //    {
            //        interfaceMembro.List();
            //        var soma = item + 1;
            //        soma = soma / 2;
            //        resultado = soma;
            //        foreach (var items in contas_parte2)
            //        {
            //            interfaceMembro.List();
            //            var numero = item - 1;
            //        }
            //    }
            //});
            //Thread thread_parte2 = new Thread(() =>
            //{
            //    foreach (var membro in contas_parte3)
            //    {
            //        interfaceMembro.List();
            //        var numero = membro + 1;
            //    }
            //    foreach (var membro in contas_parte4)
            //    {
            //        interfaceMembro.List();
            //        var numero = membro + 1;
            //    }
            //});
            //thread_parte1.Start();
            //thread_parte2.Start();

            //while (thread_parte1.IsAlive || thread_parte2.IsAlive)
            //{
            //    Thread.Sleep(105);
            //    //Não vou fazer nada
            //}

            //var fim = DateTime.Now;
            //ViewBag.resultato = fim - inico;

            return View();
        }


        // GET: Membros/Create


        public ActionResult Criar()
        {
            int igrejaId = 0;
            var membro = _interfaceMembro.GetAll(igrejaId);

            return View("ResumoMembro", membro);
        }
    }
}