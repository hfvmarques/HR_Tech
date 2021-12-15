using HR_Tech.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Tech.Repositories
{
    public interface ITechnologiesRepository
    {
        Technology GetTechnology(Guid id);
        IEnumerable<Technology> GetTechnologies();
        void CreateTechnology(Technology technology);
        void UpdateTechnology(Technology technology);
        void DeleteTechnology(Guid id);
    }
}
