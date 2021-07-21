using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.DependencyInjection;

using VNIIA.ClientServerLibrary.Dtos;

namespace VNIIA.Server.Services
{
	/// <summary>
	/// Заготовка для сервиса работы с документами
	/// </summary>
	public class DocumentService
	{
		private readonly IServiceProvider _services;
		public DocumentService(IServiceProvider services)
		{
			_services = services;
		}


		public void CreateDocument(DocumentDto documentDto)
		{
			using (var scope = _services.CreateScope())
			{
				//var anotherService = scope.ServiceProvider.GetRequiredService<AnotherService>();

				//anotherService.Something();
			}
		}
	}
}
