//Autor: Matheus Vieira de Souza
using System;

class Piramide
{
    private int n;

    public int valida
    {
        get 
        { 
            return n; 
        }
        set
        {
            if (value < 1)
            {
                throw new ArgumentException("O número precisa ser igual ou maior do que 1");
            }
            n = value;
        }
    }

    public Piramide(int n)
    {
        valida = n;
    }

    // Método que desenha a pirâmide
    public void Desenha()
    {
        for (int i = 1; i <= valida; i++)
        {
            // Imprime espaços para centralizar a pirâmide
            Console.Write(new string(' ', valida - i));

            // Imprime a primeira metade da linha
            for (int j = 1; j <= i; j++)
            {
                Console.Write(j);
            }

            // Imprime a segunda metade da linha
            for (int j = i - 1; j >= 1; j--)
            {
                Console.Write(j);
            }

            // Pula para a próxima linha
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
    Console.Write("Informe um número: ");
    int n = int.Parse(Console.ReadLine());
    Piramide piramide = new Piramide(n);
    piramide.Desenha();
    }
}
