using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using AVRunner.Responses;
using AVRunner.Responses.Models;

namespace AVRunner.Controllers
{
    public class HttpRequestSender
    {
        public static async Task<string> SendRequest(Request request)
        {
            var queries = new NameValueCollection{
            {"function", request.Function},
            {"symbol", request.Symbol},
            {"interval", request.Interval},
            {"outputsize", request.OutputSize},
            {"datatype", request.DataType},
            {"apikey", request.ApiKey}
            };

            using (var client = new HttpClient())
            {

                var response = await client.GetAsync(BuildUri(request.Uri, queries));

                var content = await response.Content.ReadAsStringAsync();

                return content;
            }
        }

        public static Uri BuildUri(string root, NameValueCollection query)
        {
            var queryCollection = HttpUtility.ParseQueryString(string.Empty);

            foreach (var key in query.Cast<string>().Where(key => !string.IsNullOrEmpty(query[key])))
            {
                queryCollection[key] = query[key];
            }

            var builder = new UriBuilder(root) { Query = queryCollection.ToString() };

            return builder.Uri;
        }

        public async Task storeoperationstemp()
        {
            var intraDayRequest = new Request
            {
                Function = "TIME_SERIES_INTRADAY",
                Symbol = "MSFT",
                Interval = "5min",
                Uri = "https://www.alphavantage.co/query"
            };

            var intraDayResponse = await HttpRequestSender.SendRequest(intraDayRequest);

            var intraDayResultList = ResponseHandler.HandleResponses<TIME_SERIES_INTRADAY>(intraDayResponse);
        }
    }
}