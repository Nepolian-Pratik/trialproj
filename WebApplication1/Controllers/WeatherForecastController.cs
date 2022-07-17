using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        protected string GetIPAddress()
        {
            return HttpContext.Connection.RemoteIpAddress.ToString();

            // HttpContext context = HttpContext.Features.Get<IHttpConnectionFeature>().HttpContext; 
            // string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            //  if (!string.IsNullOrEmpty(ipAddress))
            //  {
            //     string[] addresses = ipAddress.Split(',');
            //     if (addresses.Length != 0)
            //     {
            //         return addresses[0];
            //      }
            //  }

            //  return context.Request.ServerVariables["REMOTE_ADDR"];
        }
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        // ipAddress = Get the client's IP
        

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                IpAddress = GetIPAddress(),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}