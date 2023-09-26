using Fiap.Web.Donation1.Data;
using Fiap.Web.Donation1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.Donation1.Repository
{
    public class ProdutoRepository
    {
        //DataContext
        private readonly DataContext dataContext;

        public ProdutoRepository(DataContext ctx)
        {
            dataContext = ctx;
        }

        // Métodos que simulam as operações do banco:

        // Consulta - Listar todos
        public IList<ProdutoModel> FindAll()
        {
            var produtos = dataContext.Produtos.ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }

        public IList<ProdutoModel> FindAllWithTipo()
        {
            
            var produtos = dataContext
                .Produtos // SELECT * FROM Produtos
                .Include(p => p.TipoProduto) // INNER Join
                    .ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }

        public IList<ProdutoModel> FindAllWithTipoAndUsuario()
        {

            var produtos = dataContext
                .Produtos // SELECT * FROM Produtos
                .Include(p => p.TipoProduto) // INNER Join
                .Include(p => p.Usuario) // INNER Join

                    .ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }

        public IList<ProdutoModel> FindAllWithTipoOrderByName()
        {

            var produtos = dataContext
                .Produtos // SELECT * FROM Produtos
                .Include(p => p.TipoProduto) // INNER Join
                .OrderBy(p => p.Nome) // ORDER BY
                    .ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }

        public IList<ProdutoModel> FindAllByDisponivel(bool disponivel)
        {

            var produtos = dataContext
                .Produtos // SELECT * FROM Produtos
                .Include(p => p.TipoProduto) // INNER Join
                .Where(p => p.Disponivel == disponivel) // WHERE Disponivel = {disponivel}
                    .ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }

        public IList<ProdutoModel> FindAllByUsuarioDisponivel(bool disponivel, int usuarioId)
        {

            var produtos = dataContext
                .Produtos // SELECT * FROM Produtos
                .Include(p => p.TipoProduto) // INNER Join
                .Where(p => p.Disponivel == disponivel && p.UsuarioId == usuarioId) // WHERE Disponivel = {disponivel}
                    .ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }

        public IList<ProdutoModel> FindAllDisponivelDoUsuario(bool disponivel, int usuarioId)
        {

            var produtos = dataContext
                .Produtos // SELECT * FROM Produtos
                .Include(p => p.TipoProduto) // INNER Join
                .Where(p => p.Disponivel == disponivel && p.UsuarioId == usuarioId) // WHERE Disponivel = {disponivel}
                    .ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }

        public IList<ProdutoModel> FindAllDisponivelParaTroca(bool disponivel, int usuarioId)
        {

            var produtos = dataContext
                .Produtos // SELECT * FROM Produtos
                .Include(p => p.TipoProduto) // INNER Join
                .Where(p => p.Disponivel == disponivel && p.UsuarioId == usuarioId) // WHERE Disponivel = {disponivel}
                    .ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }

        public IList<ProdutoModel> FindByNome(string nome)
        {

            var produtos = dataContext
                .Produtos // SELECT * FROM Produtos
                .Include(p => p.TipoProduto) // INNER Join
                .Where(p => p.Nome.ToLower().Contains(nome.ToLower()))
                    .ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }

        // Consulta - Detalhe (Consulta por Id)
        public ProdutoModel FindById(int id)
        {
                                               // Where          ProdutoId = {id}
            var produto = dataContext.Produtos.FirstOrDefault(p => p.ProdutoId == id);

            return produto;
        }

        // Inserir
        public int Insert(ProdutoModel produtoModel) // Retorna o id se desejar fazer algo com ele
        {
            produtoModel.DataCadastro = DateTime.Now;

            dataContext.Produtos.Add(produtoModel);
            dataContext.SaveChanges();

            return produtoModel.ProdutoId;
        }

        // Alterar
        public void Update(ProdutoModel produtoModel)
        {
            dataContext.Produtos.Update(produtoModel);
            dataContext.SaveChanges();
        }

        // Excluir
        public void Delete(ProdutoModel produtoModel)
        {
            dataContext.Produtos.Remove(produtoModel);
            dataContext.SaveChanges();
        }


        public void Delete(int id)
        {
            var produtoModel = new ProdutoModel()
            {
                ProdutoId = id,
            };

            Delete(produtoModel);
        }
    }
}
