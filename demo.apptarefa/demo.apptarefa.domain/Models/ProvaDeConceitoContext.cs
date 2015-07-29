using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using demo.apptarefa.domain.Models.Mapping;

namespace demo.apptarefa.domain.Models
{
    public partial class ProvaDeConceitoContext : DbContext
    {
        static ProvaDeConceitoContext()
        {
            Database.SetInitializer<ProvaDeConceitoContext>(null);
        }

        public ProvaDeConceitoContext()
            : base("Name=ProvaDeConceitoContext")
        {
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Intervalo> Intervaloes { get; set; }
        public DbSet<IntervalosDeTarefa> IntervalosDeTarefas { get; set; }
        public DbSet<Ponto> Pontoes { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FuncionarioMap());
            modelBuilder.Configurations.Add(new IntervaloMap());
            modelBuilder.Configurations.Add(new IntervalosDeTarefaMap());
            modelBuilder.Configurations.Add(new PontoMap());
            modelBuilder.Configurations.Add(new TarefaMap());
        }
    }
}
