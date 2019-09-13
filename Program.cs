using System;
using System.Threading.Tasks;
using AVRunner.Controllers;
using AVRunner.Responses;
using AVRunner.Responses.Models;
using CliFx;

namespace AVRunner
{
    public static class Program
    {
        public static Task<int> Main(string[] args) =>
             new CliApplicationBuilder()
             .AddCommandsFromThisAssembly()
             .Build()
             .RunAsync(args);

        /*/async static Task Main(string[] args)
        {
            var intraDayRequest = new Request
            {
                Function = "TIME_SERIES_INTRADAY",
                Symbol = "MSFT",
                Interval = "5min",
                Uri = "https://www.alphavantage.co/query"
            };

            //var intraDayResponse = await HttpRequestSender.SendRequest(intraDayRequest);

            //var intraDayResultList = ResponseHandler.HandleResponses<TIME_SERIES_INTRADAY>(intraDayResponse);

            var globalQuoteRequest = new Request
            {
                Function = "GLOBAL_QUOTE",
                Symbol = "MSFT"
            };

            var globalQuoteResponse = await HttpRequestSender.SendRequest(globalQuoteRequest);
            var globalQuoteResults = ResponseHandler.HandleQuoteResponse(globalQuoteResponse);
        }*/
    }
}
