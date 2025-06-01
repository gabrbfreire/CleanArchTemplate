using CleanArchTemplate.Domain.Entities;

namespace CleanArchTemplate.Application.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<List<WeatherForecast>> GetWeatherForecast();
    }
}
