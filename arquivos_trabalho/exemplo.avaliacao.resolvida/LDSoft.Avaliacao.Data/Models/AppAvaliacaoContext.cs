using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using LDSoft.Avaliacao.Data.Models.Mapping;

namespace LDSoft.Avaliacao.Data.Models
{
    public partial class AppAvaliacaoContext : DbContext
    {
        static AppAvaliacaoContext()
        {
            Database.SetInitializer<AppAvaliacaoContext>(null);
        }

        public AppAvaliacaoContext()
            : base("Name=AppAvaliacaoContext")
        {
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FuncionarioMap());
            modelBuilder.Configurations.Add(new TarefaMap());
        }
    }
}
