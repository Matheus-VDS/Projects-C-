using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConversorMoedas
{
    public class ConversorService
    {
        private const string BASE_URL = "https://v6.exchangerate-api.com/v6";
        private const string API_KEY = "787c96047c1edcf70cdf45b7";

        public static async Task<ExchangeRateResponse> RealizarConversao(string moedaOrigem, string moedaDestino, decimal valor)
        {
            using (var client = new HttpClient())
            {
                string url = $"{BASE_URL}/{API_KEY}/pair/{moedaOrigem}/{moedaDestino}/{valor}";
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao acessar a API");
                }

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                return JsonSerializer.Deserialize<ExchangeRateResponse>(content, options);
            }
        }
    }
}
