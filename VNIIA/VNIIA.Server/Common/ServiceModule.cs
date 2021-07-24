using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

using VNIIA.Server.Common.Interfaces;
using VNIIA.Server.Common.Services;
using VNIIA.Server.Models;
using VNIIA.Server.Repository;
using VNIIA.Server.Services;

namespace VNIIA.Server.Common
{
	public static class ServiceModule
	{
		public static void AddCustomServices(this IServiceCollection services)
		{
			services.AddSingleton<IStartupService, WebAppStartUp>();
			//Сервисы


			//Репозитории БД
			//services.AddSingleton<DatabaseContext>();
			services.AddTransient<DocumentPositionRepository>();
			services.AddTransient<DocumentRepository>();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "VNIIA API",
					Version = "v1",
					Description = "API для тестового задания",
					Contact = new OpenApiContact() { Name = "Виктор Толкачев", Email = "tip67903@gmail.com" }
				});
			});
		}
	}
}
