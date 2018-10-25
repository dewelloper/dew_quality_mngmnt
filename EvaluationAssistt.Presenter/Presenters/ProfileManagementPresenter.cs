using EvaluationAssistt.Presenter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using EvaluationAssistt.Service.Services;

namespace EvaluationAssistt.Presenter.Presenters
{
    public class ProfileManagementPresenter
    {
        private readonly IProfileManagementView view;

        private static PagesService _pagesService;
        private static AgentsService _agentsService;
        private static TeamsService _teamsService;

        public ProfileManagementPresenter(IProfileManagementView view)
        {
            this.view = view;

            if (_pagesService == null)
            {
                _pagesService = new PagesService();
            }
            if (_agentsService == null)
            {
                _agentsService = new AgentsService();
            }
            if (_teamsService == null)
            {
                _teamsService = new TeamsService();
            }
        }

        public void GetPagesByAgentId(int agentId)
        {
            var result = _pagesService.GetPagesByAgentId(agentId);

            view.Pages = result;
        }

        public void GetPagesBookmarkedByAgentId(int agentId)
        {
            var result = _pagesService.GetPagesBookmarkedByAgentId(agentId);

            view.PagesBookmarked = result;
        }

        public void GetAgentById(int agentId)
        {
            var result = _agentsService.GetAgentById(agentId);

            view.Agent = result;
        }

        public void GetTeamsAll()
        {
            var result =  _teamsService.GetTeamsNameValueCollection();

            view.Teams = result;
        }

        public void UpdateBookmarkedPages(int agentId)
        {
            _pagesService.UpdateBookmarkedPages(agentId, view.PagesBookmarked);
        }
    }
}
