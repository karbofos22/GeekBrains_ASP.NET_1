using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Web_Api_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherForecast _holder;
        

        public WeatherForecastController(WeatherForecast holder)
        {
            _holder = holder;
           
        }


        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();

            if (_holder.Values.Count != 5)
            {
                return _holder.Values = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
            .ToList();
            }
            return _holder.Values;

        }

        [HttpPost]
        public IActionResult Save([FromQuery] string saveValuesQuestion)
        {
            if (saveValuesQuestion == "yes")
            {
                _holder.SaveData(_holder.Values);
            }
            return Ok();
        }
        
        [HttpPut]
        public IActionResult Update([FromQuery] int stringsToUpdate, [FromQuery] int newValue)
        {
            _holder.EditData(_holder.Values, stringsToUpdate, newValue);
            return Ok();
        }
    }
}
