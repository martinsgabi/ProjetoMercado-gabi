using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMercado.Models
{
    [Table("Pagamento")]
    public class Pagamento
    {
        [Column("PagamentoId")]
        [Display(Name = "Código do pagamento")]
        public int PagamentoId { get; set; }

        [Column("FormaDePagamento")]
        [Display(Name = "Forma de pagamento")]
        public string FormaDePagamento { get; set; } = string.Empty;
    }
}
