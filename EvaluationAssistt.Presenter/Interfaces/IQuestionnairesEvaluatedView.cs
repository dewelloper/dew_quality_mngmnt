using EvaluationAssistt.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Interfaces
{
    public interface IQuestionnairesEvaluatedView
    {
        int CallId { get; }
        int FormId { get; }
        string FormName { set; }
        string AgentName { set; }
        string DateStarted { set; }
        string FileName { set; }
        string EvaluatorName { set; }
        string EvaluationDate { set; }
        string TotalScore { set; }
        string CalculatedScore { set; }
        int Fceid { get; }
        string CallPhone { set; }

        IQueryable<SectionsDto> Sections { get; set; }
    }
}
