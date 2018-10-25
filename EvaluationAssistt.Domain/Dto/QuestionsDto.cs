using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Domain.Dto
{
    public class QuestionsDto : BaseDto
    {
        public int Id { get; set; }

        public string QuestionText { get; set; }

        public bool HasComment { get; set; }

        public bool RequiresComment { get; set; }

        public bool HasVisibleScore { get; set; }

        public bool HasMultipleAnswers { get; set; }

        public ICollection<AnswersDto> Answers { get; set; }
    }
}
