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
        private readonly InMemTechnologiesRepository repository;

        public TechnologiesController()
        {
            repository = new InMemTechnologiesRepository();
        }

        [HttpGet]
        public IEnumerable<Technology> GetTechnologies()
        {
            var technologies = repository.GetTechnologies();
            return technologies;
        }
    }
}
