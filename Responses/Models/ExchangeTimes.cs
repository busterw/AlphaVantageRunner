using System;

namespace AVRunner.Responses
{
    public class ExchangeTimes
    {
        public string ExchangeName { get; set; }
        public string Id { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set; }
        public string Status { get; set; }
        public TimeSpan TimeToClose { get; set; }
        public TimeSpan TimeToOpen{get;set;}

    }
}