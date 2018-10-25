using DevExpress.Web;
using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Infrastructure.Enums;
using EvaluationAssistt.Infrastructure.Extensions;
using EvaluationAssistt.Infrastructure.Helpers;
using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Presenter.Presenters;
using EvaluationAssistt.Web.JsHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace EvaluationAssistt.Web.Pages
{
    public partial class AgentManagement : EvaluationAssisttPage, IAgentManagementView
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

        public string LoginId
        {
            get
            {
                return txtLoginId.Text;
            }
            set
            {
                txtLoginId.Text = value;
            }
        }

        public string FirstName
        {
            get
            {
                return txtFirstName.Text;
            }
            set
            {
                txtFirstName.Text = value;
            }
        }

        public string LastName
        {
            get
            {
                return txtLastName.Text;
            }
            set
            {
                txtLastName.Text = value;
            }
        }

        public string RegisterNumber
        {
            get
            {
                return txtRegisterNumber.Text;
            }
            set
            {
                txtRegisterNumber.Text = value;
            }
        }

        public string IPPhone
        {
            get
            {
                return txtRegisterNumber.Text;
            }
            set
            {
                txtRegisterNumber.Text = value;
            }
        }

        public int? TeamId
        {
            get
            {
                return (int?)cmbTeam.Value;
            }
            set
            {
                cmbTeam.SelectedItem = cmbTeam.Items.FindByValue(value);
            }
        }

        public bool AllGroupsAccess
        {
            get
            {
                return cbAllGroupsAccess.Checked;
            }
            set
            {
                cbAllGroupsAccess.Checked = value;
            }
        }

        public int AgentTypeId
        {
            get
            {
                return Convert.ToInt32(cmbAgentTypes.Value);
            }
            set
            {
                cmbAgentTypes.SelectedItem = cmbAgentTypes.Items.FindByValue(value);
            }
        }

        public IQueryable<TeamsDto> Teams
        {
            set
            {
                cmbTeam.DataSource = value.ToList();
                cmbTeam.TextField = "TeamAgentName";
                cmbTeam.ValueField = "Id";
                cmbTeam.DataBind();
            }
        }

        public IQueryable<AgentsDto> Agents
        {
            set
            {
                gridviewAgents.DataSource = value.ToList();
                gridviewAgents.DataBind();
            }
        }

        public IQueryable<AgentTypesDto> AgentTypes
        {
            set
            {
                cmbAgentTypes.DataSource = value.ToList();
                cmbAgentTypes.TextField = "Name";
                cmbAgentTypes.ValueField = "Id";
                cmbAgentTypes.DataBind();
            }
        }

        public IQueryable<PagesDto> Pages
        {
            set
            {
                lstboxPagesAgents.DataSource = value.ToList().OrderBy(x => x.Description);
                lstboxPagesAgents.TextField = "Description";
                lstboxPagesAgents.ValueField = "Id";
                lstboxPagesAgents.DataBind();
            }
        }

        public IQueryable<PagesAgentsDto> PagesAgents
        {
            get
            {
                var list = new List<PagesAgentsDto>();

                foreach (ListEditItem item in lstboxPagesAgents.SelectedItems)
                {
                    list.Add(new PagesAgentsDto()
                    {
                        PageId = Convert.ToInt32(item.Value)
                    });
                }

                return list.AsQueryable();
            }
            set
            {
                lstboxPagesAgents.UnselectAll();

                foreach (var item in value)
                {
                    lstboxPagesAgents.Items.FindByValue(item.PageId).Selected = true;
                }
            }
        }

        public AgentsDto Dto
        {
            get
            {
                var dto = new AgentsDto()
                { Id = Id,
                    FirstName = FirstName,
                    LastName = LastName,
                    IPPhone = RegisterNumber,
                    TeamId = TeamId,
                    AgentTypeId = AgentTypeId,
                    LoginId = LoginId,
                    AllGroupsAccess = AllGroupsAccess
                };

                return dto;
            }
        }

        private AgentManagementPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlHelper.SelectMenu(this, "liUser");

            if (presenter == null)
            {
                presenter = new AgentManagementPresenter(this);
            }
            presenter.GetAgentsAllWithResignation();
            presenter.GetTeamsNameValueCollection();
            presenter.GetPages();
            presenter.GetAgentTypesAllByGroup(Convert.ToInt32(UserHelper.UserId));

            if (EntitySelect)
            {
                presenter.GetAgentById(EntityId);
                presenter.GetPagesAgentsByAgentId(Id);
                NewEntryUI();
            }

            if (UserHelper.Type != UserType.Admin)
            {
                btnTransfer.Visible = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            double val;
            if (IPPhone.Length > 6 && double.TryParse(IPPhone, out val) == false)
            {
                JsPopup.Popup(this, MessageType.Warning, MessageHelper.CRUDMessage.IPPhoneValidation("Agent"));
                return;
            }

            if (Id == 0)
            {
                presenter.InsertAgent();
                JsPopup.Popup(this, MessageType.Success, MessageHelper.CRUDMessage.SuccessInsert("Agent"));
            }
            else
            {
                presenter.UpdateAgent();
                JsPopup.Popup(this, MessageType.Success, MessageHelper.CRUDMessage.SuccessUpdate("Agent"));
            }

            presenter.UpdateAgentPages();
            presenter.GetAgentsAll();
        }

        [WebMethod]
        public static void DeleteAgent(int id)
        {
            var presenter =
                new AgentManagementPresenter(HttpContext.Current.Handler as AgentManagement);

            presenter.DeleteAgent(id);
        }

        [WebMethod]
        public static void ResignationAgent(int id)
        {
            var presenter =
                new AgentManagementPresenter(HttpContext.Current.Handler as AgentManagement);

            presenter.ResignationAgent(id);
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

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            var result = presenter.TransferToTeam(UserHelper.UserId, Convert.ToInt32(cmbTeam.SelectedItem.Value), Id);
            if (result)
            {
                JsPopup.Popup(this, MessageType.Success, MessageHelper.CRUDMessage.UserTransferedSuccess("Transfered..."));
            }
            else
            {
                JsPopup.Popup(this, MessageType.Success, MessageHelper.CRUDMessage.UserTransferedUnSuccess("Authorization..."));
            }
        }
    }
}
