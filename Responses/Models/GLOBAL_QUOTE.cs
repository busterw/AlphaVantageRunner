using Newtonsoft.Json;

namespace AVRunner.Responses.Models
{
    public class GLOBAL_QUOTE
    {
        [JsonProperty("01. symbol")]
        public string symbol { get; set; }
        [JsonProperty("02. open")]
        public string open { get; set; }
        [JsonProperty("03. high")]
        public string high { get; set; }
        [JsonProperty("04. low")]
        public string low { get; set; }
        [JsonProperty("05. price")]
        public string price { get; set; }
        [JsonProperty("06. volume")]
        public string volume { get; set; }
        [JsonProperty("07. latest trading day")]
        public string latestTradingDay { get; set; }
        [JsonProperty("08. previous close")]
        public string previousClose { get; set; }
        [JsonProperty("09. change")]
        public string change { get; set; }
        [JsonProperty("10. change percent")]
        public string changePercent { get; set; }
    }
}