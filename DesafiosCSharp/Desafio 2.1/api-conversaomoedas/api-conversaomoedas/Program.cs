using System;
using System.Threading.Tasks;

namespace ConversorMoedas
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string moedaOrigem="";
            string moedaDestino="";
            decimal valor;
            do
            {
                try
                {
                    Console.WriteLine("============ Conversão de moedas ============");
                    Console.Write("Digite a moeda de origem (ex: USD, BRL, EUR): ");
                    moedaOrigem = Console.ReadLine()?.ToUpper();

                    /*if (string.IsNullOrEmpty(moedaOrigem))
                    {
                        Console.WriteLine("Valor vazio, fim do programa");
                        Environment.Exit(0);  
                    }*/

                    Console.Write("Digite a moeda de destino (ex: USD, BRL, EUR): ");
                    moedaDestino = Console.ReadLine()?.ToUpper();

                    Console.Write("Digite o valor a ser convertido: ");
                    valor = decimal.Parse(Console.ReadLine());

                    var resultado = await ConversorService.RealizarConversao(moedaOrigem, moedaDestino, valor);

                    decimal valorConvertido = resultado.conversion_result;

                    Console.WriteLine($"\nValor convertido: {valorConvertido:F2} {moedaDestino}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            } while (!string.IsNullOrEmpty(moedaOrigem));
        }
    }
}
