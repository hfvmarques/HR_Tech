using HR_Tech.DTOs;
using HR_Tech.Entities;
using HR_Tech.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Tech.Controllers
{
    [ApiController]
    [Route("technologies")]
    public class TechnologiesController : ControllerBase
    {
        private readonly ITechnologiesRepository repository;

        public TechnologiesController(ITechnologiesRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<TechnologyDTO> GetTechnologies()
        {
            var technologies = repository.GetTechnologies().Select(technology => technology.AsDTO());
            return technologies;
        }

        [HttpGet("{id}")]
        public ActionResult<TechnologyDTO> GetTechnology(Guid id)
        {
            var technology = repository.GetTechnology(id);

            if (technology is null)
            {
                return NotFound();
            }
            return technology.AsDTO();
        }

        [HttpPost]
        public ActionResult<TechnologyDTO> CreateTechnology(CreateTechnologyDTO technologyDTO)
        {
            Technology technology = new()
            {
                Id = Guid.NewGuid(),
                Name = technologyDTO.Name
            };

            repository.CreateTechnology(technology);

            return CreatedAtAction(nameof(GetTechnology), new { id = technology.Id }, technology.AsDTO());
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTechnology(Guid id, UpdateTechnologyDTO technologyDTO)
        {
            var existingTechnology = repository.GetTechnology(id);

            if (existingTechnology is null)
            {
                return NotFound();
            }

            existingTechnology.Name = technologyDTO.Name;

            repository.UpdateTechnology(existingTechnology);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTechnology(Guid id)
        {
            var existingTechnology = repository.GetTechnology(id);

            if (existingTechnology is null)
            {
                return NotFound();
            }

            repository.DeleteTechnology(id);

            return NoContent();
        }
    }
}
