using EvaluationAssistt.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Interfaces
{
    public interface ICallManagementView
    {
        int? AgentId { get; }
        IQueryable<AgentsDto> Agents { set; }

        DateTime? MinDate { get; set; }
        DateTime? MaxDate { get; set; }
        int MinDuration { get; set; }
        int MaxDuration { get; set; }
        string Ucid { get; set; }
        string CallingDeviceId { get; set; }
        string Remark { get; set; }

        IQueryable<CallsDto> Calls { set; }

        IQueryable<CallsDto> CallsRandom { set; }

        int LocationId { get; }
        IQueryable<LocationsDto> Locations { set; }

        int GroupId { get; }
        IQueryable<GroupsDto> Groups { set; }

        int TeamId { get; }
        IQueryable<TeamsDto> Teams { set; }
    }
}
