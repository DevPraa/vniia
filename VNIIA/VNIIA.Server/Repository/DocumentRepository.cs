using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.EntityFrameworkCore;

using VNIIA.Server.Models;

namespace VNIIA.Server.Repository
{
	/// <summary>
	/// Репозиторий для работы с документами
	/// </summary>
	public class DocumentRepository : RepositoryBase<Document, DatabaseContext>
	{
		DatabaseContext _dbContext;
		public DocumentRepository(DatabaseContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

		public override IEnumerable<Document> Get()
		{
			return _dbContext.Documents.Include(prop => prop.DocumentPositions).AsEnumerable();
		}

		public override IEnumerable<Document> Get(Func<Document, bool> predicate)
		{
			return _dbContext.Documents.Include(prop => prop.DocumentPositions).AsQueryable().Where(predicate).AsEnumerable();
		}

		public override Document FindById(int id)
		{
			return _dbContext.Documents.Include(prop => prop.DocumentPositions).FirstOrDefault(c => c.Number == id);
		}
	}
}
