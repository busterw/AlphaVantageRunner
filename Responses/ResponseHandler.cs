using System;
using System.Collections.Generic;
using System.Linq;
using AVRunner.Responses.Models;
using Newtonsoft.Json.Linq;

namespace AVRunner.Responses
{

    public class ResponseHandler
    {
        private static List<JToken> ExtractJsonTokens(string jsonResponse)
        {
            var jsonObject = JObject.Parse(jsonResponse);

            var outputJson = jsonObject.Children();

            var data = jsonObject.Children().Children().Values().ToList();

            data.RemoveRange(0, 6);

            return data;
        }

        public static List<T> HandleResponses<T>(string jsonResponse)
        {

            var jTokens = ExtractJsonTokens(jsonResponse);

            var outputList = new List<T>();

            foreach (var jtoken in jTokens)
            {
                outputList.Add(jtoken.First().ToObject<T>());
            }

            return outputList;
        }

        public static GLOBAL_QUOTE HandleQuoteResponse(string jsonResponse)
        {
            var jObject = JObject.Parse(jsonResponse).Children().Children().First();

            var mapped = jObject.ToObject<GLOBAL_QUOTE>();

            return mapped;
        }
    }
}