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
        private readonly InMemCandidateRepository repository;

        public CandidatesController()
        {
            repository = new InMemCandidateRepository();
        }

        [HttpGet]
        public IEnumerable<Candidate> GetCandidates()
        {
            var candidates = repository.GetCandidates();
            return candidates;
        }
    }
}
