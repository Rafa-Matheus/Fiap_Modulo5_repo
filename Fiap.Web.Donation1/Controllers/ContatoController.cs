using Fiap.Web.Donation1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.Donation1.Controllers
{
    public class ContatoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Gravar(ContatoModel contatoModel)
        {
            return View("Sucesso"); // Para passar uma View específica
        }

        [HttpGet]
        public IActionResult Help()
        {
            return View(); // RedirectToAction("Index", "Home");
        }
    }
}
