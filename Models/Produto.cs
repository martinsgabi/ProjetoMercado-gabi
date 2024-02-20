using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMercado.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Column("ProdutoId")]
        [Display(Name = "Código do produto")]
        public int ProdutoId { get; set; }

        [Column("NomeProduto")]
        [Display(Name = "Nome do produto")]
        public string NomeProduto { get; set; } = string.Empty;

        [Column("PrecoProduto")]
        [Display(Name = "Preço do produto")]
        public double PrecoProduto { get; set; }

        [Column("QntEstoqueProduto")]
        [Display(Name = "Estoque do produto")]
        public int QntEstoqueProduto { get; set; }

        [Column("NumeroDoCodigo")]
        [Display(Name = "Numero do código de barra")]
        public int NumeroDoCodigo { get; set; }

        [ForeignKey("CategoriaId")]
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        [ForeignKey("FornecedoresId")]
        public int FornecedoresId { get; set; }
        public Fornecedores? Fornecedores { get; set; }
    }
}
