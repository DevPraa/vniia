using System;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using VNIIA.Server.Models;

namespace VNIIA.Server.Common.Helpers
{
	public static class EFCoreTool
	{
		public static void DetachLocal<TEntity>(this DbContext _context, TEntity t, int entryId)
			where TEntity : class, IEntity
		{
			var local = _context.Set<TEntity>()
				.Local
				.FirstOrDefault(entry => entry.Number.Equals(entryId));
			if (local != null)
			{
				_context.Entry(local).State = EntityState.Detached;
			}
		}
	}
}
