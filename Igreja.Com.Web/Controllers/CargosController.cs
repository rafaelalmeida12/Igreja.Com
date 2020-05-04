using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Authorization;
using Igreja.Com.Aplicacao.InterfaceApp;
using Igreja.Com.Dominio.Entidades;

namespace Igreja.Com.Web.Controllers
{
    [Authorize]
    public class CargosController : Controller
    {
        private readonly InterfaceCargoApp _InterfaceCargo;

        public CargosController(InterfaceCargoApp context)
        {
            _InterfaceCargo = context;
        }

        public  IActionResult Index()
        {
            return View( _InterfaceCargo.List());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cargo = _InterfaceCargo.GetEntityById(id.Value);
            if (cargo == null)
            {
                return NotFound();
            }
            return View(cargo);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cargo cargo)
        {
            if (ModelState.IsValid)
            {
               // cargo.dateTime = DateTime.Now;
                _InterfaceCargo.Add(cargo);
                return RedirectToAction(nameof(Index));
            }
            return View(cargo);
        }

        // GET: Cargoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargo =  _InterfaceCargo.GetEntityById(id.Value);
            if (cargo == null)
            {
                return NotFound();
            }
            return View(cargo);
        }

        // POST: Cargoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Cargo cargo)
        {
            if (id != cargo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _InterfaceCargo.Update(cargo);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CargoExists(cargo.Id))
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
            return View(cargo);
        }

        // GET: Cargoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargo = _InterfaceCargo.GetEntityById(id.Value);
            if (cargo == null)
            {
                return NotFound();
            }

            return View(cargo);
        }

        // POST: Cargoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cargo =  _InterfaceCargo.GetEntityById(id);
            _InterfaceCargo.Delete(cargo);
            return RedirectToAction(nameof(Index));
        }

        private bool CargoExists(int id)
        {
            return true;
        }
    }
}
