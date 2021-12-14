using HR_Tech.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Tech.Repositories
{
    public class InMemTechnologiesRepository
    {
        private readonly List<Technology> technologies = new()
        {
            new Technology { Id = Guid.NewGuid(), Name = "Reactjs" },
            new Technology { Id = Guid.NewGuid(), Name = ".NET 5" },
            new Technology { Id = Guid.NewGuid(), Name = "Vuejs" },
            new Technology { Id = Guid.NewGuid(), Name = "Ruby on Rails" }
        };

        public IEnumerable<Technology> GetTechnologies()
        {
            return technologies;
        }

        public Technology GetTechnology(Guid id)
        {
            return technologies.Where(x => x.Id == id).SingleOrDefault();
        }
    }
}
