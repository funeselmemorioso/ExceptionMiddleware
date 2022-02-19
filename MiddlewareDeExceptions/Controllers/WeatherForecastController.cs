using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareDeExceptions.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                int cero = 0;
                double div = 1 / cero;
                return Ok();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        [HttpGet]
        [Route("OtroGet")]
        public async Task<IActionResult> OtroGet()
        {
            // Sin try catch
            int cero = 0;
            double div = 1 / cero;
            return Ok();           
        }
    }
}
