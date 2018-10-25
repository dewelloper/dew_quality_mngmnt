using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Domain.Dto
{
    public class AnswersCategoriesSettingsDto
    {
        public int AnswerId { get; set; }

        public string AnswerText { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public bool DoesZeroize { get; set; }

        public bool DoesDisable { get; set; }
    }
}
