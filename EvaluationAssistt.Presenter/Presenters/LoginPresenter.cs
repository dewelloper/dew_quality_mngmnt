using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Presenters
{
    public class LoginPresenter
    {
        private readonly ILoginView view;

        private static AgentsService _agentsService;
        private static PagesService _pagesService;

        public LoginPresenter(ILoginView view)
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

        public AgentsDto ValidateUser(string loginId, out bool valid)
        {
            var dto = _agentsService.ValidateUser(loginId);

            valid = dto != null;

            return dto;
        }

        public List<string> GetPagesByAgentId(int agentId)
        {
            var result = _pagesService.GetPageNamesByAgentId(agentId);

            return result;
        }
    }
}
