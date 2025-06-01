
using Microsoft.EntityFrameworkCore;
using SimplifiedCleanArchModel.Application.Interfaces;
using SimplifiedCleanArchModel.Application.Services;
using SimplifiedCleanArchModel.Infrastructure;

namespace SimplifiedCleanArchModel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
