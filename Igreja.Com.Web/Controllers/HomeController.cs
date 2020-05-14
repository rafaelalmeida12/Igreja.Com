using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Igreja.Com.Web.Models;
using Igreja.Com.Aplicacao.InterfaceApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Igreja.Com.Web.Areas.Identity.Data;
using System.Globalization;

namespace Igreja.Com.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InterfaceMembroApp _interfaceMembro;
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly InterfaceIgrejasApp _interfaceIgrejasApp;

        public HomeController(ILogger<HomeController> logger, InterfaceMembroApp interfaceMembro,
           UserManager<AppIdentityUser> userManager, InterfaceIgrejasApp interfaceIgrejas)
        {
            _logger = logger;
            _interfaceMembro = interfaceMembro;
            _userManager = userManager;
            _interfaceIgrejasApp = interfaceIgrejas;
        }

        public async Task<IActionResult> Index()
        {
            //PEGA O USUARIO LOGADO
            var user = await _userManager.GetUserAsync(this.User);
            //BUSCAR NOME IGREJA POR ID
            int igrejaID = user.IgrejasId;
            TempData["Igreja"]= _interfaceIgrejasApp.GetEntityById(igrejaID);
            ViewBag.Mensagem = TempData["Igreja"];
            //CASO SEJA UMA FILIA BUSCA TODAS
             ViewBag.igrejasfiliais = _interfaceIgrejasApp.BuscarFilialPorIgrejaID(igrejaID);
            //BUSCAR MEMBROS POR ID
            var membros = _interfaceMembro.GetAll(igrejaID);
            ViewBag.Membro = membros;
            ViewBag.TotalGeral = _interfaceMembro.BuscarTotalMembros(igrejaID);
            //Carrega aniversariantes
            ViewBag.Mes = _interfaceMembro.BuscarAniversariantes(DateTime.Now);
            
            return View();
        }

        public IActionResult Tabela()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string ExibirMesPorExtenso(DateTime data)
        {
            return data.ToString("MMMM", CultureInfo.CreateSpecificCulture("pt-br"));
        }
    }
}
