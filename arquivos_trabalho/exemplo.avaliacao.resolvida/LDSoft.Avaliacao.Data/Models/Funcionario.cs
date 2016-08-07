using System;
using System.Collections.Generic;

namespace LDSoft.Avaliacao.Data.Models
{
    public partial class Funcionario
    {
        public Funcionario()
        {
            this.Tarefas = new List<Tarefa>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Situacao { get; set; }
        public virtual ICollection<Tarefa> Tarefas { get; set; }
    }
}