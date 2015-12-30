using System;
using System.Collections.Generic;
namespace ProjectModeloDDD.Domain.Entidades
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome  { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataDeCadastro  { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public virtual IEnumerable<Produto> Produtos { get; set; }
        public bool ClienteEspecial(Cliente cliente)
        {
            return cliente.Ativo && DateTime.Now.Year - cliente.DataDeCadastro.Year >= 5;
        }

    }
}
