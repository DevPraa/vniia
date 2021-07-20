using System;
using System.Collections.Generic;
using System.Text;

using VNIIA.Server.Models;

namespace VNIIA.Server.Interfaces
{
	public interface IWeatherForecastService
	{
		IEnumerable<IWeatherForecast> GetWeatherForecasts();
	}
}
