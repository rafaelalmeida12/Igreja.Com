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

namespace Igreja.Com.Web.Controllers
{
    public class OfertasController : Controller
    {
        private readonly InterfaceOfertaApp _interfaceOferta;

        public OfertasController(InterfaceOfertaApp interfaceOferta)
        {
            _interfaceOferta = interfaceOferta;
        }

        // GET: Ofertas
        public IActionResult Index()
        {
            return View( _interfaceOferta.List());
        }

        // GET: Ofertas/Details/5
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

        // GET: Ofertas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ofertas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Observacao,Valor,DataCadastro,Id,dateTime")] Oferta oferta)
        {
            if (ModelState.IsValid)
            {
                oferta.dateTime = DateTime.Now;
                _interfaceOferta.Add(oferta);
                
                return RedirectToAction(nameof(Index));
            }
            return View(oferta);
        }

        // GET: Ofertas/Edit/5
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

        // POST: Ofertas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Observacao,Valor,DataCadastro,Id,dateTime")] Oferta oferta)
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

        // GET: Ofertas/Delete/5
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

        // POST: Ofertas/Delete/5
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
