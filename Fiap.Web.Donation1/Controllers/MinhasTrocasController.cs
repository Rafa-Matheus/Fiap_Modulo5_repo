using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.Donation1.Controllers
{
    public class MinhasTrocasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
