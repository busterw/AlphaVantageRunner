using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AVRunner.Helpers;
using AVRunner.Responses;
using CliFx;
using CliFx.Attributes;
using CliFx.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AVRunner.Controllers
{
    [Command("time", Description = "Displays the opening and closing times of different exchanges.")]
    public class TradingDayController : ICommand
    {
        [CommandOption("name", 'n', IsRequired = false, Description = "The name of the exchange to time check. Leaving blank will display all of them.")]
        public string Name { get; set; }
        private const string TimeFile = @"Data\OpeningTimes.json";

        public async Task ExecuteAsync(IConsole console)
            => TimeWriter(console);

        private static void TimeWriter(IConsole console)
        {
            var timeList = JsonFileToList(TimeFile);

            var timeNow = DateTime.UtcNow;

            foreach (var exchange in timeList)
            {
                if (exchange.ClosingTime > timeNow && exchange.OpeningTime < timeNow)
                {
                    exchange.Status = ConsoleStrings.Open;
                    exchange.TimeToClose = exchange.ClosingTime - DateTime.UtcNow;
                }
                else
                {
                    exchange.Status = ConsoleStrings.Closed;
                    exchange.TimeToOpen = (exchange.OpeningTime.AddDays(1) - timeNow < new TimeSpan(24, 0, 0) ?
                 (exchange.OpeningTime.AddDays(1) - timeNow) :
                 (exchange.OpeningTime - timeNow));
                }

                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(exchange))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(exchange);

                    if (value.ToString() == ConsoleStrings.Open)
                        ConsoleHelper.WriteLineWithColor(console, ConsoleColor.Green, ($"{name} = {value}"));

                    else if (value.ToString() == ConsoleStrings.Closed)
                        ConsoleHelper.WriteLineWithColor(console, ConsoleColor.Red, ($"{name} = {value}"));

                    else if (name == "OpeningTime" || name == "ClosingTime")
                    {
                        var time = DateTime.Parse(value.ToString());
                        console.Output.WriteLine($"{name} = {time.ToShortTimeString()}");
                    }
                    else if (value.Equals(default(TimeSpan)))
                        continue;
                    else console.Output.WriteLine($"{name} = {value}", name, value);
                }
                ConsoleHelper.WriteLineWithColor(console, ConsoleColor.Yellow, ConsoleStrings.Divider);
            }
        }

        private static List<ExchangeTimes> JsonFileToList(string fileLocation)
        {
            using (StreamReader r = new StreamReader(fileLocation))
            {
                string json = r.ReadToEnd();
                var jsonObject = JObject.Parse(json).Children();

                var list = new List<ExchangeTimes>();

                foreach (var jToken in jsonObject)
                    list.Add(jToken.First().ToObject<ExchangeTimes>());

                return list;
            }
        }
    }

}
