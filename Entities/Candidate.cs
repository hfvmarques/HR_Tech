using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Tech.Entities
{
    public class Candidate
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:###.###.###-##}", ApplyFormatInEditMode = true)]
        public string CPF { get; set; }
        public string Name { get; set; }
        public JobOpening JobOpening { get; set; }
        public List<Technology> Technology { get; set; }
    }
}
