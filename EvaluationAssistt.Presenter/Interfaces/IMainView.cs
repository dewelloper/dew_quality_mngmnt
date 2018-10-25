using EvaluationAssistt.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Interfaces
{
    public interface IMainView
    {
        int UncheckedAgentsCount { get; set; }

        int UnreadMessagesCount { get; set; }

        List<PagesAgentsDto> BookmarkedPages { get; set; }
    }
}
