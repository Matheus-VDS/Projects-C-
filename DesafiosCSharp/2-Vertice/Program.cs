//Autor: Matheus Vieira de Souza
using System;

class Vertice
{
    public double pontoX {get; private set;} 
    public double pontoY {get; private set;}

    public Vertice(double x, double y)
    {
        pontoX = x;
        pontoY = y;
    }

    public double Distancia(Vertice v1, Vertice v2)
    {
        double distancia_X = Math.Abs(v1.pontoX - v2.pontoX);
        double distancia_Y = Math.Abs(v1.pontoY - v2.pontoY);
        return Math.Sqrt(Math.Pow(distancia_X, 2) + Math.Pow(distancia_Y, 2));
    }


    public void Move(Vertice v) 
    {
        Console.Write("Informe nova posição de x para o vértice 1: ");
        double novo_pontoX = Convert.ToDouble(Console.ReadLine());
        Console.Write("Informe nova posição de y para o vértice 1: ");
        double novo_pontoY = Convert.ToDouble(Console.ReadLine());
        Console.Write($"\nA posição do v1({v.pontoX},{v.pontoY}) agora é v1({novo_pontoX},{novo_pontoY})");
        v.pontoX = novo_pontoX;
        v.pontoY = novo_pontoY;
    }
    public void is_Equal(Vertice v1, Vertice v2)
    {
        if (v1.pontoX == v2.pontoX && v1.pontoY == v2.pontoY)
            Console.Write("\nOs vértices são iguais!\n");
        else
            Console.Write("\nOs vértices são diferentes!\n");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Informe valor de x para o vértice 1: ");
        double x = Convert.ToDouble(Console.ReadLine());
        Console.Write("Informe valor de y para o vértice 2: ");
        double y = Convert.ToDouble(Console.ReadLine());
        Console.Write("Informe valor de x para o vértice 2: ");
        double x2 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Informe valor de y para o vértice 2: ");
        double y2 = Convert.ToDouble(Console.ReadLine());
        Vertice vertice = new Vertice(x, y);
        Vertice vertice2 = new Vertice(x2, y2);

        Console.WriteLine("\n"+vertice.Distancia(vertice, vertice2)); 
        vertice.is_Equal(vertice, vertice2);
        vertice.Move(vertice);
    }
}
