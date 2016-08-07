using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LDSoft.Avaliacao.Data.Models.Mapping
{
    public class FuncionarioMap : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            this.Property(t => t.Situacao)
                .IsFixedLength()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("Funcionario");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Situacao).HasColumnName("Situacao");
        }
    }
}
