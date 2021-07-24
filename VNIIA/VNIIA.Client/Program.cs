using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using VNIIA.Client.Services;
using VNIIA.ClientServerLibrary.Dtos;

namespace VNIIA.Client
{
	static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var services = new ServiceCollection();
			
			ConfigureServices(services);

			using (ServiceProvider serviceProvider = services.BuildServiceProvider())
			{
				var form1 = serviceProvider.GetRequiredService<Main>();
				Application.Run(form1);
			}
		}

		private static void ConfigureServices(ServiceCollection services)
		{
			IConfiguration Configuration = new ConfigurationBuilder()
							  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
							  .Build();
			services.AddScoped<Main>();
			services.AddTransient<BindingSource>();
			services.AddSingleton<IConfiguration>(Configuration);
			services.AddSingleton<IBaseService<DocumentDto,HttpClient>,DocumentService>();
			services.AddSingleton<IBaseService<DocumentPositionDto, HttpClient>, DocumentPositionService>();
		}
	}
}
