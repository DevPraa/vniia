using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace VNIIA.Server
{
	class Program
	{

		static IHost _webApp;

		static void Main(string[] args)
		{
			AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
			_webApp = CreateHostBuilder(args).Build();
			_webApp.Run();

		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.ConfigureAppConfiguration((context, builder)
						=> {
						builder.SetBasePath(context.HostingEnvironment.ContentRootPath)
						.AddJsonFile("appsettings.json")
						.Build();
						});
					webBuilder.UseKestrel();
					webBuilder.UseUrls();
					webBuilder.UseStartup<Startup>();
				});
	

	private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
		{
			//TODO:
			_webApp?.StopAsync();
		}
	}
}
