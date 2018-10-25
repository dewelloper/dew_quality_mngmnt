using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Infrastructure.Helpers;
using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Presenter.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace EvaluationAssistt.Web.Pages
{
    public partial class MessageManagement : EvaluationAssisttPage, IMessageView
    {
        public int AgentId
        {
            get
            {
                return UserHelper.UserId;
            }
        }

        public IQueryable<Domain.Dto.AgentsDto> Agents
        {
            set
            {
                lstboxUsers.DataSource = value.ToList().OrderBy(x => x.TeamName).ThenBy(x => x.FullName);
                lstboxUsers.TextField = "AgentTeamFormat";
                lstboxUsers.ValueField = "Id";
                lstboxUsers.DataBind();
            }
        }

        public List<int> AgentsToList
        {
            get
            {
                return null;
            }
        }

        public IQueryable<MessagesDto> MessagesReceived
        {
            set
            {
                gridviewMessagesReceived.DataSource = value.ToList();
                gridviewMessagesReceived.DataBind();
            }
        }

        public IQueryable<MessagesDto> MessagesSent
        {
            set
            {
                gridviewMessagesSent.DataSource = value.ToList();
                gridviewMessagesSent.DataBind();
            }
        }

        private MessagePresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (presenter == null)
            {
                presenter = new MessagePresenter(this);
            }
            if (Request.QueryString["New"] == "1")
            {
                pnlRegister.Visible = true;
            }
            presenter.GetUsersByTeamId(UserHelper.TeamIdsAssociated);
            presenter.GetMessagesReceived(UserHelper.UserId);
            presenter.GetMessagesSent(UserHelper.UserId);
        }

        [WebMethod]
        public static void SendMessage(string subject, string content, string to)
        {
            var presenter =
                new MessagePresenter(HttpContext.Current.Handler as MessageManagement);

            var toList = to.Split(',').Select(int.Parse).ToList();

            presenter.SendMessage(subject, content, toList);
        }

        [WebMethod]
        public static string GetMessage(int messageId)
        {
            var presenter =
                new MessagePresenter(HttpContext.Current.Handler as MessageManagement);

            return presenter.GetMessageById(messageId);
        }

        [WebMethod]
        public static void MarkMessageAsRead(int messageId)
        {
            var presenter =
                new MessagePresenter(HttpContext.Current.Handler as MessageManagement);

            HttpContext.Current.Session["lblUnreadMessagesCount"] = null;

            presenter.MarkMessageAsRead(messageId);
        }
    }
}
