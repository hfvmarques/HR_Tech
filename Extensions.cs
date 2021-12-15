using HR_Tech.DTOs;
using HR_Tech.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Tech
{
    public static class Extensions
    {
        public static TechnologyDTO AsDTO(this Technology technology)
        {
            return new TechnologyDTO(
                technology.Id, 
                technology.Name);
        }

        public static JobOpeningDTO AsDTO(this JobOpening jobOpening)
        {
            return new JobOpeningDTO(
                jobOpening.Id, 
                jobOpening.Name);
        }

        public static CandidateDTO AsDTO(this Candidate candidate)
        {
            return new CandidateDTO(
                candidate.Id, 
                candidate.CPF, 
                candidate.Name, 
                candidate.JobOpening, 
                candidate.Technology);
        }
    }
}
