using System.Net.Http;
using Microsoft.Extensions.Configuration;
using VNIIA.ClientServerLibrary.Dtos;

namespace VNIIA.Client.Services
{
	/// <summary>
	/// Сервис по работе с позициями документов
	/// </summary>
	public class DocumentPositionService : BaseService<DocumentPositionDto, HttpClient>
	{
		public DocumentPositionService(IConfiguration configuration) : base(configuration)
		{

		}
		public override string GetControllerName()
		{
			return "DocumentPosition";
		}
	}
}
