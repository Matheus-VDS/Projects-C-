using System;
using System.Threading.Tasks;

namespace api_conversaomoedas.Services
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string moedaOrigem="";
            string moedaDestino;
            decimal valor, novo_valor, taxa;
            bool valida = false;
            MoedaValidacao Error = new MoedaValidacao();  
            Console.WriteLine("============ Conversão de moedas ============");
            do
            {
                try
                {
                    Console.Write("Digite a moeda de origem (ex: USD, BRL, EUR, AUD, BGN, CAD, CHF, CNY, EGP, GBP): ");
                    moedaOrigem = Console.ReadLine()?.ToUpper();
                    Error.TerminaPrograma(moedaOrigem);

                    Console.Write("Digite a moeda de destino (ex: USD, BRL, EUR, AUD, BGN, CAD, CHF, CNY, EGP, GBP): ");
                    moedaDestino = Console.ReadLine()?.ToUpper();
                    if (Error.MoedaIgual(moedaOrigem, moedaDestino) == true)
                        continue;
                    if (Error.MoedaTamanho(moedaOrigem, moedaDestino) == true)
                        continue;

                    Console.Write("Digite o valor a ser convertido: ");
                    valor = decimal.Parse(Console.ReadLine());
                    if (valor <= 0)
                    {
                        novo_valor = Error.MoedaNegativa(valida, valor);
                        valor = novo_valor;
                    }

                    var resultado = await ConversorService.RealizarConversao(moedaOrigem, moedaDestino, valor);

                    decimal valorConvertido = resultado.conversion_result;
                    taxa = resultado.conversion_rate;

                    Console.WriteLine($"\nValor convertido de {moedaOrigem} para {moedaDestino}: {valorConvertido:F2} {moedaDestino}\nTaxa de conversão: {taxa:F6}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            } while (!string.IsNullOrWhiteSpace(moedaOrigem));
        }
    }
}
