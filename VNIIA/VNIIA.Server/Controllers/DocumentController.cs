using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using VNIIA.Server.Models;
using VNIIA.Server.Repository;

namespace VNIIA.Server.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class DocumentController : BaseDbController<Document, DocumentRepository>
	{

		private readonly ILogger<DocumentController> _logger;

		public DocumentController(DocumentRepository repository, ILogger<DocumentController> logger) : base(repository)
		{
			_logger = logger;
		}
	}
}
