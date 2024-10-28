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

        public bool AddVertice(Vertice novoVertice)
        {
            foreach (var vertice in vertices)
            {
                if (vertice.is_Equal(novoVertice))
                {
                    return false; // Vértice já existe
                }
            }
            vertices.Add(novoVertice);
            return true;
        }

        public void RemoveVertice(Vertice verticeARemover)
        {
            if (vertices.Count <= 3)
                throw new InvalidOperationException("Um polígono deve ter pelo menos 3 vértices.");
            else
                vertices.Remove(verticeARemover);
        }
        

        public double Perimetro()
        {
            double perimetro = 0;
            for (int i = 0; i < vertices.Count; i++)
            {
                Vertice verticeAtual = vertices[i];
                Vertice proximoVertice = vertices[(i + 1) % vertices.Count]; // Conecta o último ao primeiro
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

        // Coletando as coordenadas dos vértices
        for (int i = 1; i <= numeroVertices; i++)
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

        // Adicionando um novo vértice e verificando se foi adicionado com sucesso
        Console.WriteLine("\nTentando adicionar um novo vértice ao polígono:");
        Vertice novoVertice = new Vertice(10, 10); // exemplo de novo vértice
        if (poligono.AddVertice(novoVertice))
        {
            Console.WriteLine("Vértice adicionado com sucesso.");
        }
        else
        {
            Console.WriteLine("O vértice já existe no polígono.");
        }

        // Exibindo o perímetro do polígono
        Console.WriteLine($"\nPerímetro do polígono: {poligono.Perimetro()}");

        // Tentando remover um vértice
        //Console.WriteLine("\nRemovendo um vértice:");
        poligono.RemoveVertice(vertices[0]); // Removendo o primeiro vértice
        Console.WriteLine("Vértice removido com sucesso.");
        Console.WriteLine($"O polígono agora possui {poligono.QuantidadeDeVertices} vértices.");
    }
}

