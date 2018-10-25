using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Domain.Dto
{
    public class FormsSectionsDto
    {
        public int Id { get; set; }

        public int FormId { get; set; }

        public string FormName { get; set; }

        public int SectionId { get; set; }

        public string SectionName { get; set; }
    }
}
