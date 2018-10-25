using EvaluationAssistt.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Interfaces
{
    public interface IGroupManagementView
    {
        int Id { get; set; }
        string Name { get; set; }
        int LocationId { get; set; }
        int AgentId { get; set; }

        IQueryable<GroupsDto> Groups { set; }
        IQueryable<LocationsDto> Locations { set; }
        IQueryable<AgentsDto> Agents { set; }

        GroupsDto Dto { get; }
    }
}
