using System;
using System.Collections.Generic;
using System.Linq;
//Autor: Matheus Vieira de Souza
namespace Classes
{
    public class ListaIntervalo
    {
        private List<Intervalo> intervalos;

        public ListaIntervalo()
        {
            intervalos = new List<Intervalo>();
        }

        public bool Add(Intervalo intervalo)
        {
            foreach (var i in intervalos)
            {
                if (i.TemIntersecao(intervalo))
                {
                    return false; 
                }
            }

            intervalos.Add(intervalo);
            return true;
        }

        public IReadOnlyList<Intervalo> Intervalos => intervalos.OrderBy(i => i.DataHoraInicial).ToList().AsReadOnly();
    }

    class Program
    {
        static void Main(string[] args)
        {
            ListaIntervalo lista = new ListaIntervalo();

            Intervalo intervalo1 = new Intervalo(new DateTime(2024, 10, 1, 10, 0, 0), new DateTime(2024, 10, 1, 12, 0, 0));
            Intervalo intervalo2 = new Intervalo(new DateTime(2024, 10, 1, 12, 0, 0), new DateTime(2024, 10, 1, 14, 0, 0));
            Intervalo intervalo3 = new Intervalo(new DateTime(2024, 10, 1, 11, 0, 0), new DateTime(2024, 10, 1, 13, 0, 0)); // Intersecta com intervalo1

            if (lista.Add(intervalo1))
                Console.WriteLine("Intervalo 1 adicionado com sucesso.");
            else
                Console.WriteLine("Intervalo 1 não pode ser adicionado.");

            if (lista.Add(intervalo2))
                Console.WriteLine("Intervalo 2 adicionado com sucesso.");
            else
                Console.WriteLine("Intervalo 2 não pode ser adicionado.");

            if (lista.Add(intervalo3))
                Console.WriteLine("Intervalo 3 adicionado com sucesso.");
            else
                Console.WriteLine("Intervalo 3 não pode ser adicionado, pois intersecta com outro intervalo.");

            Console.WriteLine("\nIntervalos na lista:");
            foreach (var intervalo in lista.Intervalos)
            {
                Console.WriteLine($"Início: {intervalo.DataHoraInicial}, Fim: {intervalo.DataHoraFinal}");
            }
        }
    }
}
