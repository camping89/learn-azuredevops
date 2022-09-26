using learn_azuredevops.Models;
using Microsoft.AspNetCore.Mvc;

namespace learn_azuredevops.Controllers;

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

    [HttpGet("GetWeatherForecast")]
    public IEnumerable<WeatherForecast> GetWeatherForecast()
    {
        return Enumerable.Range(1, 5)
                         .Select(index => new WeatherForecast
                          {
                              Date         = DateTime.Now.AddDays(index),
                              TemperatureC = Random.Shared.Next(-20, 55),
                              Summary      = Summaries[Random.Shared.Next(Summaries.Length)]
                          })
                         .ToArray();
    }

    [HttpGet("GetRandomCustomers")]
    public IEnumerable<Customer> GetRandomCustomers()
    {
        return Enumerable.Range(1, 5)
                         .Select(i =>
                          {
                              var firstName = Faker.Name.First();
                              var lastName  = Faker.Name.Last();

                              return new Customer
                              {
                                  Id          = Guid.NewGuid().ToString(),
                                  FirstName   = firstName,
                                  LastName    = lastName,
                                  Address     = Faker.Address.StreetAddress(true),
                                  Email       = Faker.Internet.Email($"{firstName}.{lastName}"),
                                  PhoneNumber = Faker.Phone.Number()
                              };
                          });
    }
}