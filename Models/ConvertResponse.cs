using System.Text.Json.Serialization;

namespace CurrencyConverterApi.Models
{
    public class ConvertResponse
    {
        public decimal ExchangeRate { get; set; }
        public decimal ConvertedAmount { get; set; }
    }
}
