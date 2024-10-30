//Autor: Matheus Vieira de Souza

using System;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime inicio1 = new DateTime(2024, 10, 1, 14, 0, 0);
            DateTime fim1 = new DateTime(2024, 10, 1, 16, 0, 0);
            Intervalo intervalo1 = new Intervalo(inicio1, fim1);

            DateTime inicio2 = new DateTime(2024, 10, 1, 15, 0, 0);
            DateTime fim2 = new DateTime(2024, 10, 1, 17, 0, 0);
            Intervalo intervalo2 = new Intervalo(inicio2, fim2);

            Console.WriteLine($"Duração do intervalo 1: {intervalo1.Duracao}");

            if (intervalo1.TemIntersecao(intervalo2))
                Console.WriteLine("Os intervalos têm interseção.");
            else
                Console.WriteLine("Os intervalos não têm interseção.");

            if (intervalo1.EhIgual(intervalo2))
                Console.WriteLine("Os intervalos são iguais.");
            else
                Console.WriteLine("Os intervalos são diferentes.");
        }
    }
}