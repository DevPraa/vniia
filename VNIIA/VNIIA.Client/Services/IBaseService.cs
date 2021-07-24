using System.Collections.Generic;
using System.Threading.Tasks;

namespace VNIIA.Client.Services
{
	public interface IBaseService<T, THttpClient>
	{
		Task<T> CreateAsync(T document);
		Task<T> UpdateAsync(T document);
		Task<T> DeleteAsync(int id);
		Task<T> FindByIdAsync(int id);
		Task<IEnumerable<T>> GetAllAsync();

		public THttpClient Client { get;}
		abstract string GetControllerName();
	}
}