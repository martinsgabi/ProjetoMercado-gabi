using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMercado.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Column("ClienteId")]
        [Display(Name = "Código do cliente")]
        public int ClienteId { get; set; }

        [Column("NomeCliente")]
        [Display(Name = "Nome do cliente")]
        public string NomeCliente { get; set; } = string.Empty;

        [Column("TelefoneCliente")]
        [Display(Name = "Telefone")]
        public int TelefoneCliente { get; set; } 

        [Column("CPFCliente")]
        [Display(Name = "CPF")]
        public int CPFCliente { get; set; }

        [Column("NumeroDoCartao")]
        [Display(Name = "Número do cartão")]
        public int NumeroDoCartao { get; set; }
    }
}
