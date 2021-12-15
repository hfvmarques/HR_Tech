using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Tech.DTOs
{
    public record JobOpeningDTO (Guid Id, string Name);
    public record CreateJobOpeningDTO ([Required] string Name);
    public record UpdateJobOpeningDTO ([Required] string Name);    
}
