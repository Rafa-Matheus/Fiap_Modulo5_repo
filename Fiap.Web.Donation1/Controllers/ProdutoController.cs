using Fiap.Web.Donation1.Data;
using Fiap.Web.Donation1.Models;
using Fiap.Web.Donation1.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.Donation1.Controllers
{
    public class ProdutoController : Controller
    {

        //private List<ProdutoModel> produtos;

        private readonly ProdutoRepository produtoRepository;

        public ProdutoController(DataContext dataContext)
        {

            produtoRepository = new ProdutoRepository(dataContext);

            // Acesso fake ao banco dados

            /*
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
            };*/
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Consulta o BD

            //ViewBag.Produtos = produtos; // Carrego/Levo os produtos para a View
            //TempData["Produtos"] = produtos;

            var produtos = produtoRepository.FindAll();

            return View(produtos); // Posso enviar pois a View está tipada
        }

        [HttpGet] // Get é para obter/abrir/consultar algo
        public IActionResult Novo()
        {
            return View(new ProdutoModel());
        }

        [HttpPost] // Post deve ser usado para gravar algo
        public IActionResult Novo(ProdutoModel produtoModel) // instanciação implícita
        {
            #region Código anterior comentado
            /*
            // Aqui poderiam ir as instruções que gravariam o produto no DB

            ViewBag.Produtos = produtos;

            // ViewBag.Mensagem = $"{produtoModel.Nome} cadastrado com sucesso";
            TempData["Mensagem"] = $"{produtoModel.Nome} cadastrado com sucesso";

            return RedirectToAction("Index");
            */
            #endregion

            if (string.IsNullOrEmpty(produtoModel.Nome))
            {
                ViewBag.Mensagem = "O campo nome é requerido";

                return View(produtoModel);
            }
            else
            {
                produtoModel.UsuarioId = 1;
                produtoRepository.Insert(produtoModel);

                // UPDATE produto SET WHERE Produto = produtoModel.ProdutoId
                TempData["Mensagem"] = $"{produtoModel.Nome} alterado com sucesso";

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            // SELECT * FROM produto WHERE ProdutoId = {id};
            //var produto = produtos[id - 1];
            var produto = produtoRepository.FindById(id);

            // ViewBag para passar elementos do Controller para a View
            //ViewBag.Produto = produto;

            // Posso enviar produto como parâmetro pois a View está associada a Model
            return View(produto); 
        }

        [HttpPost]
        public IActionResult Editar(ProdutoModel produtoModel)
        {
            if (string.IsNullOrEmpty(produtoModel.Nome))
            {
                ViewBag.Mensagem = "O campo nome é requerido";

                return View(produtoModel);
            }
            else
            {
                produtoModel.DataCadastro = DateTime.Now;
                produtoModel.UsuarioId = 1;
                produtoRepository.Update(produtoModel);

                // UPDATE produto SET WHERE Produto = produtoModel.ProdutoId
                TempData["Mensagem"] = $"{produtoModel.Nome} alterado com sucesso";

                return RedirectToAction("Index");
            }
        }
    }
}
