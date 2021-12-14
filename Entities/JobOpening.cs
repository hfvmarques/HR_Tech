using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Tech.Entities
{
    public record JobOpening
    {
        [Key]
        public Guid Id { get; init; }
        public string Name { get; init; }
    }
}
