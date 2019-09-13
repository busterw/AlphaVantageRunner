using System;
using System.ComponentModel;
using System.Threading.Tasks;
using AVRunner.Controllers;
using AVRunner.Responses;
using AVRunner.Responses.Models;
using CliFx;
using CliFx.Services;

namespace AVRunner
{
    public static class Program
    {
        public async static Task<int> Main(string[] args)
        {

            //await DebugTestSpace();

            return new CliApplicationBuilder()
            .AddCommandsFromThisAssembly()
            .Build()
            .RunAsync(args).Result;
        }

        public async static Task DebugTestSpace()
        {
            var request = new Request
            {
                Symbol = "MSFT",
                Function = "GLOBAL_QUOTE"
            };

            var response = await HttpRequestSender.SendRequest(request);

            var responseObject = ResponseHandler.HandleQuoteResponse(response);

            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(responseObject))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(responseObject);
                Console.WriteLine("{0}={1}", name, value);
            }
        }
    }
}
