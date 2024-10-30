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

    public void Desenha()
    {
        for (int i = 1; i <= valida; i++)
        {
            Console.Write(new string(' ', valida - i));

            for (int j = 1; j <= i; j++)
            {
                Console.Write(j);
            }

            for (int j = i - 1; j >= 1; j--)
            {
                Console.Write(j);
            }
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
