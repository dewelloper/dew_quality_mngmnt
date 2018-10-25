using EvaluationAssistt.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Interfaces
{
    public interface ICategoryQuestionsManagementView
    {
        int CategoryId { get; }

        IQueryable<CategoriesDto> Categories { set; }

        IQueryable<QuestionsDto> Questions { set; }

        IQueryable<CategoriesQuestionsDto> CategoryQuestions { get; set; }
    }
}
