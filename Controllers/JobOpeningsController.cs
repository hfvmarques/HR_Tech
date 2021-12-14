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
        private readonly InMemJobOpeningsRepository repository;

        public JobOpeningsController()
        {
            repository = new InMemJobOpeningsRepository();
        }

        [HttpGet]
        public IEnumerable<JobOpening> GetJobOpenings()
        {
            var jobOpenings = repository.GetJobOpenings();
            return jobOpenings;
        }
    }
}
