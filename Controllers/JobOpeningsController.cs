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
    [Route("jobopenings")]
    public class JobOpeningsController : ControllerBase
    {
        private readonly IJobOpeningsRepository repository;

        public JobOpeningsController(IJobOpeningsRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<JobOpeningDTO> GetJobOpenings()
        {
            var jobOpenings = repository.GetJobOpenings().Select(jobOpening => jobOpening.AsDTO());
            return jobOpenings;
        }

        [HttpGet("{id}")]
        public ActionResult<JobOpeningDTO> GetJobOpening(Guid id)
        {
            var jobOpening = repository.GetJobOpening(id);

            if (jobOpening is null)
            {
                return NotFound();
            }
            return jobOpening.AsDTO();
        }

        [HttpPost]
        public ActionResult<JobOpeningDTO> CreateJobOpening(CreateJobOpeningDTO jobOpeningDTO)
        {
            JobOpening jobOpening = new()
            {
                Id = Guid.NewGuid(),
                Name = jobOpeningDTO.Name
            };

            repository.CreateJobOpening(jobOpening);

            return CreatedAtAction(nameof(GetJobOpening), new { id = jobOpening.Id }, jobOpening.AsDTO());
        }

        [HttpPut("{id}")]
        public ActionResult UpdateJobOpening(Guid id, UpdateJobOpeningDTO jobOpeningDTO)
        {
            var existingJobOpening = repository.GetJobOpening(id);

            if (existingJobOpening is null)
            {
                return NotFound();
            }

            existingJobOpening.Name = jobOpeningDTO.Name;

            repository.UpdateJobOpening(existingJobOpening);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteJobOpening(Guid id)
        {
            var existingJobOpening = repository.GetJobOpening(id);

            if (existingJobOpening is null)
            {
                return NotFound();
            }

            repository.DeleteJobOpening(id);

            return NoContent();
        }
    }
}
