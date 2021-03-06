﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Igreja.Com.Dominio.Entidades;
using Igreja.Com.Infra.Configuracao;
using Igreja.Com.Aplicacao.InterfaceApp;

namespace Igreja.Com.Web.Controllers
{
    public class OfertasController : Controller
    {
        #region Construtores
    
        private readonly InterfaceOfertaApp _interfaceOferta;
        private readonly InterfaceCaixaApp _interfaceCaixaApp;
        private readonly InterfaceCategoriaOfertaApp _interfaceCategoriaOfertaApp;

        public OfertasController(InterfaceOfertaApp interfaceOferta,
            InterfaceCaixaApp interfaceCaixaApp,InterfaceCategoriaOfertaApp interfaceCategoriaOfertaApp)
        {
            _interfaceOferta = interfaceOferta;
            _interfaceCaixaApp = interfaceCaixaApp;
            _interfaceCategoriaOfertaApp = interfaceCategoriaOfertaApp;
        }
        #endregion
        public IActionResult Index()
        {
            return View( _interfaceOferta.List());
        }
        public  IActionResult Lista()
        {
            var ofertas = _interfaceOferta.List();

            return PartialView("Index",ofertas);

        }
        public IActionResult Create()
        {
            ViewBag.CategoriaOfertas = new SelectList(_interfaceCategoriaOfertaApp.List(),"Id", "Descricao");
            return PartialView("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Oferta oferta)
        {
            if (ModelState.IsValid)
            {
                AdicionarValorCaixa(oferta);

                _interfaceOferta.Add(oferta);

                return RedirectToAction(nameof(Index));
            }
            return View(oferta);
        }

        private void AdicionarValorCaixa(Oferta oferta)
        {
            
           var caixaDoMes= _interfaceCaixaApp.BuscarSaldoDoMes(oferta.dateTime);

           
            
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oferta =  _interfaceOferta.GetEntityById(id.Value);
            if (oferta == null)
            {
                return NotFound();
            }
            return View(oferta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Oferta oferta)
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
