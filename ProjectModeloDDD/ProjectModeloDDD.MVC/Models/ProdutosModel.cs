using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectModeloDDD.MVC.Models
{
    public class ProdutosModel
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Nome do produto deve ser informado")]
        [MaxLength(250,ErrorMessage = "Maxímo {0} caractres")]
        [MinLength(4,ErrorMessage = "Minímo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Deve ser informado um valor ")]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal),"0","999999999999")]
        public decimal Valor { get; set; }

        public bool Disponivel { get; set; }
        public int ClienteId { get; set; }
        public virtual ClientesModel Cliente { get; set; }
    }
}