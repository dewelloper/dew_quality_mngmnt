using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Infrastructure.Enums;
using EvaluationAssistt.Infrastructure.Helpers;
using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Presenter.Presenters;
using EvaluationAssistt.Web.JsHelpers;
using System;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;

namespace EvaluationAssistt.Web.Pages
{
    public partial class CallManagement : EvaluationAssisttPage, ICallManagementView
    {
        public int? AgentId
        {
            get
            {
                if (Request.QueryString["AgentId"] == null && cmbAgents.SelectedItem == null)
                {
                    return null;
                }
                if (Request.QueryString["AgentId"] != null)
                {
                    //presenter.GetAgentsAll();
                    var agent_id = Request.QueryString["AgentId"];
                    int agentId;
                    Int32.TryParse(agent_id, out agentId);
                    Session["AgentId"] = agent_id;
                    cmbAgents.SelectedItem = cmbAgents.Items.FindByValue(agentId);
                }

                return Convert.ToInt32(cmbAgents.Value);
            }
            set
            {
                cmbAgents.SelectedItem = cmbAgents.Items.FindByValue(value);
            }
        }

        public IQueryable<AgentsDto> Agents
        {
            set
            {
                var agents = value.ToList();
                agents.Sort();
                agents.Insert(0, new AgentsDto { FirstName = "Tümü", Id = 0 });
                cmbAgents.DataSource = agents;
                cmbAgents.TextField = "CallManagementFormat";
                cmbAgents.ValueField = "Id";
                cmbAgents.DataBind();
            }
        }

        public DateTime? MinDate
        {
            get
            {
                return Convert.ToDateTime(dateMin.Value);
            }
            set
            {
                dateMin.Value = value;
            }
        }

        public DateTime? MaxDate
        {
            get
            {
                return Convert.ToDateTime(dateMax.Value);
            }
            set
            {
                dateMax.Value = value;
            }
        }

        public int MinDuration
        {
            get
            {
                return Convert.ToInt32(numMinDuration.Value);
            }
            set
            {
                numMinDuration.Value = value;
            }
        }

        public int MaxDuration
        {
            get
            {
                return Convert.ToInt32(numMaxDuration.Value);
            }
            set
            {
                numMaxDuration.Value = value;
            }
        }

        public string Ucid
        {
            get
            {
                return txtUCID.Text;
            }
            set
            {
                txtUCID.Text = value;
            }
        }

        public string CallingDeviceId
        {
            get
            {
                return txtCallingDeviceId.Text;
            }
            set
            {
                txtCallingDeviceId.Text = value;
            }
        }

        public string Remark
        {
            get
            {
                return txtRemark.Text;
            }
            set
            {
                txtRemark.Text = value;
            }
        }

        public IQueryable<CallsDto> Calls
        {
            set
            {
                gridviewCalls.DataSource = value.ToList();
                gridviewCalls.DataBind();
                Session["TempData"] = value.ToList();
            }
        }

        public IQueryable<CallsDto> CallsRandom
        {
            set
            {
                gridviewCalls.DataSource = value.ToList();
                gridviewCalls.DataBind();
                Session["TempData"] = value.ToList();
            }
        }

        public int LocationId
        {
            get
            {
                return Convert.ToInt32(cmbLocations.Value);
            }
        }

        public IQueryable<LocationsDto> Locations
        {
            set
            {
                cmbLocations.DataSource = value.ToList();
                cmbLocations.TextField = "Name";
                cmbLocations.ValueField = "Id";
                cmbLocations.DataBind();
            }
        }

        public int GroupId
        {
            get
            {
                return Convert.ToInt32(cmbGroups.Value);
            }
        }

        public IQueryable<GroupsDto> Groups
        {
            set
            {
                var list = value.ToList();
                list.Insert(0, new GroupsDto() { Id = 0, Name = "Seçiniz" });
                cmbGroups.DataSource = list;
                cmbGroups.TextField = "GroupAgentName";
                cmbGroups.ValueField = "Id";
                cmbGroups.DataBind();
            }
        }

        public int TeamId
        {
            get
            {
                if (cmbTeams.Value != null && cmbTeams.Value.ToString() != "")
                    Session["TeamId"] = cmbTeams.Value;

                if (Session["TeamId"] != null && cmbTeams.Value == null)
                    return Convert.ToInt32(Session["TeamId"].ToString());
                    
                return Convert.ToInt32(cmbTeams.Value);
            }
        }

        public IQueryable<TeamsDto> Teams
        {
            set
            {
                var list = value.ToList();
                list.Insert(0, new TeamsDto() { Id = 0, Name = "Seçiniz" });
                cmbTeams.DataSource = list;
                cmbTeams.TextField = "TeamAgentName";
                cmbTeams.ValueField = "Id";
                cmbTeams.DataBind();

                var previousUrl = Request.UrlReferrer.ToString();
                if (Session["LocationId"] != null && previousUrl.Contains("Questionnaires"))
                {
                    SetSelections();
                    btnExecute_Click(null, null);
                }
            }
        }

        private CallManagementPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlHelper.SelectMenu(this, "liCall");

            if (presenter == null)
            {
                presenter = new CallManagementPresenter(this);
            }
            presenter.GetLocations();

            if (AgentId.HasValue && !Page.IsPostBack)
            {
                presenter.GetCallsByAgentIdForThisMonth();
            }
            if (!IsPostBack)
            {
                dateMin.Date = StartOfDay(DateTime.Now);
                dateMax.Date = EndOfDay(DateTime.Now);

                MinDate = StartOfDay(DateTime.Now);
                MaxDate = EndOfDay(DateTime.Now);
            }

            var previousUrl = Request.UrlReferrer.ToString();
            if (Session["LocationId"] != null && previousUrl.Contains("Questionnaires"))
            {
                var userid = UserHelper.UserId;
                var locationId = Convert.ToInt32(Session["LocationId"]);
                var groupId = Convert.ToInt32(Session["GroupId"]);
                cmbLocations.Value = locationId;
                cmbGroups.Value = groupId;
                cmbAgents.Value = Convert.ToInt32(Session["cmbAgents"]);

                if (Session["dateMin"] != null)
                {
                    dateMin.Value = Session["dateMin"].ToString();
                }
                if (Session["dateMax"] != null)
                {
                    dateMax.Value = Session["dateMax"].ToString();
                }

                presenter.GetGroups(userid);
                presenter.GetTeams(userid);
            }

            if(!IsPostBack)
                cmbTeams_Callback(null, null);
        }

        public void SetSelections()
        {
            if (Session["LocationId"] != null)
            {
                var locationId = Convert.ToInt32(Session["LocationId"]);
                for (var k = 0; k < cmbLocations.Items.Count; k++)
                {
                    if (Convert.ToInt32(cmbLocations.Items[k].Value) == locationId)
                    {
                        cmbLocations.SelectedIndex = k;
                        break;
                    }
                }

                if (Session["GroupId"] != null)
                {
                    var groupId = Convert.ToInt32(Session["GroupId"]);

                    for (var k = 0; k < cmbGroups.Items.Count; k++)
                    {
                        if (Convert.ToInt32(cmbGroups.Items[k].Value) == groupId)
                        {
                            cmbGroups.SelectedIndex = k;
                            break;
                        }
                    }
                }

                if (Session["TeamId"] != null)
                {
                    var teamId = Convert.ToInt32(Session["TeamId"]);

                    for (var k = 0; k < cmbTeams.Items.Count; k++)
                    {
                        if (Convert.ToInt32(cmbTeams.Items[k].Value) == teamId)
                        {
                            cmbTeams.SelectedIndex = k;
                            break;
                        }
                    }
                }

                if (Session["AgentId"] != null)
                {
                    var agentId = Convert.ToInt32(Session["AgentId"]);

                    for (var k = 0; k < cmbAgents.Items.Count; k++)
                    {
                        if (Convert.ToInt32(cmbAgents.Items[k].Value) == agentId)
                        {
                            cmbAgents.SelectedIndex = k;
                            break;
                        }
                    }
                }


                if (Session["MinDuration"] != null)
                {
                    MinDuration = Convert.ToInt32(Session["MinDuration"]);
                }
                if (Session["numMaxDuration"] != null && Session["numMaxDuration"].GetType().Name == "ASPxSpinEdit")
                {
                    numMaxDuration.Value = Convert.ToInt32(((DevExpress.Web.ASPxSpinEdit)(Session["numMaxDuration"])).Value);
                }
                else
                {
                    try
                    {
                        numMaxDuration.Value = Convert.ToInt32(Session["numMaxDuration"].ToString());
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }

        public DateTime EndOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }

        public DateTime StartOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        }

        protected void btnExecute_Click(object sender, EventArgs e)
        {
            var locationName = cmbLocations.SelectedItem == null ? string.Empty : cmbLocations.SelectedItem.Text;
            var groupName = Convert.ToInt32(cmbGroups.SelectedItem == null ? "0" : cmbGroups.SelectedItem.Value);
            var teamId = Convert.ToInt32(cmbTeams.SelectedItem == null ? "0" : cmbTeams.SelectedItem.Value);
            var assistantId = Convert.ToInt32(cmbAgents.SelectedItem == null ? "0" : cmbAgents.SelectedItem.Value);
            var numMinDurationP = 0;
            var numMaxDurationP = 0;
            Int32.TryParse(numMinDuration.Value.ToString(), out numMinDurationP);
            Int32.TryParse(numMaxDuration.Value.ToString(), out numMaxDurationP);
            var minDate = DateTime.Parse(dateMin.Text);
            var maxDate = DateTime.Parse(dateMax.Text);
            var callingPhone = txtCallingDeviceId.Text;
            var ucid = txtUCID.Text;
            var userId = UserHelper.UserId;

            var settings = WebConfigurationManager.AppSettings;
            var CallResultShowTypeId = Convert.ToBoolean(settings["CallResultShowTypeId"].ToString().Trim() == "1");

            var scillNo = txtScilNo.Text;
            var loginId = txtLoginId.Text;

            if ((maxDate - minDate).Days > 31 && locationName == string.Empty && scillNo == string.Empty && loginId == string.Empty && ucid == string.Empty && callingPhone == string.Empty)
            {
                JsPopup.Popup(this, MessageType.Warning, "Bu sorgu sonucunda gelecek data miktarı sistemin çalışmasını yavaşlatabileceği için, diğer filitreleri de kullanmanız yahut tarih filtresini bir ya da birkaç güne kadar indirgemeniz gerekmektedir.", true);
                return;
            }

            Session["LocationId"] = LocationId;
            Session["GroupId"] = GroupId;
            Session["TeamId"] = TeamId;
            Session["AgentId"] = AgentId;
            Session["MinDuration"] = MinDuration;
            Session["numMaxDuration"] = numMaxDuration;
            Session["dateMin"] = dateMin.Value;
            Session["dateMax"] = dateMax.Value;

            presenter.GetCalls(UserHelper.TeamIdsAssociated,
                locationName,
                groupName,
                teamId,
                assistantId,
                numMinDurationP, numMaxDurationP, callingPhone, ucid, userId, CallResultShowTypeId, scillNo, loginId);
        }

        protected void cmbGroups_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (presenter == null)
            {
                presenter = new CallManagementPresenter(this);
            }
            var userid = UserHelper.UserId;
            presenter.GetGroups(userid);
        }

        protected void cmbTeams_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (presenter == null)
            {
                presenter = new CallManagementPresenter(this);
            }
            var userid = UserHelper.UserId;
            presenter.GetTeams(userid);
        }

        protected void gridviewCalls_BeforeColumnSortingGrouping(object sender, DevExpress.Web.ASPxGridViewBeforeColumnGroupingSortingEventArgs e)
        {
            if (!IsCallback)
            {
                return;
            }
            gridviewCalls.DataSource = Session["TempData"];
            gridviewCalls.DataBind();
        }

        protected void gridviewCalls_PageIndexChanged(object sender, EventArgs e)
        {
            if (!IsCallback)
            {
                return;
            }
            gridviewCalls.DataSource = Session["TempData"];
            gridviewCalls.DataBind();
        }

        protected void gridviewCalls_AutoFilterCellEditorCreate(object sender, DevExpress.Web.ASPxGridViewEditorCreateEventArgs e)
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
                presenter = new CallManagementPresenter(this);
            }
            gridviewCalls.DataSource = Session["TempData"];
            gridviewCalls.DataBind();
        }

        [WebMethod]
        public static string PlayFile(int callId)
        {
            var presenter
            = new CallManagementPresenter(HttpContext.Current.Handler as CallManagement);

            var fileName = presenter.GetFileName(callId);

            return FileHelper.GetSoundPlayer(FileHelper.GetFilePath(fileName));
        }

        public bool IsListenable
        {
            get
            {
                var settings = WebConfigurationManager.AppSettings;
                var isListenable = Convert.ToBoolean(settings["IsListenable"].ToString().Trim() == "1");
                return isListenable;
            }
        }

        protected void btnRandomRetrive_Click(object sender, EventArgs e)
        {
            var startDate = DateTime.Today.AddDays(-Convert.ToInt32(cmbDaysCount.Value));
            var randomCount = Convert.ToInt32(cmbRandomCount.Value);

            presenter.GetCallsRandom(startDate, randomCount);
        }

        protected void btnExporter_Click(object sender, EventArgs e)
        {
            gridviewCalls.DataSource = Session["TempData"];
            gridviewCalls.DataBind();
            aspxGrdExporter.WriteXlsxToResponse("RandomReport_" + DateTime.Now.ToString("ddMMyyyyHHMM"));
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Session["LocationId"] = null;
            Session["GroupId"] = null;
            Session["TeamId"] = null;
            Session["AgentId"] = null;
            Session["MinDuration"] = null;
            Session["numMaxDuration"] = null;
            Session["dateMin"] = null;
            Session["dateMax"] = null;
        }

        protected void dateMin_DateChanged(object sender, EventArgs e)
        {
            if (!dateMin.Date.ToString().Contains("0001"))
            {
                Session["dateMin"] = dateMin.Date;
            }
            else
            {
                dateMin.Date = Convert.ToDateTime(Session["dateMin"]);
            }
            if (cmbLocations.SelectedItem != null)
            {
                Session["LocationId"] = cmbLocations.SelectedItem.Value;
            }
            if (cmbGroups.SelectedItem != null)
            {
                Session["GroupId"] = cmbGroups.SelectedItem.Value;
            }
            if (cmbTeams.SelectedItem != null)
            {
                Session["TeamId"] = cmbTeams.SelectedItem.Value;
            }
            if (cmbAgents.SelectedItem != null)
            {
                Session["AgentId"] = cmbAgents.SelectedItem.Value;
            }
            if (numMinDuration.Text != string.Empty)
            {
                Session["MinDuration"] = numMinDuration.Text;
            }
            if (numMaxDuration.Text != string.Empty)
            {
                Session["numMaxDuration"] = numMaxDuration.Text;
            }
        }

        protected void dateMax_DateChanged(object sender, EventArgs e)
        {
            if (!dateMax.Date.ToString().Contains("0001"))
            {
                Session["dateMax"] = dateMax.Date;
            }
            else
            {
                dateMax.Date = Convert.ToDateTime(Session["dateMax"]);
            }
            if (cmbLocations.SelectedItem != null)
            {
                Session["LocationId"] = cmbLocations.SelectedItem.Value;
            }
            if (cmbGroups.SelectedItem != null)
            {
                Session["GroupId"] = cmbGroups.SelectedItem.Value;
            }
            if (cmbTeams.SelectedItem != null)
            {
                Session["TeamId"] = cmbTeams.SelectedItem.Value;
            }
            if (cmbAgents.SelectedItem != null)
            {
                Session["AgentId"] = cmbAgents.SelectedItem.Value;
            }
            if (numMinDuration.Text != string.Empty)
            {
                Session["MinDuration"] = numMinDuration.Text;
            }
            if (numMaxDuration.Text != string.Empty)
            {
                Session["numMaxDuration"] = numMaxDuration.Text;
            }
        }

        protected void cmbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
