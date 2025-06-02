
using Microsoft.EntityFrameworkCore;
using CleanArchTemplate.Api.Configuration;
using CleanArchTemplate.Application.Interfaces;
using CleanArchTemplate.Application.Interfaces.Auth;
using CleanArchTemplate.Application.Services;
using CleanArchTemplate.Application.Services.Auth;
using CleanArchTemplate.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace CleanArchTemplate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection"),
                sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(Program).Assembly.FullName);
                    sqlOptions.EnableRetryOnFailure();
                }
            ));

            JwtConfig.AddJwtAuthentication(builder.Services, builder.Configuration);
            SwaggerConfig.AddJwtSwagger(builder.Services);

            builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
            builder.Services.AddScoped<IAuthService, AuthService>();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseAuthorization();
            app.UseAuthentication();
            app.MapControllers();
            app.Run();
        }
    }
}
