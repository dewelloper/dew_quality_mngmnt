using EvaluationAssistt.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Interfaces
{
    public interface ITeamManagementView
    {
        int Id { get; set; }
        string Name { get; set; }
        int GroupId { get; set; }
        int AgentId { get; set; }

        IQueryable<TeamsDto> Teams { set; }
        IQueryable<GroupsDto> Groups { set; }
        IQueryable<AgentsDto> Agents { set; }

        TeamsDto Dto { get; }
    }
}
