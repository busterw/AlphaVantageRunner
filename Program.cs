using System;
using System.Threading.Tasks;
using AVRunner.Controllers;
using AVRunner.Responses;

namespace AVRunner
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Test");
            
            var intraDayRequest = new Request{
                Function = "TIME_SERIES_INTRADAY",
                Symbol = "MSFT",
                Interval = "5min",
                Uri = "https://www.alphavantage.co/query"
            };

            var intraDayResponse = await HttpRequestSender.SendRequest(intraDayRequest);

            var intraDayResultList = ResponseHandler.HandleIntraDayResponse(intraDayResponse);
        }
    }
}
