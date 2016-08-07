using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console1 = System.Console;
using LDSoft.Avaliacao.Infrastructure.Extensions;

namespace LdSoft.Avaliacao.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            console1.WriteLine("1 - Collatz");

            int maiorInicial = 2;
            int maiorSequencia = 0;
            var tempo = Stopwatch.StartNew();
            var sequencias = new Dictionary<int, int>();

            for (int x = 2; x <= 1000000; x++)
            {
                int contador = 1;

                for (int n = x; n > 1; n = CondicaoDeCollatz(n))
                {
                    if (sequencias.ContainsKey(n))
                    {
                        contador += sequencias[n] - 1;
                        break;
                    }

                    contador++;

                    //if (x == 7)
                    //console1.Write(n.ToString() + " > ");
                }

                sequencias.Add(x, contador);

                if (contador > maiorSequencia)
                {
                    maiorInicial = x;
                    maiorSequencia = contador;
                }
            }

            tempo.Stop(); //inicial 6335 milissegundos

            console1.WriteLine(" ");
            console1.WriteLine(" - Número inicial - " + maiorInicial.ToString() + " que produziu uma sequencia com " + maiorSequencia.ToString() + " termos;");
            console1.WriteLine(" - Em " + tempo.ElapsedMilliseconds.ToString() + " milissegundos.");



            console1.WriteLine(" ");
            console1.WriteLine("2 - Ordenação Linq ");

            console1.ReadKey();
        }

        private static int CondicaoDeCollatz(int n)
        {
            return n.EhPar() ? n / 2 : (3 * n) + 1;
        }

    }
}
