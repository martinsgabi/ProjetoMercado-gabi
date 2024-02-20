using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMercado.Models
{
    [Table("Venda")]
    public class Venda
    {
        [Column("VendaId")]
        [Display(Name = "Código de venda")]
        public int VendaId { get; set; }

        [Column("ValorTotal")]
        [Display(Name = "Valor total")]
        public double ValorTotal { get; set; }

        [Column("DataVenda")]
        [Display(Name = "Data da venda")]
        public DateTime DataVenda { get; set; }

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        [ForeignKey("VendedorId")]
        public int VendedorId { get; set; }
        public Vendedor? vendedor { get; set; }

        [ForeignKey("PagamentoId")]
        public int PagamentoId { get; set; }
        public Pagamento? Pagamento { get; set; }


        [NotMapped]
        public List<VendaHasProduto>? ProdutosList { get; set; }
    }
}
