namespace AVRunner.Controllers
{
    public class Request
    {
        public string Function { get; set; }
        public string Symbol { get; set; }
        public string Interval { get; set; }
        public string OutputSize { get; set; }
        public string DataType { get; set; } = "json";
        public string ApiKey { get; } = "7Q4ACODWA2G1MO7X";
        public string Uri { get; set; } = "https://www.alphavantage.co/query";
    }
}