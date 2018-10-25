using EvaluationAssistt.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Interfaces
{
    public interface IMessageView
    {
        int AgentId { get; }
        IQueryable<AgentsDto> Agents { set; }
        List<int> AgentsToList { get; }
        IQueryable<MessagesDto> MessagesReceived { set; }
        IQueryable<MessagesDto> MessagesSent { set; }
    }
}
