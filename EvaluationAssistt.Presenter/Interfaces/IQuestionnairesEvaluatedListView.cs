using EvaluationAssistt.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Interfaces
{
    public interface IQuestionnairesEvaluatedListView
    {
        IQueryable<FormsCallsDto> Calls { set; }

        List<int> Teams { get; }

        bool Evaluationtype { get; }

        int AgentId { get; }
    }
}
