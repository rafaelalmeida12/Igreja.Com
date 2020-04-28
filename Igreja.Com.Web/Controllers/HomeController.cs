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

namespace Igreja.Com.Web.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InterfaceMembroApp interfaceMembro;

        public HomeController(ILogger<HomeController> logger, InterfaceMembroApp _interfaceMembro)
        {
            _logger = logger;
            interfaceMembro=_interfaceMembro;
        }

        public IActionResult Index()
        {
            ViewBag.Membro = interfaceMembro.GetAll();
            return View();
        }

        public IActionResult User()
        {
            
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
    }
}
