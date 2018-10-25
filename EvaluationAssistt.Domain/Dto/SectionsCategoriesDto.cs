using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Domain.Dto
{
    public class SectionsCategoriesDto
    {
        public int Id { get; set; }

        public int SectionId { get; set; }

        public string SectionName { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
