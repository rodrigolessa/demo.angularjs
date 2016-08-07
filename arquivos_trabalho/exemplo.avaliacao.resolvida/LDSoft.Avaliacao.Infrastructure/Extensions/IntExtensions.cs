using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDSoft.Avaliacao.Infrastructure.Extensions
{
    public static class IntExtensions
    {
        public static bool EhPar(this int numero)
        {
            return (numero % 2 == 0);
        }
    }
}
