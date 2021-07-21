using System;
using System.Collections.Generic;
using System.Text;

using VNIIA.Server.Models;

namespace VNIIA.Server.Repository.Interfaces
{
	public interface IRepositoryBase<TEntity> where TEntity : class, IEntity
	{
		/// <summary>
		/// Создаёт объект
		/// </summary>
		/// <param name="item"></param>
		void Create(TEntity item);
		/// <summary>
		/// Возвращает объект по указанному идентификатору
		/// </summary>
		/// <param name="item"></param>
		TEntity FindById(int id);
		/// <summary>
		/// Возвращает список объектов
		/// </summary>
		/// <returns></returns>
		IEnumerable<TEntity> Get();
		/// <summary>
		/// Возвращает объекты удовлетворяющие условию
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
		/// <summary>
		/// Удаляет объект
		/// </summary>
		/// <param name="item"></param>
		void Remove(TEntity item);
		/// <summary>
		/// Обновляет объект
		/// </summary>
		/// <param name="item"></param>
		void Update(TEntity item);
	}
}
