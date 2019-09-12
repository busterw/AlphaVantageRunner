using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace AVRunner.Controllers{
    public  class HttpRequestSender{
        public static async Task<string> SendRequest(Request request){

            var queries = new NameValueCollection{
            {"function", request.Function},
            {"symbol", request.Symbol},
            {"interval", request.Interval},
            {"outputsize", request.OutputSize},
            {"datatype", request.DataType},
            {"apikey", request.ApiKey}    
            };

            using (var client = new HttpClient()){

                var response = await client.GetAsync(BuildUri(request.Uri, queries));

                var content = await response.Content.ReadAsStringAsync();

                return content; 
            }
        }

        public static Uri BuildUri(string root, NameValueCollection query){
            var queryCollection = HttpUtility.ParseQueryString(string.Empty);

            foreach(var key in query.Cast<string>().Where(key => !string.IsNullOrEmpty(query[key]))){
                queryCollection[key] = query[key];
            }

            var builder = new UriBuilder(root) {Query = queryCollection.ToString()};

            return builder.Uri;
        }
    }
}