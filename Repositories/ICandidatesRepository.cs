using HR_Tech.Entities;
using System;
using System.Collections.Generic;

namespace HR_Tech.Repositories
{
    public interface ICandidatesRepository
    {
        Candidate GetCandidate(Guid id);
        IEnumerable<Candidate> GetCandidates();
        void CreateCandidate(Candidate candidate);
        void UpdateCandidate(Candidate candidate);
        void DeleteCandidate(Guid id);
    }
}