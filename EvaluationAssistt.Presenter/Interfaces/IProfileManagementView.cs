using System;
using System.Collections.Generic;
using System.Linq;
using EvaluationAssistt.Domain.Dto;

namespace EvaluationAssistt.Presenter.Interfaces
{
    public interface IProfileManagementView
    {
        AgentsDto Agent { set; }

        IQueryable<TeamsDto> Teams { set; }

        IQueryable<PagesAgentsDto> Pages { set; }

        IQueryable<PagesAgentsDto> PagesBookmarked { get; set; }
    }
}
