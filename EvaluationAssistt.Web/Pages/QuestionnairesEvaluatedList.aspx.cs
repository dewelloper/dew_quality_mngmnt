using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Presenter.Presenters;
using EvaluationAssistt.Infrastructure.Helpers;
using EvaluationAssistt.Domain.Dto;
using System.Web.Services;
using System.Web.Configuration;

namespace EvaluationAssistt.Web.Pages
{
    public partial class QuestionnairesEvaluatedList : EvaluationAssisttPage, IQuestionnairesEvaluatedListView, EvaluationAssistt.Web.Pages.IQuestionnairesEvaluatedList
    {
        public IQueryable<FormsCallsDto> Calls
        {
            set
            {
                gridviewCalls.DataSource = value.ToList();
                gridviewCalls.DataBind();
            }
        }

        public List<int> Teams
        {
            get
            {
                return UserHelper.TeamIdsAssociated;
            }
        }

        public bool Evaluationtype
        {
            get
            {
                var settings = WebConfigurationManager.AppSettings;
                var evaluationSearchIsAuthenticated = Convert.ToBoolean(settings["EvaluationSearchIsAuthenticated"].ToString().Trim() == "1");
                return evaluationSearchIsAuthenticated;
            }
        }

        public int AgentId
        {
            get
            {
                return UserHelper.UserId == null ? 0 : (int)UserHelper.UserId;
            }
        }

        private QuestionnairesEvaluatedListPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (presenter == null)
            {
                presenter = new QuestionnairesEvaluatedListPresenter(this);
            }
        }

        protected void btnExecute_Click(object sender, EventArgs e)
        {
            var scoreMin = numMinDuration.Value == null ? (int?)null : int.Parse(numMinDuration.Text);
            var scoreMax = numMaxDuration.Value == null ? (int?)null : int.Parse(numMaxDuration.Text);

            presenter.GetCallsEvaluated(scoreMin, scoreMax);
        }

        [WebMethod]
        public static void DeleteEvaluation(int id)
        {
            var presenter =
                new QuestionnairesEvaluatedListPresenter(HttpContext.Current.Handler as QuestionnairesEvaluatedList);

            presenter.DeleteEvaluation(id);
        }

        protected void gridviewCalls_BeforeColumnSortingGrouping(object sender, DevExpress.Web.ASPxGridViewBeforeColumnGroupingSortingEventArgs e)
        {
            var scoreMin = numMinDuration.Value == null ? (int?)null : int.Parse(numMinDuration.Text);
            var scoreMax = numMaxDuration.Value == null ? (int?)null : int.Parse(numMaxDuration.Text);

            presenter.GetCallsEvaluated(scoreMin, scoreMax);
        }

        protected void gridviewCalls_PageIndexChanged(object sender, EventArgs e)
        {
            var scoreMin = numMinDuration.Value == null ? (int?)null : int.Parse(numMinDuration.Text);
            var scoreMax = numMaxDuration.Value == null ? (int?)null : int.Parse(numMaxDuration.Text);

            presenter.GetCallsEvaluated(scoreMin, scoreMax);
        }

        protected void gridviewCalls_AutoFilterCellEditorCreate(object sender, DevExpress.Web.ASPxGridViewEditorCreateEventArgs e)
        {
            if (String.IsNullOrEmpty(e.Column.FilterExpression))
            {
                return;
            }
            var scoreMin = numMinDuration.Value == null ? (int?)null : int.Parse(numMinDuration.Text);
            var scoreMax = numMaxDuration.Value == null ? (int?)null : int.Parse(numMaxDuration.Text);

            if (presenter == null)
            {
                presenter = new QuestionnairesEvaluatedListPresenter(this);
            }
            presenter.GetCallsEvaluated(scoreMin, scoreMax);
        }
    }
}
