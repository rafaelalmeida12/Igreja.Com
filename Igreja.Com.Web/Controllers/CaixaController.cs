﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Igreja.Com.Aplicacao.InterfaceApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Igreja.Com.Web.Controllers
{
    public class CaixaController : Controller
    {

        #region Construtores
        private readonly InterfaceOfertaApp _interfaceOfertaApp;
        private readonly InterfaceDespesaApp _interfaceDespesaApp;
        private readonly InterfaceCaixaApp _interfaceCaixaApp;
        public CaixaController(InterfaceOfertaApp interfaceOfertaApp,
            InterfaceDespesaApp interfaceDespesaApp, InterfaceCaixaApp interfaceCaixaApp)
        {
            _interfaceOfertaApp = interfaceOfertaApp;
            _interfaceDespesaApp = interfaceDespesaApp;
            _interfaceCaixaApp = interfaceCaixaApp;
        }
        #endregion

        public ActionResult Index()
        {
            DateTime date = DateTime.Now;
            ViewBag.Saldo = _interfaceOfertaApp.CalculaSaldo();
            ViewBag.Despesa = _interfaceDespesaApp.CalculaSaldo();
            ViewBag.Despesa = _interfaceCaixaApp.BuscarSaldoDoMes(date);
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
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
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Caixa/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Caixa/Edit/5
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

        // GET: Caixa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Caixa/Delete/5
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