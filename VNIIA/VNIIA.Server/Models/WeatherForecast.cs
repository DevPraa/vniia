using System;
using System.Collections.Generic;
using System.Text;

namespace VNIIA.Server.Models
{
	public interface IWeatherForecast
	{
		DateTime Date { get; set; }
		string Summary { get; set; }
		int TemperatureC { get; set; }
		int TemperatureF { get; }
	}

	public class WeatherForecast : IWeatherForecast
	{
		public DateTime Date { get; set; }

		public int TemperatureC { get; set; }

		public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

		public string Summary { get; set; }
	}
}
