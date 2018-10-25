using EvaluationAssistt.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Interfaces
{
    public interface IAgentManagementView
    {
        int Id { get; set; }
        string LoginId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string RegisterNumber { get; set; }
        int? TeamId { get; set; }
        int AgentTypeId { get; set; }
        bool AllGroupsAccess { get; set; }
        string IPPhone { get; set; }

        IQueryable<TeamsDto> Teams { set; }
        IQueryable<AgentsDto> Agents { set; }
        IQueryable<AgentTypesDto> AgentTypes { set; }
        IQueryable<PagesDto> Pages { set; }
        IQueryable<PagesAgentsDto> PagesAgents { get; set; }

        AgentsDto Dto { get; }
    }
}
