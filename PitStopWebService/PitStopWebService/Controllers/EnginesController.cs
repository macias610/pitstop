using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DomainModel;
using Repository;
using Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Constans.Policies;

namespace PitStopWebService.Controllers
{
    [Route("api/[controller]")]
    public class EnginesController : Controller
    {
        private readonly IRepository repository;

        public EnginesController(IRepository repository)
        {
            this.repository = repository;
        }

        [Authorize(Policy = PolicyTypes.Engines.Get)]
        [HttpGet(Name = "Engines")]
        public IEnumerable<Engine> GetAll()
        {
            IEnumerable<Engine> engines = repository.GetAll<Engine>();
            return engines;
        }

        [HttpGet("{id}", Name = "GetEngineById")]
        public IActionResult GetById(string id)
        {
            Engine engine = repository.GetById<Engine>(id);
            if (engine == null)
            {
                return NotFound();
            }
            return new ObjectResult(engine);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Engine engine)
        {
            if (engine == null)
            {
                return BadRequest();
            }
            repository.Create<Engine>(engine);

            return new CreatedResult("test", engine.Id);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var engine = repository.GetById<Engine>(id);
            if (engine == null)
            {
                return NotFound();
            }
            repository.Delete<Engine>(engine);

            return new NoContentResult();
        }

    }
}