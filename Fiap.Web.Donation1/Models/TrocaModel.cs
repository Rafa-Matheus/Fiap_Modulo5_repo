using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.Donation1.Models
{
    public enum TrocaStatus
    {
        Iniciado = 1,
        Analisado = 2,
        Finalizado = 3,
        Revertido = 4
    }

    [Table("Troca")]
    public class TrocaModel
    {
        [Key]
        public Guid TrocaId { get; set; } = Guid.NewGuid();

        public DateTime DataCriacao { get; set; }

        public TrocaStatus Status { get; set; }

        public int ProdutoId1 { get; set; }

        [ForeignKey(nameof(ProdutoId1))]
        public ProdutoModel ProdutoModel1 { get; set; }

        public int ProdutoId2 { get; set; }

        [ForeignKey(nameof(ProdutoId2))]
        public ProdutoModel ProdutoModel2 { get; set; }
    }
}
