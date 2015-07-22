using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace demo.tarefas.domain.Models.Mapping
{
    public class TarefaMap : EntityTypeConfiguration<Tarefa>
    {
        public TarefaMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Descricao)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Tarefa");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.IdFuncionario).HasColumnName("IdFuncionario");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
            this.Property(t => t.Executada).HasColumnName("Executada");

            // Relationships
            this.HasRequired(t => t.Funcionario)
                .WithMany(t => t.Tarefas)
                .HasForeignKey(d => d.IdFuncionario);

        }
    }
}
