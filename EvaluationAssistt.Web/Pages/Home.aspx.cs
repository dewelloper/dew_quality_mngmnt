using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Domain.Entity;
using EvaluationAssistt.Infrastructure.Enums;
using EvaluationAssistt.Infrastructure.Helpers;
using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Presenter.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;

namespace EvaluationAssistt.Web.Pages
{
    public partial class Home : EvaluationAssisttPage, IHomeView
    {
        public int AgentId
        {
            get
            {
                return UserHelper.UserId == null ? 0 : (int)UserHelper.UserId;
            }
        }
        public int AgentCallCount
        {
            set
            {
                lblCallCount.InnerText = value.ToString("n0");
            }
        }
        public int AgentAverageCallDuration
        {
            set
            {
                lblAverageCallDuration.InnerText = value.ToString("n0");
            }
        }
        public DateTime DateMin
        {
            get
            {
                var date = Convert.ToDateTime(dateMin.Value);
                return TypeHelper.DateTime(date, TypeHelper.DateTimeType.Min);
            }
        }
        public DateTime DateMax
        {
            get
            {
                var date = Convert.ToDateTime(dateMax.Value);
                return TypeHelper.DateTime(date, TypeHelper.DateTimeType.Max);
            }
        }
        public IQueryable<FormsCallsDto> CallsEvaluatedLast30Days
        {
            set
            {
                gridviewCalls.DataSource = value.ToList().OrderByDescending(x => x.EvaluationDate);
                gridviewCalls.DataBind();
            }
        }

        public int TeamId
        {
            get
            {
                return UserHelper.TeamId == null ? 0 : (int)UserHelper.TeamId;
            }
        }
        public DateTime DateTeamMin
        {
            get
            {
                var date = Convert.ToDateTime(dateMinTeam.Value);
                return TypeHelper.DateTime(date, TypeHelper.DateTimeType.Min);
            }
        }
        public DateTime DateTeamMax
        {
            get
            {
                var date = Convert.ToDateTime(dateMaxTeam.Value);
                return TypeHelper.DateTime(date, TypeHelper.DateTimeType.Max);
            }
        }
        public IQueryable<ufnCallSummaries_Result> TeamCallSummaries
        {
            set
            {
                repeaterTeamCallSummaries.DataSource = value.OrderBy(x => x.AgentName).Take(50);
                repeaterTeamCallSummaries.DataBind();
            }
        }
        public IQueryable<ufnCallEvaluatedSummaries_Result> TeamCallEvaluatedSummaries
        {
            set
            {
                repeaterTeamCallEvaluatedSummaries.DataSource = value.OrderBy(x => x.AgentName);
                repeaterTeamCallEvaluatedSummaries.DataBind();
            }
        }
        public DateTime DateTeamLeaderMin
        {
            get
            {
                var date = Convert.ToDateTime(dateMinTeamLeader.Value);
                return TypeHelper.DateTime(date, TypeHelper.DateTimeType.Min);
            }
        }
        public DateTime DateTeamLeaderMax
        {
            get
            {
                var date = Convert.ToDateTime(dateMaxTeamLeader.Value);
                return TypeHelper.DateTime(date, TypeHelper.DateTimeType.Max);
            }
        }
        public IQueryable<ufnCallEvaluatedTeamLeaderSummaries_Result> TeamLeaderCallEvaluatedSummaries
        {
            set
            {
                repeaterTeamLeaderCallEvaluatedSummaries.DataSource = value.OrderBy(x => x.FormName);
                repeaterTeamLeaderCallEvaluatedSummaries.DataBind();
            }
        }
        public IQueryable<FormsCallsDto> CallsEvaluatedWithRemarks
        {
            set
            {
                var vlist = value.ToList();
                var isDisplaying = false;
                foreach (FormsCallsDto fcd in vlist)
                {
                    if (fcd.CallState == 1 || fcd.CallState == 32)
                    {
                        isDisplaying = true;
                    }
                }

                if (isDisplaying)
                {
                    Session["isExistAttention"] = true;
                }
                else
                {
                    Session["isExistAttention"] = null;
                }

                gridviewCallsEvaluated.DataSource = value.ToList().OrderByDescending(x => x.EvaluationDate);
                gridviewCallsEvaluated.DataBind();
                Session["HomeTempDataEv"] = value.ToList().OrderByDescending(x => x.EvaluationDate);
            }
        }

        public IQueryable<FormsCallsDto> CallsEvaluatedByTeamsAndDate
        {
            set
            {
                grdmycalls.DataSource = value.ToList();
                grdmycalls.DataBind();

                Session["HomeTempData"] = value.ToList();
            }
        }

        public int GroupId
        {
            get
            {
                return (int)UserHelper.GroupId;
            }
        }
        public DateTime DateGroupMin
        {
            get
            {
                return new DateTime();
            }
        }
        public DateTime DateGroupMax
        {
            get
            {
                return new DateTime();
            }
        }
        public IQueryable<ufnCallTeamSummaries_Result> GroupLeaderCallSummaries
        {
            set
            {
                repeaterGroupCallSummaries.DataSource = value.OrderBy(x => x.TeamName);
                repeaterGroupCallSummaries.DataBind();
            }
        }

        public bool EvaluationSearchIsAuthenticated
        {
            get
            {
                var settings = WebConfigurationManager.AppSettings;
                var homeEvaluationResultLinkedToTeamleader = Convert.ToBoolean(settings["HomeEvaluationResultLinkedToTeamleader"].ToString().Trim() == "1");
                return homeEvaluationResultLinkedToTeamleader;
            }
        }

        private HomePresenter presenter;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            var settings = WebConfigurationManager.AppSettings;
            var canSee = Convert.ToBoolean(settings["CanSeeOtherCalls"].ToString().Trim() == "1");

            switch (UserHelper.Type)
            {
                case EvaluationAssistt.Infrastructure.Enums.UserType.Agent:
                    pnlAgent.Visible = true;
                    pnlTeamLeader.Visible = false;
                    pnlGroupLeader.Visible = false;
                    dateMin.Value = DateTime.Now;
                    dateMax.Value = DateTime.Now;
                    if (canSee)
                    {
                        rbListEvaluater.Style.Add("visibility", "hidden");
                    }
                    break;

                case EvaluationAssistt.Infrastructure.Enums.UserType.TeamLeader:
                    pnlAgent.Visible = false;
                    pnlTeamLeader.Visible = true;
                    pnlGroupLeader.Visible = false;
                    dateMinTeam.Value = DateTime.Now;
                    dateMaxTeam.Value = DateTime.Now;
                    dateMinTeamLeader.Value = TypeHelper.DateTimeMonthRange(DateTime.Now, TypeHelper.DateTimeType.Min);
                    dateMaxTeamLeader.Value = TypeHelper.DateTimeMonthRange(DateTime.Now, TypeHelper.DateTimeType.Max);
                    if (canSee)
                    {
                        rbListEvaluater.Style.Add("visibility", "hidden");
                    }
                    break;

                case EvaluationAssistt.Infrastructure.Enums.UserType.GroupLeader:
                    pnlAgent.Visible = false;
                    pnlTeamLeader.Visible = true;
                    pnlGroupLeader.Visible = true;
                    rbListEvaluater.Style.Add("visibility", "hidden");
                    break;

                case EvaluationAssistt.Infrastructure.Enums.UserType.QualityExpert:
                    pnlAgent.Visible = false;
                    pnlTeamLeader.Visible = true;
                    pnlGroupLeader.Visible = true;
                    rbListEvaluater.Style.Add("visibility", "visible");
                    break;
                case EvaluationAssistt.Infrastructure.Enums.UserType.Admin:
                    pnlAgent.Visible = false;
                    pnlTeamLeader.Visible = true;
                    pnlGroupLeader.Visible = true;
                    rbListEvaluater.Style.Add("visibility", "visible");
                    break;

                default:
                    break;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["LocationId"] = null;

            HtmlHelper.SelectMenu(this, "liHome");

            if (presenter == null)
            {
                presenter = new HomePresenter(this);
            }
            if (UserHelper.Type == UserType.Agent)
            {
                presenter.GetCallSummary();
                presenter.GetCallsEvaluatedLast30Days();
            }
            else
            {
                if (UserHelper.Type == UserType.TeamLeader || UserHelper.Type == UserType.Admin || UserHelper.Type == UserType.QualityExpert || UserHelper.Type == UserType.GroupLeader)
                {
                    var userTypeId = 0;
                    if (UserHelper.Type == UserType.Admin)
                    {
                        userTypeId = 1;
                    }
                    else
                    {
                        if (UserHelper.Type == UserType.QualityExpert)
                        {
                            userTypeId = 2;
                        }
                        else
                        {
                            if (UserHelper.Type == UserType.GroupLeader)
                            {
                                userTypeId = 3;
                            }
                            else
                            {
                                if (UserHelper.Type == UserType.TeamLeader)
                                {
                                    userTypeId = 4;
                                }
                                else
                                {
                                    if (UserHelper.Type == UserType.Agent)
                                    {
                                        userTypeId = 5;
                                    }
                                }
                            }
                        }
                    }
                    var startDate = DateTime.Now.AddDays(-7);
                    var endDate = DateTime.Now;

                    if (!IsPostBack)
                    {
                        dateMin.Date = StartOfDay(DateTime.Now);
                        dateMax.Date = EndOfDay(DateTime.Now);
                        dateMinTeamLeader.Date = StartOfDay(DateTime.Now);
                        dateMaxTeamLeader.Date = EndOfDay(DateTime.Now);
                        startDate = dateMin.Date;
                        endDate = dateMax.Date;
                    }

                    presenter.GetCallsEvaluatedWithRemarks(userTypeId, startDate, endDate);
                    if (!IsPostBack)
                    {
                        rbListEvaluater.SelectedIndex = 0;
                        btnMyEvaluated_Click(null, null);
                    }
                }
            }
            rbListEvaluater.Items[0].Attributes.Add("class", "Redbutton");
            rbListEvaluater.Items[1].Attributes.Add("class", "Greenbutton");
        }

        public DateTime EndOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }

        public DateTime StartOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        }

        [WebMethod]
        public static string GetCallSummary(string dateMin, string dateMax)
        {
            var dMin = TypeHelper.DateTime(DateTime.Parse(dateMin), TypeHelper.DateTimeType.Min);
            var dMax = TypeHelper.DateTime(DateTime.Parse(dateMax), TypeHelper.DateTimeType.Max);

            var presenter = new HomePresenter(HttpContext.Current.Handler as Home);
            return presenter.GetCallSummaryAjax(dMin, dMax);
        }

        [WebMethod]
        public static string GetTeamCallSummary(string dateMin, string dateMax)
        {
            var dMin = TypeHelper.DateTime(DateTime.Parse(dateMin), TypeHelper.DateTimeType.Min);
            var dMax = TypeHelper.DateTime(DateTime.Parse(dateMax), TypeHelper.DateTimeType.Max);

            var presenter = new HomePresenter(HttpContext.Current.Handler as Home);
            return presenter.GetTeamCallSummaryAjax(dMin, dMax);
        }

        [WebMethod]
        public static string GetTeamLeaderCallEvaluatedSummary(string dateMin, string dateMax)
        {
            var dMin = DateTime.Parse(dateMin);
            var dMax = DateTime.Parse(dateMax);
            var presenter = new HomePresenter(HttpContext.Current.Handler as Home);
            return presenter.GetTeamLeaderCallEvaluatedSummaryAjax(dMin, dMax);
        }

        [WebMethod]
        public static string GetGroupCallSummary(string dateMin, string dateMax)
        {
            var dMin = TypeHelper.DateTime(DateTime.Parse(dateMin), TypeHelper.DateTimeType.Min);
            var dMax = TypeHelper.DateTime(DateTime.Parse(dateMax), TypeHelper.DateTimeType.Max);

            var presenter = new HomePresenter(HttpContext.Current.Handler as Home);
            return presenter.GetGroupCallSummaryAjax(dMin, dMax);
        }

        [WebMethod]
        public static string GetGroupTeamCallSummary(int teamId, string dateMin, string dateMax)
        {
            var dMin = TypeHelper.DateTime(DateTime.Parse(dateMin), TypeHelper.DateTimeType.Min);
            var dMax = TypeHelper.DateTime(DateTime.Parse(dateMax), TypeHelper.DateTimeType.Max);

            var presenter = new HomePresenter(HttpContext.Current.Handler as Home);
            return presenter.GetTeamCallSummaryAjax(teamId, dMin, dMax);
        }

        protected void btnMyEvaluated_Click(object sender, EventArgs e)
        {
            var evaluatorId = 0;
            if (rbListEvaluater.SelectedIndex == 0)
            {
                evaluatorId = UserHelper.UserId;
            }
            var teams = new List<int>();
            teams.Add(Convert.ToInt32(UserHelper.TeamId));

            if (UserHelper.Type == UserType.Admin || UserHelper.Type == UserType.QualityExpert)
            {
                teams.Clear();
                teams.Add(99999);
            }

            presenter.GetCallsEvaluatedByTeamsAndDate(teams, dateMinTeamLeader.Date, dateMaxTeamLeader.Date, evaluatorId);

            var userTypeId = 0;
            if (UserHelper.Type == UserType.Admin)
            {
                userTypeId = 1;
            }
            else
            {
                if (UserHelper.Type == UserType.QualityExpert)
                {
                    userTypeId = 2;
                }
                else
                {
                    if (UserHelper.Type == UserType.GroupLeader)
                    {
                        userTypeId = 3;
                    }
                    else
                    {
                        if (UserHelper.Type == UserType.TeamLeader)
                        {
                            userTypeId = 4;
                        }
                        else
                        {
                            if (UserHelper.Type == UserType.Agent)
                            {
                                userTypeId = 5;
                            }
                        }
                    }
                }
            }
            presenter.GetCallsEvaluatedWithRemarks(userTypeId, dateMinTeamLeader.Date, dateMaxTeamLeader.Date);
        }

        protected void grdmycalls_AutoFilterCellEditorCreate(object sender, DevExpress.Web.ASPxGridViewEditorCreateEventArgs e)
        {
            if (!IsCallback)
            {
                return;
            }
            if (String.IsNullOrEmpty(e.Column.FilterExpression))
            {
                return;
            }
            if (presenter == null)
            {
                presenter = new HomePresenter(this);
            }
            grdmycalls.DataSource = Session["HomeTempData"];
            grdmycalls.DataBind();
        }

        protected void grdmycalls_BeforeColumnSortingGrouping(object sender, DevExpress.Web.ASPxGridViewBeforeColumnGroupingSortingEventArgs e)
        {
            if (!IsCallback)
            {
                return;
            }
            grdmycalls.DataSource = Session["HomeTempData"];
            grdmycalls.DataBind();
        }

        protected void grdmycalls_PageIndexChanged(object sender, EventArgs e)
        {
            if (!IsCallback)
            {
                return;
            }
            grdmycalls.DataSource = Session["HomeTempData"];
            grdmycalls.DataBind();
        }

        protected void gridviewCallsEvaluated_AutoFilterCellEditorCreate(object sender, DevExpress.Web.ASPxGridViewEditorCreateEventArgs e)
        {
            if (!IsCallback)
            {
                return;
            }
            if (String.IsNullOrEmpty(e.Column.FilterExpression))
            {
                return;
            }
            if (presenter == null)
            {
                presenter = new HomePresenter(this);
            }
            gridviewCallsEvaluated.DataSource = Session["HomeTempDataEv"];
            gridviewCallsEvaluated.DataBind();
        }

        protected void gridviewCallsEvaluated_BeforeColumnSortingGrouping(object sender, DevExpress.Web.ASPxGridViewBeforeColumnGroupingSortingEventArgs e)
        {
            if (!IsCallback)
            {
                return;
            }
            gridviewCallsEvaluated.DataSource = Session["HomeTempDataEv"];
            gridviewCallsEvaluated.DataBind();
        }

        protected void gridviewCallsEvaluated_PageIndexChanged(object sender, EventArgs e)
        {
            if (!IsCallback)
            {
                return;
            }
            gridviewCallsEvaluated.DataSource = Session["HomeTempDataEv"];
            gridviewCallsEvaluated.DataBind();
        }
    }
}
