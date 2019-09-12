using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace AVRunner.Responses
{

    public class ResponseHandler{
        public static List<TIME_SERIES_INTRADAY> HandleIntraDayResponse (string jsonResponse){
            var jsonObject = JObject.Parse(jsonResponse);

            var outputJson = jsonObject.Children();

            var data = jsonObject
            .Children()
            .Children()
            .Values()
            .ToList();
            
            data.RemoveRange(0,6);

            var outputList = new List<TIME_SERIES_INTRADAY>();

            foreach(var jtoken in data){

            outputList.Add(jtoken.First().ToObject<TIME_SERIES_INTRADAY>());
            }

            return outputList;
        }
    }
}