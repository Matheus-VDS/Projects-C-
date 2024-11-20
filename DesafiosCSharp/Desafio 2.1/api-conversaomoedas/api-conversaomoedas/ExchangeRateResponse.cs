namespace api_conversaomoedas.Services
{
    public class ExchangeRateResponse
    {
        public string result { get; set; }
        public decimal conversion_rate { get; set; }
        public decimal conversion_result { get; set; }
    }
}
