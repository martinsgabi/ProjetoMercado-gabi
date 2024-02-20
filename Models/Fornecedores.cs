using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMercado.Models
{
    [Table("Fornecedores")]
    public class Fornecedores
    {
        [Column("FornecedoresId")]
        [Display(Name = "Código dos fornecedores")]
        public int FornecedoresId { get; set; }

        [Column("NomeFornecedores")]
        [Display(Name = "Nome dos fornecedores")]
        public string NomeFornecedores { get; set; } = string.Empty;

        [Column("CNPJFornecedores")]
        [Display(Name = "CNPJ")]
        public int CNPJFornecedores { get; set; } 
    }
}
