using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using VNIIA.Server.Interfaces;
using VNIIA.Server.Models;

namespace VNIIA.Server.Controllers
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
		private readonly IWeatherForecastService _weatherForecastService;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
		{
			_logger = logger;
			_weatherForecastService = weatherForecastService;
		}

		[HttpGet]
		public IEnumerable<IWeatherForecast> Get() => _weatherForecastService.GetWeatherForecasts();
	}
}
