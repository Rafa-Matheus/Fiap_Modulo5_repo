using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.Donation1.Models
{
    [Table("TipoProduto")] // Indica que a classe representa a tabela
    public class TipoProdutoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Vai gerando Id incremental
        public int TipoProdutoId { get; set; }

        // [Column("NomeTipoProduto")] // Associa a propriedade à coluna do banco
        [Required(ErrorMessage ="O nome para o tipo do produto é obrigatório.")] // Não aceita nulo
        [StringLength(55)] // Tamanho da string
        [MinLength(3)] // Tamanho mínimo para o campo
        [Display(Name ="Nome do tipo de produto: ")]
        public string Nome { get; set; }

        [StringLength(256)]
        public string? Descricao { get; set; }

        [NotMapped] // Anotação para propriedade que NÃO É uma entidade do banco
        public string? Token { get; set; }
    }
}
