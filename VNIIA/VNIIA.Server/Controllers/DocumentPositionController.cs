using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.Logging;

using VNIIA.Server.Models;
using VNIIA.Server.Repository;

namespace VNIIA.Server.Controllers
{
	public class DocumentPositionController : BaseDbController<DocumentPosition, DocumentPositionRepository>
	{
		private readonly ILogger<DocumentPositionController> _logger;

		public DocumentPositionController(DocumentPositionRepository repository, ILogger<DocumentPositionController> logger) : base(repository)
		{
			_logger = logger;

		}
	}
}
