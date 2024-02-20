using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMercado.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Column("CategoriaId")]
        [Display(Name = "Código da categoria")]
        public int CategoriaId { get; set; }

        [Column("NomeCategoria")]
        [Display(Name = "Nome da categoria")]
        public string NomeCategoria { get; set; } = string.Empty;
    }
}
