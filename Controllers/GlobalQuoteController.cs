using System;
using System.ComponentModel;
using System.Threading.Tasks;
using AVRunner.Helpers;
using AVRunner.Responses;
using CliFx;
using CliFx.Attributes;
using CliFx.Services;
using System.Linq;

namespace AVRunner.Controllers
{
    [Command("global", Description = "A lightweight alternative to the time series APIs, this service returns the latest price and volume information for a security of your choice.")]
    public class GlobalQuoteController : ICommand
    {
        [CommandOption("symbol", 's', IsRequired = true, Description = "The name of the equity of your choice.")]
        public string Symbol { get; set; }

        public async Task ExecuteAsync(IConsole console)
        {
            var request = new Request
            {
                Symbol = Symbol,
                Function = "GLOBAL_QUOTE"
            };

            var response = await HttpRequestSender.SendRequest(request);

            var responseObject = ResponseHandler.HandleQuoteResponse(response);

            ConsoleHelper.WriteLineWithColor(console, ConsoleColor.Yellow, DateTime.Now);

            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(responseObject))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(responseObject);
 
                if (value.ToString().Contains('%') && value.ToString().Contains('-'))
                        ConsoleHelper.WriteLineWithColor(console, ConsoleColor.Red, ($"{name} = {value}"));
                else if (value.ToString().Contains('%'))
                        ConsoleHelper.WriteLineWithColor(console, ConsoleColor.Green, ($"{name} = {value}"));
                else
                    console.Output.WriteLine("{0}={1}", name, value);
            }
        }
    }
}