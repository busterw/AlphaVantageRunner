using System;
using System.ComponentModel;
using System.Threading.Tasks;
using AVRunner.Controllers;
using AVRunner.Responses;
using AVRunner.Responses.Models;
using CliFx;
using CliFx.Services;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

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
    }
}
