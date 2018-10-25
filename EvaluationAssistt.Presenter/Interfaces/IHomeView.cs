using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Interfaces
{
    public interface IHomeView
    {
        int AgentId { get; }
        int AgentCallCount { set; }
        int AgentAverageCallDuration { set; }
        DateTime DateMin { get; }
        DateTime DateMax { get; }
        IQueryable<FormsCallsDto> CallsEvaluatedLast30Days { set; }

        int TeamId { get; }
        DateTime DateTeamMin { get; }
        DateTime DateTeamMax { get; }
        IQueryable<ufnCallSummaries_Result> TeamCallSummaries { set; }
        IQueryable<ufnCallEvaluatedSummaries_Result> TeamCallEvaluatedSummaries { set; }
        DateTime DateTeamLeaderMin { get; }
        DateTime DateTeamLeaderMax { get; }
        IQueryable<ufnCallEvaluatedTeamLeaderSummaries_Result> TeamLeaderCallEvaluatedSummaries { set; }
        IQueryable<FormsCallsDto> CallsEvaluatedWithRemarks { set; }
        IQueryable<FormsCallsDto> CallsEvaluatedByTeamsAndDate { set; }

        int GroupId { get; }
        DateTime DateGroupMin { get; }
        DateTime DateGroupMax { get; }
        IQueryable<ufnCallTeamSummaries_Result> GroupLeaderCallSummaries { set; }

        bool EvaluationSearchIsAuthenticated { get; }
    }
}
