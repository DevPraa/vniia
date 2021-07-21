using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Mvc;

using VNIIA.Server.Models;
using VNIIA.Server.Repository.Interfaces;

namespace VNIIA.Server.Controllers
{
	[Route("[controller]/[action]")]
	[ApiController]
	public abstract class BaseDbController<TEntity, TRepository> : ControllerBase
		where TEntity : class, IEntity
        where TRepository : IRepositoryBase<TEntity>
	{
		private readonly TRepository _repository;

		public BaseDbController(TRepository repository)
		{
			_repository = repository;
		}


        // GET: [controller]/Get
        [HttpGet]
        public ActionResult<IEnumerable<TEntity>> Get()
        {
            return new ObjectResult(_repository.Get());
        }

        // GET: [controller]/FindById/5
        [HttpGet("{id}")]
        public ActionResult<TEntity> FindById(int id)
        {
            var movie =  _repository.FindById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }

        // PUT: [controller]/Update/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, TEntity movie)
        {
            if (id != movie.Number)
            {
                return BadRequest();
            }
            var obj = _repository.FindById(movie.Number);
            if (obj == null)
            {
                return BadRequest();
            }
            obj = movie;
            _repository.Update(obj);
            return NoContent();
        }

        // POST: [controller]/Create
        [HttpPost]
        public ActionResult<TEntity> Create(TEntity movie)
        {
            _repository.Create(movie);
            return CreatedAtAction("FindById", new { id = movie.Number }, movie);
        }

        // DELETE: [controller]/Delete/5
        [HttpDelete("{id}")]
        public ActionResult<TEntity> Delete(int id)
        {
            var movie = _repository.FindById(id);
            
            if (movie == null)
            {
                return NotFound();
            }
            _repository.Remove(movie);
            return movie;
        }
    }
}
