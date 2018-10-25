using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Infrastructure.Enums;
using EvaluationAssistt.Infrastructure.Extensions;
using EvaluationAssistt.Infrastructure.Helpers;
using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Presenter.Presenters;
using EvaluationAssistt.Web.JsHelpers;
using System;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace EvaluationAssistt.Web.Pages
{
    public partial class TeamManagement : EvaluationAssisttPage, ITeamManagementView
    {
        public int Id
        {
            get
            {
                if (ViewState["Id"] == null)
                {
                    ViewState["Id"] = 0;
                }

                return Convert.ToInt32(ViewState["Id"]);
            }
            set
            {
                ViewState["Id"] = value;
            }
        }

        public string Name
        {
            get
            {
                return txtName.Text;
            }
            set
            {
                txtName.Text = value;
            }
        }

        public int GroupId
        {
            get
            {
                return Convert.ToInt32(cmbGroup.Value);
            }
            set
            {
                cmbGroup.SelectedItem = cmbGroup.Items.FindByValue(value);
            }
        }

        public int AgentId
        {
            get
            {
                return Convert.ToInt32(cmbAgent.Value);
            }
            set
            {
                cmbAgent.SelectedItem = cmbAgent.Items.FindByValue(value);
            }
        }

        public IQueryable<TeamsDto> Teams
        {
            set
            {
                gridviewTeams.DataSource = value.ToList();
                gridviewTeams.DataBind();
            }
        }

        public IQueryable<GroupsDto> Groups
        {
            set
            {
                cmbGroup.DataSource = value.ToList();
                cmbGroup.TextField = "GroupAgentName";
                cmbGroup.ValueField = "Id";
                cmbGroup.DataBind();
            }
        }

        public IQueryable<AgentsDto> Agents
        {
            set
            {
                cmbAgent.DataSource = value.ToList();
                cmbAgent.TextField = "FullName";
                cmbAgent.ValueField = "Id";
                cmbAgent.DataBind();
            }
        }

        public TeamsDto Dto
        {
            get
            {
                var dto = new TeamsDto()
                { Id = Id,
                    Name = Name,
                    GroupId = GroupId,
                    AgentId = AgentId
                };

                return dto;
            }
        }

        private TeamManagementPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (presenter == null)
            {
                presenter = new TeamManagementPresenter(this);
            }
            presenter.GetTeamsAll();
            presenter.GetGroupsNameValueCollection();
            presenter.GetAgentsNameValueCollection();

            if (EntitySelect)
            {
                presenter.GetTeamById(EntityId);
                NewEntryUI();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Id == 0)
            {
                presenter.InsertTeam();
                JsPopup.Popup(this, MessageType.Success, MessageHelper.CRUDMessage.SuccessInsert("TakÄ±m"));
            }
            else
            {
                presenter.UpdateTeam();
                JsPopup.Popup(this, MessageType.Success, MessageHelper.CRUDMessage.SuccessUpdate("TakÄ±m"));
            }

            presenter.GetTeamsAll();
            CancelEntryUI();
        }

        [WebMethod]
        public static void DeleteTeam(int id)
        {
            var presenter =
                   new TeamManagementPresenter(HttpContext.Current.Handler as TeamManagement);

            presenter.DeleteAgent(id);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            CancelEntryUI();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            NewEntryUI();
        }

        private void NewEntryUI()
        {
            pnlRegister.Visible = true;
            btnNew.Visible = false;
        }

        private void CancelEntryUI()
        {
            pnlRegister.Clear();
            pnlRegister.Visible = false;
            btnNew.Visible = true;
            Id = 0;
        }
    }
}
