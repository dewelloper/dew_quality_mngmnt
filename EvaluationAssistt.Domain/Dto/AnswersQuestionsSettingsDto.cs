using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Domain.Dto
{
    public class AnswersQuestionsSettingsDto
    {
        public int AnswerId { get; set; }

        public string AnswerText { get; set; }

        public int QuestionId { get; set; }

        public string QuestionText { get; set; }

        public bool DoesZeroize { get; set; }

        public bool DoesDisable { get; set; }
    }
}
