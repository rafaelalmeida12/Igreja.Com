using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Igreja.Com.Aplicacao.InterfaceApp;
using Igreja.Com.Dominio.Entidades;
using Igreja.Com.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Igreja.Com.Web.Controllers
{
    [Authorize]
    public class MembrosController : Controller
    {
        private readonly InterfaceMembroApp interfaceMembro;
        private readonly UserManager<AppIdentityUser> userManager;

        public MembrosController(InterfaceMembroApp interfaceMembro, UserManager<AppIdentityUser> userManager)
        {
            this.interfaceMembro = interfaceMembro;
            this.userManager = userManager;
        }

        // GET: Membros
        public ActionResult Index()
        {

            return View(interfaceMembro.List());
        }

        // GET: Membros/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Teste()
        {
            var resultado = 0;
            List<int> digits = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                                              11, 12, 13, 14, 15, 16, 17, 18, 19,20};
            var contasQuantidadePorThread = digits.Count() / 4;

            var contas_parte1 = digits.Take(contasQuantidadePorThread);
            var contas_parte2 = digits.Skip(contasQuantidadePorThread).Take(contasQuantidadePorThread);
            var contas_parte3 = digits.Skip(contasQuantidadePorThread * 2).Take(contasQuantidadePorThread);
            var contas_parte4 = digits.Skip(contasQuantidadePorThread * 3);
            var inico = DateTime.Now;

            Thread thread_parte1 = new Thread(() =>
            {
                foreach (var item in contas_parte1)
                {
                    interfaceMembro.List();
                    var soma = item + 1;
                    soma = soma / 2;
                    resultado = soma;
                    foreach (var items in contas_parte2)
                    {
                        interfaceMembro.List();
                        var numero = item - 1;
                    }
                }
            });
            Thread thread_parte2 = new Thread(() =>
            {
                foreach (var membro in contas_parte3)
                {
                    interfaceMembro.List();
                    var numero = membro + 1;
                }
                foreach (var membro in contas_parte4)
                {
                    interfaceMembro.List();
                    var numero = membro + 1;
                }
            });
            thread_parte1.Start();
            thread_parte2.Start();

            while (thread_parte1.IsAlive || thread_parte2.IsAlive)
            {
                Thread.Sleep(105);
                //Não vou fazer nada
            }

            var fim = DateTime.Now;
            ViewBag.resultato = fim - inico;

            return View();
        }


        // GET: Membros/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Criar()
        {

            var membro = interfaceMembro.GetAll();

            return View("ResumoMembro", membro);
        }
        // POST: Membros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Membro membro)
        {
            try
            {
                //validacoes 
                interfaceMembro.EhValido(membro);
                interfaceMembro.Existe(membro);

                //usuario
                CADASTRARUSUARIO(membro);
                //
                membro.dateTime = DateTime.Now;
                interfaceMembro.Add(membro);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task CADASTRARUSUARIO(Membro membro)
        {
            var usuario = await userManager.GetUserAsync(this.User);

            usuario.Nome = membro.Nome;
            usuario.Email = membro.Email;
            usuario.Telefone = membro.Telefone;
            usuario.Endereco = membro.Endereco.Bairro;
            usuario.Complemento = membro.Endereco.Complemento;
            usuario.Bairro = membro.Endereco.Bairro;
            usuario.Municipio = "Porto-Velho";
            usuario.UF = "RO";
            usuario.CEP = "76813-040";

            await userManager.UpdateAsync(usuario);
        }


        // GET: Membros/Edit/5
        public ActionResult Edit(int id)
        {
            var membro = interfaceMembro.GetEntityById(id);
            return View(membro);
        }

        // POST: Membros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Membro membro)
        {
            try
            {
                // TODO: Add update logic here
                interfaceMembro.Update(membro);
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
    }
}