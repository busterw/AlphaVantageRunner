using System;
using CliFx.Services;

namespace AVRunner.Helpers
{
    public static class ConsoleHelper
    {
        public static void WriteLineWithColor(IConsole console, ConsoleColor color, object text)
        {
            console.ForegroundColor = color;
            console.Output.WriteLine(text);
            console.ForegroundColor = ConsoleColor.White;
        }
    }
}