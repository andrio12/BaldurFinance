using Newtonsoft.Json;

namespace BaldurFinance.Data
{
	public class StockMarketService
	{
		public async Task<List<StockMarket.Stock>> GetStockMarketData()
        {
			HttpClient client = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://google-finance4.p.rapidapi.com/search/?q=airbnb&hl=en&gl=US")
			};

			using var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			string body = await response.Content.ReadAsStringAsync();
			
			List<StockMarket.Stock> stocks = new List<StockMarket.Stock>();

			JsonSerializer serializer = new JsonSerializer();
			using (var sr = new StringReader(body))
			using (var reader = new JsonTextReader(sr))
			{
				stocks = serializer.Deserialize<List<StockMarket.Stock>>(reader);
			}

			return stocks ?? new List<StockMarket.Stock>();
        }

    }
}
