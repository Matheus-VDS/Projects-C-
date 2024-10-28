namespace Classes
{
    public class Vertice
    {
        public double pontoX { get; private set; }
        public double pontoY { get; private set; }

        public Vertice(double x, double y)
        {
            pontoX = x;
            pontoY = y;
        }

        public double Distancia(Vertice v2)
        {
            double distancia_X = Math.Abs(pontoX - v2.pontoX);
            double distancia_Y = Math.Abs(pontoY - v2.pontoY);
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
        public bool is_Equal(Vertice v2)
        {
            if (pontoX == v2.pontoX && pontoY == v2.pontoY)
                return true;
            else
                return false;
        }
    }
}
