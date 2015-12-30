using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectModeloDDD.Domain.Entidades;

namespace ProjectModelo.Infra.EntidadesConfiguração
{
  public  class ClienteConfiguracao : EntityTypeConfiguration<Cliente>
  {
      public ClienteConfiguracao()
      {
          HasKey(c => c.ClienteId);

          Property(c => c.Nome)
              .IsRequired()
              .HasMaxLength(150);

          Property(c => c.Sobrenome)
                .IsRequired()
                .HasMaxLength(150);

          Property(c => c.Email)
                .IsRequired();
      }
  }
}
