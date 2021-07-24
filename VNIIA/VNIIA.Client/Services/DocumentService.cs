using System.Net.Http;
using Microsoft.Extensions.Configuration;
using VNIIA.ClientServerLibrary.Dtos;

namespace VNIIA.Client.Services
{
	/// <summary>
	/// Сервис по работе с документами
	/// </summary>
	public class DocumentService : BaseService<DocumentDto,HttpClient>
	{
		public DocumentService(IConfiguration configuration): base(configuration)
		{

		}
		public override string GetControllerName()
		{
			return "Document";
		}
	}
}
