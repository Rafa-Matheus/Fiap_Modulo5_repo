﻿using Fiap.Web.Donation1.Data;
using Fiap.Web.Donation1.Models;
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
