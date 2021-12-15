using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Tech.DTOs
{
    public record TechnologyDTO (Guid Id, string Name);
    public record CreateTechnologyDTO ([Required] string Name);
    public record UpdateTechnologyDTO([Required] string Name);   
}
