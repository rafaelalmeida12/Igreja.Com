using Igreja.Com.Aplicacao.InterfaceApp;
using Igreja.Com.Dominio.Entidades;
using Igreja.Com.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Igreja.Com.Web.Controllers
{
    [Authorize]
    public class DizimosController : Controller
    {
        #region Construtores
      
        private readonly InterfaceDizimoApp _interfaceDizimo;
        private readonly InterfaceMembroApp _interfaceMembro;
        private readonly InterfaceCultoApp _interfaceCulto;
        private readonly InterfaceMovimentacaoApp _interfaceMovimentacao;
        private readonly UserManager<AppIdentityUser> _userManager;


        public DizimosController(InterfaceDizimoApp interfaceDizimo,InterfaceMembroApp interfaceMembro, 
            InterfaceCultoApp interfaceCulto, InterfaceMovimentacaoApp interfaceMovimentacao, UserManager<AppIdentityUser> userManager)
        {
           _interfaceDizimo = interfaceDizimo;
           _interfaceMembro = interfaceMembro;
           _interfaceCulto = interfaceCulto;
            _interfaceMovimentacao = interfaceMovimentacao;
            _userManager = userManager;
        }
        #endregion
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
          
            ViewBag.cultos= new SelectList(_interfaceCulto.List(),"Id", "descricao");
            ViewBag.Membro = new SelectList(_interfaceMembro.GetAll(1), "Id", "Nome");
            return View();
        }
        // POST: Dizimos/Create
        [HttpPost]
        public ActionResult Create(Dizimo objeto)
        {
            try
            {
                //  objeto.dateTime = DateTime.Now;
                var IdDizimo = _interfaceDizimo.AddRetornoDizimo(objeto);
              string user= _userManager.GetUserName(this.User);
                AdicionarMovimentacao(objeto.Valor,IdDizimo, user);
                return RedirectToAction("Index", "Caixa");
            }
            catch
            {
                return View();
            }
        }

        private void AdicionarMovimentacao(decimal valor, int idDizimo, string user)
        {
            Movimentacao movi = new Movimentacao
            {
                Valor = valor,
                Id_Movimentacoes = idDizimo,
                Pessoa = user,
                Data=DateTime.Now,
                TipoDespesa=0

            };

            _interfaceMovimentacao.Add(movi);
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