using Newtonsoft.Json;

namespace AVRunner.Responses.Models
{
    public class TIME_SERIES_DAILY_ADJUSTED
    {
        [JsonProperty("1. open")]
        public string open { get; set; }
        [JsonProperty("2. high")]
        public string high { get; set; }
        [JsonProperty("3. low")]
        public string low { get; set; }
        [JsonProperty("4. close")]
        public string close { get; set; }
        [JsonProperty("5. adjusted close")]
        public string adjustedClose { get; set; }
        [JsonProperty("6. volume")]
        public string volume { get; set; }
        [JsonProperty("7. dividend amount")]
        public string dividendAmount { get; set; }
        [JsonProperty("8. split coefficient")]
        public string splitCoefficient { get; set; }

    }
}