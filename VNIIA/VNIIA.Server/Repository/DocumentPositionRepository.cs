using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.EntityFrameworkCore;

using VNIIA.Server.Models;

namespace VNIIA.Server.Repository
{
	/// <summary>
	/// Репозиторий для работы с позициями документов
	/// </summary>
	public sealed class DocumentPositionRepository : RepositoryBase<DocumentPosition, DatabaseContext>
	{
		DatabaseContext _dbContext;
		public DocumentPositionRepository(DatabaseContext dbContext ) : base(dbContext)
		{
			_dbContext = dbContext;
		}

		public override IEnumerable<DocumentPosition> Get()
		{
			return _dbContext.DocumentPositions.Include(prop => prop.Document).AsEnumerable();
		}

		public override IEnumerable<DocumentPosition> Get(Func<DocumentPosition, bool> predicate)
		{
			return _dbContext.DocumentPositions.Include(prop => prop.Document).AsQueryable().Where(predicate).AsEnumerable();
		}

		public override DocumentPosition FindById(int id)
		{
			return _dbContext.DocumentPositions.Include(prop => prop.Document).FirstOrDefault(c => c.Number == id);
		}

		public override void Update(DocumentPosition item)
		{
			base.Update(item);
			var doc = _dbContext.Documents.Find(item.DocumentId);
			if (doc != null)
			{
				_dbContext.Entry(doc).State = EntityState.Modified;
				_dbContext.SaveChanges();
			}
		}

		/// <summary>
		/// Получить позиции документа, связанные с документом
		/// </summary>
		public IEnumerable<DocumentPosition> GetDocumentRelatedDocumentPositions(int document)
		{
			return Get(c=>c.DocumentId == document);
		}
	}
}
