using Fiap.Web.Donation1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.Donation1.Data
{
    // Essa é a classe que manipula os dados da aplicação
    public class DataContext : DbContext
    {
        public DbSet<TipoProdutoModel> TipoProdutos { get; set; }

        /*
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<TrocaModel> Trocas { get; set; }
        */

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected DataContext()
        {

        }
    }
}
