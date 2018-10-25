using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView view;

        private static AgentsService _agentsService;
        private static MessagesService _messagesService;
        private static PagesService _pagesService;

        public MainPresenter(IMainView view)
        {
            this.view = view;

            if (_agentsService == null)
            {
                _agentsService = new AgentsService();
            }
            if (_messagesService == null)
            {
                _messagesService = new MessagesService();
            }
            if (_pagesService == null)
            {
                _pagesService = new PagesService();
            }
        }

        public void GetUncheckedAgentsCount(List<int> teams)
        {
            view.UncheckedAgentsCount = view.UncheckedAgentsCount == -1 ? _agentsService.GetUncheckedAgentsCount(teams) : view.UncheckedAgentsCount;
        }

        public void GetUnreadMailsCount(int userId)
        {
            view.UnreadMessagesCount = view.UnreadMessagesCount == -1 ? _messagesService.GetUnreadMessagesCount(userId) : view.UnreadMessagesCount;
        }

        public void GetBookmarkedPages(int agentId)
        {
            view.BookmarkedPages = view.BookmarkedPages == null ? _pagesService.GetPagesBookmarkedByAgentId(agentId).ToList() : view.BookmarkedPages;
        }
    }
}
