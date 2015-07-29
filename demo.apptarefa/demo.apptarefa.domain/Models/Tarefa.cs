using System;
using System.Collections.Generic;

namespace demo.apptarefa.domain.Models
{
    public partial class Tarefa
    {
        public Tarefa()
        {
            this.IntervalosDeTarefas = new List<IntervalosDeTarefa>();
        }

        public int Id { get; set; }
        public int IdFuncionario { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Nullable<bool> Executada { get; set; }
        public Nullable<long> IdIceScrum { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public virtual ICollection<IntervalosDeTarefa> IntervalosDeTarefas { get; set; }
    }
}
