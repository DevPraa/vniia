using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

using VNIIA.Server.Models;

namespace VNIIA.Server.Repository
{
	/// <summary>
	/// Репозиторий для работы с документами
	/// </summary>
	public class DocumentRepository : RepositoryBase<Document>
	{
		public DocumentRepository(DbContext dbContext) : base(dbContext)
		{

		}
	}
}
