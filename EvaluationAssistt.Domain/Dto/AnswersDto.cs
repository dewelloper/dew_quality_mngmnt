using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Domain.Dto
{
    public class AnswersDto : BaseDto
    {
        public int Id { get; set; }

        public string AnswerText { get; set; }

        public int QuestionId { get; set; }

        public short Score { get; set; }

        public bool IsDefault { get; set; }

        public string AnswerFormat
        {
            get
            {
                return String.Format("{0} - {1} puan{2}", AnswerText, Score, IsDefault ? " (Varsayılan)" : String.Empty);
            }
        }

        public List<int> CategoriesToToggle { get; set; }
        public List<int> SectionsToToggle { get; set; }
        public List<int> QuestionsToToggle { get; set; }
    }
}
