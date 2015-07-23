using System;
using System.Collections.Generic;

namespace demo.apptarefa.domain.Models
{
    public partial class Intervalo
    {
        public long Id { get; set; }
        public int IdPonto { get; set; }
        public Nullable<System.TimeSpan> Entrada { get; set; }
        public Nullable<System.TimeSpan> Saida { get; set; }
        public virtual Ponto Ponto { get; set; }
    }
}
