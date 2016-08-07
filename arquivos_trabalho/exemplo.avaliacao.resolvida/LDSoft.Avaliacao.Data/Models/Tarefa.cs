using System;
using System.Collections.Generic;

namespace LDSoft.Avaliacao.Data.Models
{
    public partial class Tarefa
    {
        public int Id { get; set; }
        public int IdFuncionario { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Nullable<bool> Executada { get; set; }
        public string Situacao { get; set; }
        public virtual Funcionario Funcionario { get; set; }
    }
}
