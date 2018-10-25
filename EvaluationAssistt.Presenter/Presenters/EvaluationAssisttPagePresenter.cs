using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Presenters
{
    public class EvaluationAssisttPagePresenter
    {
        private readonly IEvaluationAssisttPage view;

        private static AgentsService _agentsService;
        private static PagesService _pagesService;

        public EvaluationAssisttPagePresenter(IEvaluationAssisttPage view)
        {
            this.view = view;

            if (_agentsService == null)
            {
                _agentsService = new AgentsService();
            }
            if (_pagesService == null)
            {
                _pagesService = new PagesService();
            }
        }

        public IQueryable<AgentsDto> GetUncheckedAgentsNames(List<int> teams)
        {
            var result = _agentsService.GetUncheckedAgentsName(teams);

            return result;
        }

        public void BookmarkPage(int agentId, string pageName)
        {
            pageName = pageName.Replace(".aspx", String.Empty);
            _pagesService.BookmarkPage(agentId, pageName);
        }
    }
}
