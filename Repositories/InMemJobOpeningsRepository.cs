using HR_Tech.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Tech.Repositories
{
    public class InMemJobOpeningsRepository
    {
        private readonly List<JobOpening> jobOpenings = new()
        {
            new JobOpening { Id = Guid.NewGuid(), Name = "Project Manager" },
            new JobOpening { Id = Guid.NewGuid(), Name = "Fullstack .NET Developer" },
            new JobOpening { Id = Guid.NewGuid(), Name = "Frontend Reactjs Developer" },
            new JobOpening { Id = Guid.NewGuid(), Name = "DevOps" }
        };

        public IEnumerable<JobOpening> GetJobOpenings()
        {
            return jobOpenings;
        }

        public JobOpening GetJobOpening(Guid id)
        {
            return jobOpenings.Where(x => x.Id == id).SingleOrDefault();
        }
    }
}
