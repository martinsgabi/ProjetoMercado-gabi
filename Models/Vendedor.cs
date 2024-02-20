using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMercado.Models
{
    [Table("Vendedor")]
    public class Vendedor
    {
        [Column("VendedorId")]
        [Display(Name = "Código do vendedor")]
        public int VendedorId { get; set; }

        [Column("NomeVendedor")]
        [Display(Name = "Nome do vendedor")]
        public string NomeVendedor { get; set; } = string.Empty;

        [Column("NumeroDoCaixa")]
        [Display(Name = "Caixa")]
        public int NumeroDoCaixa { get; set; } 
    }
}
