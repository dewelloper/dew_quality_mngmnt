using EvaluationAssistt.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Interfaces
{
    public interface IReportingView
    {
        int Id { get; set; }
        string LoginId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string RegisterNumber { get; set; }
        int? TeamId { get; set; }
        int AgentTypeId { get; set; }

        IQueryable<FormsCallsDto> FormsCalls { get; set; }
        IQueryable<CallsOfAgentDto> CallsOfAgents { get; set; }
        IQueryable<TeamCallsDto> TeamCalls { get; set; }
        IQueryable<AgentsDto> Agents { get; set; }
        IQueryable<FormsDto> Forms { get; set; }
    }
}
