//Autor: Matheus Vieira de Souza
using System;
using Classes;
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

        bool igual = vertice.is_Equal(vertice2);
        if(igual==true) Console.Write("\nOs vértices são iguais!\n");
        else Console.Write("\nOs vértices são diferentes!\n");
        Console.WriteLine("A distancia entre os vértices é: "+vertice.Distancia(vertice2)+"\n");
        vertice.Move(vertice);
    }
}
