using EvaluationAssistt.Presenter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using EvaluationAssistt.Service.Services;

namespace EvaluationAssistt.Presenter.Presenters
{
    public class MessagePresenter
    {
        private readonly IMessageView view;

        private static MessagesService _messagesService;
        private static AgentsService _agentsService;

        public MessagePresenter(IMessageView view)
        {
            this.view = view;

            if (_messagesService == null)
            {
                _messagesService = new MessagesService();
            }
            if (_agentsService == null)
            {
                _agentsService = new AgentsService();
            }
        }

        public void GetUsersByTeamId(List<int> list)
        {
            var result = _agentsService.GetAgentsByTeamIds(list).Where(x => x.Id != view.AgentId);

            view.Agents = result;
        }

        public void SendMessage(string subject, string content, List<int> toList)
        {
            _messagesService.SendMessage(subject, content, view.AgentId, toList);
        }

        public void GetMessagesReceived(int userId)
        {
            var result = _messagesService.GetMessagesReceivedByUserId(userId);

            view.MessagesReceived = result;
        }

        public string GetMessageById(int messageId)
        {
            return _messagesService.GetMessageById(messageId);
        }

        public void MarkMessageAsRead(int messageId)
        {
            _messagesService.MarkMessageAsRead(view.AgentId, messageId);
        }

        public void GetMessagesSent(int userId)
        {
            var result = _messagesService.GetMessagesSentByUserId(userId);

            view.MessagesSent = result;
        }
    }
}
