
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace api_conversaomoedas.Services
{
    class CoinErrorValidation
    {
        public string MoedaOrigem { get; set; }
        public string MoedaDestino { get; set; }
        public decimal valor { get; set; }
        public decimal taxa { get; set; }
        bool valida { get; set; }
        public CoinErrorValidation() { }

        public bool MoedaIgual(string MoedaOrigem, string MoedaDestino)
        {
            if (MoedaOrigem.Equals(MoedaDestino) == true)
            {
                Console.WriteLine("Moedas iguais, digite novamente");
                return true;
            }
            return false;
        }
        public void TerminaPrograma(string MoedaOrigem)
        {
            if (string.IsNullOrWhiteSpace(MoedaOrigem))
            {
                Console.WriteLine("Moeda de origem vazia, fim do programa");
                Environment.Exit(0);
            }
        }

        public decimal MoedaNegativa(bool valida, decimal valor)
        {
            while (valida == false) {  
                if (valor <= 0)
                {
                    Console.WriteLine("Valor menor ou igual a zero, digite o valor novamente:");
                    valor = decimal.Parse(Console.ReadLine());
                }
                else
                    valida = true;
            }
            return valor;
        }

        public bool MoedaTamanho(string MoedaOrigem, string MoedaDestino)
        {
            if ((MoedaOrigem.Length | MoedaDestino.Length) != 3)
            {
                Console.WriteLine("Moeda de origem e destino devem conter 3 caracteres, digite novamente");
                return true;
            }
            return false;
        }
        public decimal MoedaArredondamento(decimal valor)
        {
            return Math.Round(valor, 2);
        }

        public void ApresentacaoTaxa(decimal taxa)
        {
            Console.WriteLine();
        }
    }
}
