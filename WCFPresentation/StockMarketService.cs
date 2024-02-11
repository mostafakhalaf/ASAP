using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WCFPresentation
{
    public class StockMarketService : IStockMarketService
    {
        private readonly HttpClient _client;
        //private readonly DatabaseContext _dbContext; // Assuming you have a database context set up

        public StockMarketService()
        {
            _client = new HttpClient();
            //_dbContext = new DatabaseContext(); // Initialize your database context
        }
        public async Task<ResultValues> FetchAndStoreStockData(string symbol, string startDate)
        {
            ResultValues result = new ResultValues()
            {
                StatusCode = "400",
                Message = "An Error Occured",
                Success = false,
            };
            try
            {
                if (string.IsNullOrEmpty(symbol))
                {
                    symbol = "AAPL";
                }
                if (string.IsNullOrEmpty(startDate))
                {
                    startDate = "2023-01-09";
                }
                var date = System.DateTime.Today;
                var apiKey = "phiw002NbH8I8bL1gXRP8NVX1kR5pT_3"; // Replace with your Polygon.io API key
                var apiUrl = $"https://api.polygon.io/v2/aggs/ticker/{symbol}/range/1/day/{startDate}/{date.ToString("yyyy-MM-dd")}?adjusted=true&sort=asc&limit=120&apiKey={apiKey}";

                var response = await _client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var marketData = JsonConvert.DeserializeObject<PolygonApiResponse>(jsonString);
                    //code to send the tesult to stock api controller
                    result.ReturnObject = marketData;
                    result.StatusCode = "200";
                    result.Message = "Successfully got learning objects";
                    result.Success = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }
    }
}
