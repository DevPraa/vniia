using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using VNIIA.Server.Interfaces;
using VNIIA.Server.Models;

namespace VNIIA.Server.Services
{
	internal class WeatherForecastService : IWeatherForecastService
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};
		public IEnumerable<IWeatherForecast> GetWeatherForecasts()
		{
			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			})
			.ToArray();
		}
	}
}
