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

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InterfaceMembroApp interfaceMembro;
        private readonly UserManager<AppIdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, InterfaceMembroApp _interfaceMembro,
           UserManager<AppIdentityUser> userManager)
        {
            _logger = logger;
            interfaceMembro = _interfaceMembro;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(this.User);
            if (user != null) ViewBag.Membro = interfaceMembro.GetAll(user.IgrejasId);
            var mes = ExibirMesPorExtenso(new DateTime(2019, 7, 7));
            ViewBag.Mes = interfaceMembro.BuscarAniversariantes(DateTime.Now);
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
