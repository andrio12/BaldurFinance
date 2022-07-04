namespace BaldurFinance.Data
{
    public class StockMarket
    {
        public class Stock
        {
            public Info? Info { get; set; }
            public Price? Price { get; set; }
        }

        public class Info
        {
            public string? Type { get; set; }
            public string? Title { get; set; }
            public string? Ticker { get; set; }

        }

        public class Price
        {
            public string? Currency { get; set; }
            public float PreviousClose { get; set; }

        }
    }
}
