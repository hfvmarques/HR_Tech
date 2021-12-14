using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Tech.Entities
{
    public record Candidate
    {
        [Key]
        [DisplayFormat(DataFormatString = "{0:###.###.###-##}", ApplyFormatInEditMode = true)]
        public string CPF { get; init; }
        public string Name { get; init; }
        public JobOpening JobOpening { get; init; }
        public List<Technology> Technology { get; init; }
    }
}
