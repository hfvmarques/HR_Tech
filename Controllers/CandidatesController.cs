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
    [Route("candidates")]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidatesRepository repository;

        public CandidatesController(ICandidatesRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<CandidateDTO> GetCandidates()
        {
            var candidates = repository.GetCandidates().Select(candidate => candidate.AsDTO());
            return candidates;
        }

        [HttpGet("{id}")]
        public ActionResult<CandidateDTO> GetCandidate(Guid id)
        {
            var candidate = repository.GetCandidate(id);

            if (candidate is null)
            {
                return NotFound();
            }
            return candidate.AsDTO();
        }

        [HttpPost]
        public ActionResult<CandidateDTO> CreateCandidate(CreateCandidateDTO candidateDTO)
        {
            Candidate candidate = new()
            {
                Id = Guid.NewGuid(),
                CPF = candidateDTO.CPF,
                Name = candidateDTO.Name,
                JobOpening = candidateDTO.JobOpening,
                Technology = candidateDTO.Technology
            };

            repository.CreateCandidate(candidate);

            return CreatedAtAction(nameof(GetCandidate), new { id = candidate.Id }, candidate.AsDTO());
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCandidate(Guid id, UpdateCandidateDTO candidateDTO)
        {
            var existingCandidate = repository.GetCandidate(id);

            if (existingCandidate is null)
            {
                return NotFound();
            }

            existingCandidate.Name = candidateDTO.Name;
            existingCandidate.JobOpening = candidateDTO.JobOpening;
            existingCandidate.Technology = candidateDTO.Technology;

            repository.UpdateCandidate(existingCandidate);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCandidate(Guid id)
        {
            var existingCandidate = repository.GetCandidate(id);

            if (existingCandidate is null)
            {
                return NotFound();
            }

            repository.DeleteCandidate(id);

            return NoContent();
        }
    }
}
