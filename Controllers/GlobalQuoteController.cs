using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading.Tasks;
using AVRunner.Helpers;
using AVRunner.Responses;
using AVRunner.Responses.Models;
using CliFx;
using CliFx.Attributes;
using CliFx.Services;

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

            var previousObject = new GLOBAL_QUOTE();

            ConsoleHelper.WriteLineWithColor(console, ConsoleColor.Yellow, DateTime.Now);

            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(responseObject))
            {
                decimal number;

                string name = descriptor.Name;
                object value = descriptor.GetValue(responseObject);

                object previousValue = descriptor.GetValue(previousObject);

                if (decimal.TryParse(value.ToString(), out number))
                    if (decimal.Parse(previousValue.ToString()) < decimal.Parse(value.ToString()))
                        ConsoleHelper.WriteLineWithColor(console, ConsoleColor.Green,("{0}={1}", name, number));
                    else 
                        ConsoleHelper.WriteLineWithColor(console, ConsoleColor.Red,("{0}={1}", name, number));

                else
                    console.Output.WriteLine("{0}={1}", name, value);

            }

            previousObject = responseObject;
        }
    }
}