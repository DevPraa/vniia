using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using VNIIA.ClientServerLibrary.Dtos;

namespace VNIIA.Client.Services
{
	public abstract class BaseService<T,THttpClient> : IBaseService<T, THttpClient>
		where T : EntityDto
		where THttpClient: HttpClient, new()
	{
		THttpClient client;
		IConfiguration _configuration;
		public BaseService(IConfiguration configuration)
		{
			client = new THttpClient();
			_configuration = configuration;
			client.BaseAddress = new Uri($"http://{_configuration.GetSection("ApiHost").Value}/{GetControllerName()}/");
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public async Task<T> CreateAsync(T document)
		{
			var response = await client.PostAsJsonAsync<T>($"Create", document);
			return await response.Content.ReadAsAsync<T>();
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			var response = await client.GetAsync("Get");
			return await response.Content.ReadAsAsync<IEnumerable<T>>();
		}

		public async Task<T> FindByIdAsync(int id)
		{
			var response = await client.GetAsync($"FindById/{id}");
			return await response.Content.ReadAsAsync<T>();
		}

		public async Task<T> UpdateAsync(T document)
		{
			var response = await client.PutAsJsonAsync($"Update/{document.Number}", document);
			return await response.Content.ReadAsAsync<T>();
		}

		public async Task<T> DeleteAsync(int id)
		{
			var response = await client.DeleteAsync($"Delete/{id}");
			return await response.Content.ReadAsAsync<T>();
		}



		public abstract string GetControllerName();

		public THttpClient Client => client;
	}
}
