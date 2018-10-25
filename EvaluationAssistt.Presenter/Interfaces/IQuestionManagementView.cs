using System.Linq;
using EvaluationAssistt.Domain.Dto;
using System.Collections.Generic;

namespace EvaluationAssistt.Presenter.Interfaces
{
    public interface IQuestionManagementView
    {
        int Id { get; set; }
        string QuestionText { get; set; }
        bool HasComment { get; set; }
        bool RequiresComment { get; set; }
        bool HasVisibleScore { get; set; }
        bool HasMultipleAnswers { get; set; }

        IQueryable<QuestionsDto> Questions { set; }
        ICollection<AnswersDto> Answers { get; set; }

        QuestionsDto Dto { get; }
    }
}
