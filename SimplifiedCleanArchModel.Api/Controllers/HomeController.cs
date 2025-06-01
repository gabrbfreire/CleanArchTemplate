using Microsoft.AspNetCore.Mvc;
using SimplifiedCleanArchModel.Application.Interfaces;

namespace SimplifiedCleanArchModel.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public HomeController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _weatherForecastService.GetWeatherForecast());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"You requested id {id}");
        }

        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return CreatedAtAction(nameof(Get), new { value });
        }
    }
}
