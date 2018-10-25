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
    public partial class GroupManagement : EvaluationAssisttPage, IGroupManagementView
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

        public int LocationId
        {
            get
            {
                return Convert.ToInt32(cmbLocation.Value);
            }
            set
            {
                cmbLocation.SelectedItem = cmbLocation.Items.FindByValue(value);
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

        public IQueryable<GroupsDto> Groups
        {
            set
            {
                gridviewGroups.DataSource = value.ToList();
                gridviewGroups.DataBind();
            }
        }

        public IQueryable<LocationsDto> Locations
        {
            set
            {
                cmbLocation.DataSource = value.ToList();
                cmbLocation.TextField = "Name";
                cmbLocation.ValueField = "Id";
                cmbLocation.DataBind();
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

        public GroupsDto Dto
        {
            get
            {
                var dto = new GroupsDto()
                { Id = Id,
                    Name = Name,
                    LocationId = LocationId,
                    AgentId = AgentId
                };

                return dto;
            }
        }

        private GroupManagementPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (presenter == null)
            {
                presenter = new GroupManagementPresenter(this);
            }
            presenter.GetGroupsAll();
            presenter.GetLocationsNameValueCollection();
            presenter.GetAgentsNameValueCollection();

            if (EntitySelect)
            {
                presenter.GetGroupById(EntityId);
                NewEntryUI();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Id == 0)
            {
                presenter.InsertGroup();
                JsPopup.Popup(this, MessageType.Success, MessageHelper.CRUDMessage.SuccessInsert("Grup"));
            }
            else
            {
                presenter.UpdateGroup();
                JsPopup.Popup(this, MessageType.Success, MessageHelper.CRUDMessage.SuccessUpdate("Grup"));
            }

            presenter.GetGroupsAll();
            CancelEntryUI();
        }

        [WebMethod]
        public static void DeleteGroup(int id)
        {
            var presenter =
                new GroupManagementPresenter(HttpContext.Current.Handler as GroupManagement);

            presenter.DeleteGroup(id);
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
