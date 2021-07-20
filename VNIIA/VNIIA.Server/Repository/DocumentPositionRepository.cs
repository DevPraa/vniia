using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

using VNIIA.Server.Models;

namespace VNIIA.Server.Repository
{
	/// <summary>
	/// Репозиторий для работы с позициями документов
	/// </summary>
	public class DocumentPositionRepository : RepositoryBase<DocumentPosition>
	{
		public DocumentPositionRepository(DbContext dbContext ) : base(dbContext)
		{

		}

	}
}
