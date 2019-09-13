using System.Threading.Tasks;
using AVRunner.Responses;
using AVRunner.Responses.Models;
using CliFx;
using CliFx.Attributes;
using CliFx.Services;

namespace AVRunner.Controllers
{
    [Command("series", Description = "Request a time series for a certain asset")]
    public class TimeSeriesConsoleController : ICommand
    {
        [CommandOption("function", 'f', IsRequired = true, Description = "The time series of your choice."+
        "(TIME_SERIES_INTRADAY,"+
         "TIME_SERIES_DAILY,"+ 
         "TIME_SERIES_DAILY_ADJUSTED,"+
         "TIME_SERIES_WEEKLY,"+
         " TIME_SERIES_WEEKLY_ADJUSTED,"+
         "TIME_SERIES_MONTHLY,"+
         " TIME_SERIES_MONTHLY_ADJUSTED)")]
        public string Function { get; set; }
        [CommandOption("symbol", 's', IsRequired = true, Description = "The name of the equity of your choice.")]
        public string Symbol { get; set; }
        [CommandOption("interval", 'i', IsRequired = false, Description = "Time interval between two consecutive data points in the time series.")]
        public string Interval { get; set; }
        public async Task ExecuteAsync(IConsole console)
        {
            var request = new Request
            {
                Function = Function,
                Symbol = Symbol,
                Interval = Interval,
            };

            var response = await HttpRequestSender.SendRequest(request);

            switch (Function){
                case "TIME_SERIES_INTRADAY":
                console.Output.WriteLine(ResponseHandler.HandleResponses<TIME_SERIES_INTRADAY>(response));
                break;
                case "TIME_SERIES_DAILY":
                
                break;
                case "TIME_SERIES_DAILY_ADJUSTED":
                break;
                case "TIME_SERIES_WEEKLY":
                break;
                case "TIME_SERIES_WEEKLY_ADJUSTED":
                break;
                case "TIME_SERIES_MONTHLY":
                break;
                case "TIME_SERIES_MONTHLY_ADJUSTED":
                break;
            }
        }
    }
}