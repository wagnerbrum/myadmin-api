using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace MyAdmin.WebApi.Controllers;

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

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        // var resultString = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
        // _logger.LogDebug("Return ListarEspecialidades " + resultString);

        _logger.LogInformation("WeatherForecast - Get()");

        var obj = JsonSerializer.Serialize(new {
            Teste = "teste 123",
            Teste2 = "teste 123"
        });
        
        _logger.LogInformation($"WeatherForecast - Teste - {obj.ToString()}");

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
