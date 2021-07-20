using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.DependencyInjection;

using VNIIA.Server.Common.Interfaces;
using VNIIA.Server.Common.Services;
using VNIIA.Server.Interfaces;
using VNIIA.Server.Services;

namespace VNIIA.Server.Common
{
	public static class ServiceModule
	{
		public static void AddCustomServices(this IServiceCollection services)
		{
			services.AddSingleton<IStartupService, WebAppStartUp>();
			services.AddSingleton<IWeatherForecastService, WeatherForecastService>();
		}
	}
}
