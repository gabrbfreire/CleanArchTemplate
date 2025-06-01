namespace SimplifiedCleanArchModel.Application.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<List<WeatherForecast>> GetWeatherForecast();
    }
}
