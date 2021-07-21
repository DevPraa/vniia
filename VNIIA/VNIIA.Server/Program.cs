using System;
using System.Diagnostics;
using System.IO;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace VNIIA.Server
{
	class Program
	{

		static IHost _webApp;

		static void Main(string[] args)
		{
			AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
			Debug.WriteLine("Запуск сервера API!");
			var ApiServerHost = "localhost";
			var ApiServerPort = "10789";
			var baseAddress = $"http://{ApiServerHost}:{ApiServerPort}/";

			_webApp = CreateHostBuilder(args, baseAddress).Build();
			_webApp.Run();

		}

		public static IHostBuilder CreateHostBuilder(string[] args, string baseAddress) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseKestrel();
					webBuilder.UseUrls(baseAddress);
					webBuilder.UseStartup<Startup>();
				});

		private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
		{
			//TODO: Исправить остановку хоста. Работает неправильно.
			_webApp?.StopAsync();
		}
	}
}
