
using System.Data.Entity.ModelConfiguration;
using ProjectModeloDDD.Domain.Entidades;

namespace ProjectModelo.Infra.EntidadesConfiguração
{
   public class ProdutoConfiguracao : EntityTypeConfiguration<Produto>
   {
       public ProdutoConfiguracao()
       {
           HasKey(p => p.ProdutoId);

           Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(250);

           Property(p => p.Valor)
               .IsRequired();

           HasRequired(p => p.Cliente)
               .WithMany()
               .HasForeignKey(p => p.ClienteId);
       }
   }
}
