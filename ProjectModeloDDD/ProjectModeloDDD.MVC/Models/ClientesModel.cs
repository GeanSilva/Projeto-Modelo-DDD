using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectModeloDDD.MVC.Models
{
    public class ClientesModel
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(150,ErrorMessage = "Maxímo {0} caracteres")]
        [MinLength(4,ErrorMessage = "Minímo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo sobrenome")]
        [MaxLength(150,ErrorMessage = "Maxímo {0} caracteres")]
        [MinLength(4,ErrorMessage = "Minímo {0} caracteres")]
        public string Sobrenome { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataDeCadastro { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(100,ErrorMessage = "Maxímo {0} caracteres")]
        [EmailAddress(ErrorMessage = "Informe um E-mail válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        public bool Ativo { get; set; }
        public virtual IEnumerable<ProdutosModel> Produtos { get; set; }
    }
}