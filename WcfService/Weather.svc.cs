using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Weather" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Weather.svc or Weather.svc.cs at the Solution Explorer and start debugging.
    public class Weather : IWeather
    {
        private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        public Task<List<WeatherForecast>> GetForecast(DateTime startDate)
        {
            Random random = new Random();

            return Task.FromResult(Enumerable.Range(1, 50).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = random.Next(-20, 55),
                Summary = Summaries[random.Next(Summaries.Length)]
            }).ToList());
        }
    }
}
