using HR_Tech.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Tech.Repositories
{
    public class InMemCandidateRepository
    {
        private readonly Random random = new();

        private readonly List<Candidate> candidates = new()
        {
            new Candidate { CPF = "26403455087", Name = "Helena Luiza Silveira", JobOpening = new JobOpening(), 
                Technology = new List<Technology>() },
            new Candidate { CPF = "87858771310", Name = "Marli Nina da Cruz", JobOpening = new JobOpening(), 
                Technology = new List<Technology>() },
            new Candidate { CPF = "88699934343", Name = "Erick Vicente Ferreira", JobOpening = new JobOpening(), 
                Technology = new List<Technology>() },
            new Candidate { CPF = "00697720616", Name = "Isabelle Heloise Aparício", JobOpening = new JobOpening(), 
                Technology = new List<Technology>() }
        };

        public IEnumerable<Candidate> GetCandidates()
        {
            return candidates;
        }

        public Candidate GetCandidate(string cpf)
        {
            return candidates.Where(x => x.CPF == cpf).SingleOrDefault();
        }
    }
}
