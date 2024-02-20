using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMercado.Models
{
    //[Keyless]
    [Table("VendaHasProduto")]
    public class VendaHasProduto
    {
        [Column("VendaHasProdutoId")]
        [Display(Name = "Código da venda do produto")]
        public int VendaHasProdutoId { get; set; }

        [ForeignKey("VendaId")]
        public int VendaId { get; set; }
        public Venda? Venda { get; set; }

        [ForeignKey("ProdutoId")]
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }

        [Column("QntVendaHas")]
        [Display(Name = "Quantidade")]
        public int QntVendaHas { get; set; }
    }
}