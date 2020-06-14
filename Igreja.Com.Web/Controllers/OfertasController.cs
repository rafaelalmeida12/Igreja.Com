using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Igreja.Com.Dominio.Entidades;
using Igreja.Com.Infra.Configuracao;
using Igreja.Com.Aplicacao.InterfaceApp;
using Microsoft.AspNetCore.Identity;
using Igreja.Com.Web.Areas.Identity.Data;

namespace Igreja.Com.Web.Controllers
{
    public class OfertasController : Controller
    {
        #region Construtores

        private readonly InterfaceOfertaApp _interfaceOferta;
        private readonly InterfaceCategoriaOfertaApp _interfaceCategoriaOfertaApp;
        private readonly InterfaceCultoApp _interfaceCulto;
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly InterfaceMovimentacaoApp _interfaceMovimentacao;

        public OfertasController(InterfaceOfertaApp interfaceOferta,
            InterfaceCategoriaOfertaApp interfaceCategoriaOfertaApp, InterfaceCultoApp interfaceCulto, UserManager<AppIdentityUser> userManager,
            InterfaceMovimentacaoApp interfaceMovimentacao)
        {
            _interfaceOferta = interfaceOferta;
            _interfaceCategoriaOfertaApp = interfaceCategoriaOfertaApp;
            _interfaceCulto = interfaceCulto;
            _userManager = userManager;
            _interfaceMovimentacao = interfaceMovimentacao;
        }
        #endregion
        public IActionResult Index()
        {
            return View(_interfaceOferta.List());
        }
        public IActionResult Lista()
        {
            var ofertas = _interfaceOferta.List();

            return PartialView("Index", ofertas);

        }
        public IActionResult Create()
        {
            ViewBag.CategoriaOfertas = new SelectList(_interfaceCategoriaOfertaApp.List(), "Id", "Descricao");
            ViewBag.cultos = new SelectList(_interfaceCulto.List(), "Id", "descricao");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Oferta oferta)
        {
            try
            {
                var IdOferta = _interfaceOferta.AddRetornoOferta(oferta);
                string user = _userManager.GetUserName(this.User);
                AdicionarMovimentacao(oferta.Valor, IdOferta, user);
                return RedirectToAction("Index", "Caixa");
            }
            catch
            {
              return  View(oferta);
            }
        }

        private void AdicionarMovimentacao(decimal valor, int idDizimo, string user)
        {
            Movimentacao movi = new Movimentacao
            {
                Valor = valor,
                Id_Movimentacoes = idDizimo,
                Pessoa = user,
                Data = DateTime.Now,
                TipoDespesa = 0

            };

            _interfaceMovimentacao.Add(movi);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oferta = _interfaceOferta.GetEntityById(id.Value);
            if (oferta == null)
            {
                return NotFound();
            }
            return View(oferta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Oferta oferta)
        {
            if (id != oferta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _interfaceOferta.Update(oferta);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfertaExists(oferta.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(oferta);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oferta = _interfaceOferta.GetEntityById(id.Value);
            if (oferta == null)
            {
                return NotFound();
            }

            return View(oferta);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oferta = _interfaceOferta.GetEntityById(id.Value);
            if (oferta == null)
            {
                return NotFound();
            }

            return View(oferta);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var oferta = await _interfaceOferta.Oferta.FindAsync(id);
            //_interfaceOferta.Oferta.Remove(oferta);
            //await _interfaceOferta.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfertaExists(int id)
        {
            return true;/*_interfaceOferta.Any(e => e.Id == id);*/
        }
    }
}
