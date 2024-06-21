using backend.Dtos.Stodk;
using backend.Interfaces;
using backend.Mappers;
using backend.Models;
using Newtonsoft.Json;

namespace backend.Services
{
    public class FMPService : IFMPService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public FMPService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<Stock> FindStockBySymbolAsync(string symbol)
        {
            try
            {
                //var result = await _httpClient.GetAsync($"https://financialmodelingprep.com/api/v3/profile/AAPL");
                var result = await _httpClient.GetAsync($"https://financialmodelingprep.com/api/v3/profile/{symbol}?apikey={_configuration["FMPKey"]}");
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    var tasks = JsonConvert.DeserializeObject<FMPStock[]>(content);
                    var stock = tasks![0];
                    if (stock != null)
                    {
                        return stock.ToStockFromFMP();
                    }
                    return null!;
                }
                return null!;
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex);
                return null!;
            }
        }
    }
}
