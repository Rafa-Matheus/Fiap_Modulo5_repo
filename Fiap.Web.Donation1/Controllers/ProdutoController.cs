using Fiap.Web.Donation1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.Donation1.Controllers
{
    public class ProdutoController : Controller
    {

        private List<ProdutoModel> produtos;

        public ProdutoController()
        {
            // Acesso fake ao banco dados

            produtos = new List<ProdutoModel>{
                new ProdutoModel()
                {
                    ProdutoId = 1,
                    Nome = "Iphone 11",
                    TipoProdutoId = 1,
                    Disponivel = true,
                    DataExpiracao = DateTime.Now,
                },
                new ProdutoModel()
                {
                    ProdutoId = 2,
                    Nome = "Iphone 12",
                    TipoProdutoId = 2,
                    Disponivel = true,
                    DataExpiracao = DateTime.Now,
                },
                new ProdutoModel()
                {
                    ProdutoId = 3,
                    Nome = "Iphone 13",
                    TipoProdutoId = 1,
                    Disponivel = true,
                    DataExpiracao = DateTime.Now,
                },
            };
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Consulta o BD

            ViewBag.Produtos = produtos; // Carrego/Levo os produtos para a View
            //TempData["Produtos"] = produtos;

            return View(); // ViewBag deve ser associado a um retorno View!
        }

        [HttpGet] // Get é para obter/abrir/consultar algo
        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost] // Post deve ser usado para gravar algo
        public IActionResult Novo(ProdutoModel produtoModel)
        {
            // Aqui poderiam ir as instruções que gravariam o produto no DB

            ViewBag.Produtos = produtos;

            //ViewBag.Mensagem = $"{produtoModel.Nome} cadastrado com sucesso";
            TempData["Mensagem"] = $"{produtoModel.Nome} cadastrado com sucesso";

            return RedirectToAction("Index");
        }
    }
}
