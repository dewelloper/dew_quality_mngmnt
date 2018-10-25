using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Domain.Dto
{
    public class AnswersSectionsSettingsDto
    {
        public int AnswerId { get; set; }

        public string AnswerText { get; set; }

        public int SectionId { get; set; }

        public string SectionName { get; set; }

        public bool DoesZeroize { get; set; }

        public bool DoesDisable { get; set; }
    }
}
