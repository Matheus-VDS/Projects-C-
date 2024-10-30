//Autor: Matheus Vieira de Souza
using Classes;
using System;
using System.Collections.Generic;

namespace Classes
{
    public class Poligono
    {
        private List<Vertice> vertices;

        public Poligono(List<Vertice> verticesIniciais)
        {
            if (verticesIniciais.Count < 3)
            {
                throw new ArgumentException("Um polígono deve ter pelo menos 3 vértices.");
            }
            vertices = new List<Vertice>(verticesIniciais);
        }

        public int QuantidadeDeVertices => vertices.Count;

        public bool AddVertice(Vertice v)
        {
            foreach (var vertice in vertices)
            {
                if (vertice.is_Equal(v))
                {
                    return false; 
                }
            }
            vertices.Add(v);
            return true;
        }

        public void RemoveVertice(Vertice v)
        {
            if (vertices.Count <= 3)
                throw new InvalidOperationException("Um polígono deve ter pelo menos 3 vértices.");
            else
                vertices.Remove(v);
        }
        

        public double Perimetro()
        {
            double perimetro = 0;
            for (int i = 0; i < vertices.Count; i++)
            {
                Vertice verticeAtual = vertices[i];
                Vertice proximoVertice = vertices[(i + 1) % vertices.Count];
                perimetro += verticeAtual.Distancia(proximoVertice);
            }
            return perimetro;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Vertice> vertices = new List<Vertice>();
        int numeroVertices = Convert.ToInt32(Console.ReadLine());

        if (numeroVertices < 3)
        {
            Console.WriteLine("Um polígono deve ter pelo menos 3 vértices.");
            return;
        }

        for (int i = 0; i < numeroVertices; i++)
        {
            Console.Write($"Informe valor de x para o vértice {i}: ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.Write($"Informe valor de y para o vértice {i}: ");
            double y = Convert.ToDouble(Console.ReadLine());

            Vertice vertice = new Vertice(x, y);
            vertices.Add(vertice);
        }
        Poligono poligono = new Poligono(vertices);

        Console.WriteLine($"\nO polígono possui {poligono.QuantidadeDeVertices} vértices.");

        Console.WriteLine("\nTentando adicionar um novo vértice ao polígono:");
        Vertice novoVertice = new Vertice(10, 10);
        if (poligono.AddVertice(novoVertice))
        {
            Console.WriteLine("Vértice adicionado com sucesso.");
        }
        else
        {
            Console.WriteLine("O vértice já existe no polígono.");
        }

        Console.WriteLine($"\nPerímetro do polígono: {poligono.Perimetro()}");

        Console.WriteLine("Informe um vértice para ser removido: ");
        poligono.RemoveVertice(vertices[0]);
        Console.WriteLine($"O polígono agora possui {poligono.QuantidadeDeVertices} vértices.");
    }
}

