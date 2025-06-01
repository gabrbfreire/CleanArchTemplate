using Microsoft.AspNetCore.Mvc;
using CleanArchTemplate.Application.Interfaces;

namespace CleanArchTemplate.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : Controller
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _weatherForecastService.GetWeatherForecast());
        }
    }
}
