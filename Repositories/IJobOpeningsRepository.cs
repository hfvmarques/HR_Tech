using HR_Tech.Entities;
using System;
using System.Collections.Generic;

namespace HR_Tech.Repositories
{
    public interface IJobOpeningsRepository
    {
        JobOpening GetJobOpening(Guid id);
        IEnumerable<JobOpening> GetJobOpenings();
        void CreateJobOpening(JobOpening jobOpening);
        void UpdateJobOpening(JobOpening jobOpening);
        void DeleteJobOpening(Guid id);
    }
}