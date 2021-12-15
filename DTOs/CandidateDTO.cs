using HR_Tech.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Tech.DTOs
{
    public record CandidateDTO (
        Guid Id,
        string CPF,
        string Name,
        JobOpening JobOpening,
        List<Technology> Technology);
    public record CreateCandidateDTO (
        [Required] string CPF, 
        [Required] string Name, 
        JobOpening JobOpening, 
        List<Technology> Technology);
    public record UpdateCandidateDTO(
        [Required] string Name,
        JobOpening JobOpening,
        List<Technology> Technology);    
}
