using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.AspNetCore.Mvc;

using VNIIA.Server.Models;

namespace VNIIA.Server.Controllers
{

    /// <summary>
    /// Тестовый контроллер для генерации данных в БД. Написан на скорую руку, чтобы не заморачиваться.
    /// </summary>
	[ApiController]
    [Route("[controller]/[action]")]
    [Produces("application/json")]
    public class GenerateTestDataController : ControllerBase
    {
        DatabaseContext db;

        public GenerateTestDataController(DatabaseContext dbContext)
        {
            db = dbContext;
        }
        // POST: [controller]/Generate
        [HttpPost]
        public ActionResult Generate()
        {
            try
            {
                var document = db.Documents.Take(1);
                if (document != null)
                {
                    List<Document> docs = new List<Document>();
                    for (int i = 0; i < 10; i++)
                    {
                        docs.Add(new Document { Date = DateTime.Now, Amount = 0, Note = $"Тестовый документ {i}" });
                    }
                    db.Documents.AddRange(docs);
                    db.SaveChanges();
                    List<DocumentPosition> positions = new List<DocumentPosition>();
                    Random random = new Random();
                    var documents = db.Documents.ToArray();
                    foreach (Document documentItem in documents)
                    {
                        int posiotionsCount = random.Next(1, 10);
                        for (int i = 0; i < posiotionsCount; i++)
                        {
                            positions.Add(new DocumentPosition { Name = $"Позиция документа{i}", Sum = i * random.Next(1, 10), DocumentId = documentItem.Number });
                        }
                    }
                    db.DocumentPositions.AddRange(positions);
                    db.SaveChanges();
                    foreach (Document documentItem in documents)
                    {
                        db.Entry(documentItem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    }
                }
                db.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
