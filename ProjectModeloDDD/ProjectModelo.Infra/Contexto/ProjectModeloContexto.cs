using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using ProjectModelo.Infra.EntidadesConfiguração;
using ProjectModeloDDD.Domain.Entidades;

namespace ProjectModelo.Infra.Contexto
{
   public class ProjectModeloContexto : DbContext
    {
       public ProjectModeloContexto()
            :base("ProjetoModelo")
       {        
       }
       public DbSet<Cliente>Clintes{ get; set; }
       public DbSet<Produto>Produtos{ get; set; }

       protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
           modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
           modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
           modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

           modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

           modelBuilder.Configurations.Add(new ClienteConfiguracao());
           modelBuilder.Configurations.Add(new ProdutoConfiguracao());
        }

       public virtual int SaveChagens()
       {
           foreach (var entry   in ChangeTracker.Entries().Where(entry =>entry.GetType().GetProperty("DataDeCadastro") != null))
           {
               if (entry.State == EntityState.Added)
               {
                   entry.Property("DataDeCadastro").CurrentValue = DateTime.Now;
               }

               if (entry.State == EntityState.Modified)
               {
                   entry.Property("DataDeCadastro").IsModified = false;
               }
           }

           return base.SaveChanges();
       }
    }
}
