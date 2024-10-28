//Autor: Matheus Vieira de Souza
using System;
using Classes;
using System;

namespace Classes
{
    public class Triangulo
    {
        public Vertice Vertice1 { get; private set; }
        public Vertice Vertice2 { get; private set; }
        public Vertice Vertice3 { get; private set; }

        public Triangulo(Vertice v1, Vertice v2, Vertice v3)
        {
            Vertice1 = v1;
            Vertice2 = v2;
            Vertice3 = v3;

            if (v1 == null || v2 == null || v3 == null)
            {
                throw new ArgumentNullException("Os vértices não podem ser nulos.");
            }

            if (!forma_Triangulo())
            {
                throw new ArgumentException("Os vértices não formam um triângulo.");
            }
        }

        public enum TipoTriangulo
        {
            Equilatero,
            Isosceles,
            Escaleno
        }

        private bool forma_Triangulo()
        {
            double a = Vertice1.Distancia(Vertice2);
            double b = Vertice2.Distancia(Vertice3);
            double c = Vertice3.Distancia(Vertice1);
            return (a + b > c) && (a + c > b) && (b + c > a);
        }

        public bool triangle_isEqual(Triangulo t)
        {
            return (Vertice1.is_Equal(t.Vertice1) &&
                    Vertice2.is_Equal(t.Vertice2) &&
                    Vertice3.is_Equal(t.Vertice3)) ||
                   (Vertice1.is_Equal(t.Vertice2) &&
                    Vertice2.is_Equal(t.Vertice3) &&
                    Vertice3.is_Equal(t.Vertice1)) ||
                   (Vertice1.is_Equal(t.Vertice3) &&
                    Vertice2.is_Equal(t.Vertice1) &&
                    Vertice3.is_Equal(t.Vertice2));
        }

        public double Perimetro
        {
            get
            {
                double a = Vertice1.Distancia(Vertice2);
                double b = Vertice2.Distancia(Vertice3);
                double c = Vertice3.Distancia(Vertice1);
                return a + b + c;
            }
        }

        public TipoTriangulo Tipo
        {
            get
            {
                double a = Vertice1.Distancia(Vertice2);
                double b = Vertice2.Distancia(Vertice3);
                double c = Vertice3.Distancia(Vertice1);

                if (a == b && b == c)
                    return TipoTriangulo.Equilatero;
                else if (a == b || b == c || a == c)
                    return TipoTriangulo.Isosceles;
                else
                    return TipoTriangulo.Escaleno;
            }
        }
        public double Area
        {
            get
            {
                double a = Vertice1.Distancia(Vertice2);
                double b = Vertice2.Distancia(Vertice3);
                double c = Vertice3.Distancia(Vertice1);
                double S = Perimetro / 2;
                return Math.Sqrt(S * (S - a) * (S - b) * (S - c));
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Informe os vértices do triângulo 1:");
        Console.Write("Informe valor de x para o vértice 1: ");
        double x1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Informe valor de y para o vértice 1: ");
        double y1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Informe valor de x para o vértice 2: ");
        double x2 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Informe valor de x para o vértice 2: ");
        double y2 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Informe valor de y para o vértice 3: ");
        double x3 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Informe valor de z para o vértice 3: ");
        double y3 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Informe os vértices do triângulo 2:");
        Console.Write("Informe valor de x para o vértice 1: ");
        double x4 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Informe valor de y para o vértice 1: ");
        double y4 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Informe valor de x para o vértice 2: ");
        double x5 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Informe valor de x para o vértice 2: ");
        double y5 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Informe valor de y para o vértice 3: ");
        double x6 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Informe valor de z para o vértice 3: ");
        double y6 = Convert.ToDouble(Console.ReadLine());

        Vertice v1 = new Vertice(x1, y1);
        Vertice v2 = new Vertice(x2, y2);
        Vertice v3 = new Vertice(x3, y3);
        Vertice v4 = new Vertice(x4, y4);
        Vertice v5 = new Vertice(x5, y5);
        Vertice v6 = new Vertice(x6, y6);

        Triangulo t1 = new Triangulo(v1, v2, v3);
        Triangulo t2 = new Triangulo(v4, v5, v6);

        Console.WriteLine($"Perímetro: {t1.Perimetro}");
        Console.WriteLine($"Tipo: {t1.Tipo}");
        Console.WriteLine($"Área: {t1.Area}");

        // Verificando se os triângulos são iguais
        if (t1.triangle_isEqual(t2))
        {
            Console.WriteLine("Os triângulos são iguais.");
        }
        else
        {
            Console.WriteLine("Os triângulos são diferentes.");
        }
    }
}