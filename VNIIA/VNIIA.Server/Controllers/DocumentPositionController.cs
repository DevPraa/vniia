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
	public class DocumentPositionController : BaseDbController<DocumentPosition, DocumentPositionRepository>
	{
		private readonly ILogger<DocumentPositionController> _logger;
		private readonly DocumentPositionRepository _repository;

		public DocumentPositionController(DocumentPositionRepository repository, ILogger<DocumentPositionController> logger) : base(repository)
		{
			_logger = logger;
			_repository = repository;
		}

		[HttpGet("{id}")]
		public ActionResult<IEnumerable<DocumentPosition>> GetDocumentRelatedDocumentPositions(int id)
		{
			return new ObjectResult(_repository.GetDocumentRelatedDocumentPositions(id));
		}
	}
}
