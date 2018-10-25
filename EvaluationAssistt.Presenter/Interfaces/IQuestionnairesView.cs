using EvaluationAssistt.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Interfaces
{
    public interface IQuestionnairesView
    {
        int CallId { get; }

        int FormId { get; set; }

        string AgentName { set; }

        string DateStarted { set; }

        string FileName { set; }

        int Score { set; }

        bool? Marked { get; set; }

        FormsDto FormSelected { get; set; }

        IQueryable<FormsDto> Forms { set; }

        IQueryable<SectionsDto> Sections { get; set; }

        IQueryable<FlagsDto> Flags { set; }

        int InsertedId { get; set; }

        string CallPhone { set; }
    }
}
