using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.EntityFrameworkCore;

using VNIIA.Server.Models;
using VNIIA.Server.Repository.Interfaces;

namespace VNIIA.Server.Repository
{
	/// <summary>
	/// Базовый репозиторий
	/// </summary>
	public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
	{
		DbContext _context;
		DbSet<TEntity> _dbSet;

		public RepositoryBase(DbContext context)
		{
			_context = context;
			_dbSet = context.Set<TEntity>();
		}

		///<inheritdoc/>
		public virtual void Create(TEntity item)
		{
			_dbSet.Add(item);
			_context.SaveChanges();
		}

		///<inheritdoc/>
		public virtual void Update(TEntity item)
		{
			_context.Entry(item).State = EntityState.Modified;
			_context.SaveChanges();
		}

		///<inheritdoc/>
		public virtual void Remove(TEntity item)
		{
			_dbSet.Remove(item);
			_context.SaveChanges();
		}

		///<inheritdoc/>
		public virtual TEntity FindById(int id)
		{
			return _dbSet.Find(id);
		}

		///<inheritdoc/>
		public virtual IEnumerable<TEntity> Get()
		{
			return _dbSet.ToList();
		}

		///<inheritdoc/>
		public virtual IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
		{
			return _dbSet.Where(predicate).ToList();
		}

	}
}
