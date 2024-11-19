using ConversorMoedas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace api_conversaomoedas.Services
{
    class ErrorValidation
    {
        public string MoedaOrigem { get; set; }
        public string MoedaDestino { get; set; }
        public double valor { get; set; }



        public bool MoedaIgual(string MoedaOrigem, string MoedaDestino)
        {
            if (MoedaOrigem.Equals(MoedaDestino) == true)
            {
                Console.WriteLine("Moedas iguais, digite novamente");
                return false;
            }
            return true;
        }
        public bool VaziaMoeda(string MoedaOrigem)
        {
            if (string.IsNullOrEmpty(MoedaOrigem))
            {
                Console.WriteLine("Moeda vazia, fim do programa");
                return false;
            }
            return true;
        }

        public bool MoedaZero(double valor)
        {
            if (valor < 0.0)
            {
                Console.WriteLine("Valor menor que zero, digite o valor novamente");
                return false;
            }
            return true;
        }

        public bool MoedaTamanho(string MoedaOrigem, string MoedaDestino)
        {
            if (MoedaOrigem.Length != 3)
            {
                Console.WriteLine("Moeda de origem inválida, digite novamente");
                return false;
            }
            return true;
        }
    }
}
