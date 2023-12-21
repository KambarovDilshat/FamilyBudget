using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FamilyBudget.Infrastructure.Services
{
    public class CurrencyConverterService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "t"; //  API URL

        public CurrencyConverterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<decimal> ConvertCurrencyAsync(decimal amount, string fromCurrency, string toCurrency)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_apiUrl}?base={fromCurrency}&symbols={toCurrency}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var rates = JsonConvert.DeserializeObject<CurrencyRates>(content);

                return amount * rates.Rates[toCurrency];
            }
            catch (Exception ex)
            {
                // Обработка ошибок
                throw new InvalidOperationException("Произошла ошибка при конвертации валюты", ex);
            }
        }

        private class CurrencyRates
        {
            public Dictionary<string, decimal> Rates { get; set; }
        }
    }
}
