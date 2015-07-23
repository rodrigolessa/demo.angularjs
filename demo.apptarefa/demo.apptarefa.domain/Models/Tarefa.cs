using System;
using System.Collections.Generic;

namespace demo.apptarefa.domain.Models
{
    public partial class Tarefa
    {
        public int Id { get; set; }
        public int IdFuncionario { get; set; }
        public string Descricao { get; set; }
        public Nullable<bool> Executada { get; set; }
        public virtual Funcionario Funcionario { get; set; }
    }
}
