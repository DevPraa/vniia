using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Mvc;

using VNIIA.Server.Models;
using VNIIA.Server.Repository.Interfaces;

namespace VNIIA.Server.Controllers
{
    
    [ApiController]
    [Route("[controller]/[action]")]
    [Produces("application/json")]
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
        public virtual ActionResult<IEnumerable<TEntity>> Get()
        {
            try
            {
                return new ObjectResult(_repository.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: [controller]/FindById/5
        [HttpGet("{id}")]
        public virtual ActionResult<TEntity> FindById(int id)
        {
            try
            {
                var movie = _repository.FindById(id);
                if (movie == null)
                {
                    return NotFound();
                }
                return movie;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // PUT: [controller]/Update/5
        [HttpPut("{id}")]
        public virtual IActionResult Update(int id, TEntity movie)
        {
            try
            {
                if (id != movie.Number)
                {
                    return BadRequest();
                }
                var obj = _repository.FindById(movie.Number);
                if (obj == null)
                {
                    return BadRequest("Запись для обновления не найдена");
                }
                obj = movie;
                _repository.Update(obj);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: [controller]/Create
        [HttpPost]
        public virtual ActionResult<TEntity> Create(TEntity movie)
        {
            try
            {
                _repository.Create(movie);
                return CreatedAtAction("FindById", new { id = movie.Number }, movie);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // DELETE: [controller]/Delete/5
        [HttpDelete("{id}")]
        public virtual ActionResult<TEntity> Delete(int id)
        {
            try
            {
                var movie = _repository.FindById(id);

                if (movie == null)
                {
                    return NotFound();
                }
                _repository.Remove(movie);
                return movie;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
