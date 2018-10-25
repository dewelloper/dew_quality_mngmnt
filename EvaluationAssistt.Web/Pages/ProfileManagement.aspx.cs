using DevExpress.Web;
using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Infrastructure.Helpers;
using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Presenter.Presenters;
using EvaluationAssistt.Web.JsHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Web.Pages
{
    public partial class ProfileManagement : EvaluationAssisttPage, IProfileManagementView
    {
        public AgentsDto Agent
        {
            set
            {
                txtFirstName.Text = value.FirstName;
                txtLastName.Text = value.LastName;
                txtLoginId.Text = value.LoginId;
                txtRegisterNumber.Text = value.RegisterNumber;
                txtTeamLeaderName.Text = value.TeamLeaderName;
                cmbTeam.SelectedItem = cmbTeam.Items.FindByValue(value.TeamId);
            }
        }

        public IQueryable<Domain.Dto.PagesAgentsDto> Pages
        {
            set
            {
                lstboxPages.DataSource = value.ToList().OrderBy(x => x.PageDescription);
                lstboxPages.TextField = "PageDescription";
                lstboxPages.ValueField = "PageId";
                lstboxPages.DataBind();
            }
        }

        public IQueryable<PagesAgentsDto> PagesBookmarked
        {
            get
            {
                var list = new List<PagesAgentsDto>();

                foreach (ListEditItem item in lstboxBookmarks.Items)
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
                lstboxBookmarks.DataSource = value.ToList().OrderBy(x => x.PageDescription);
                lstboxBookmarks.TextField = "PageDescription";
                lstboxBookmarks.ValueField = "PageId";
                lstboxBookmarks.DataBind();

                foreach (ListEditItem item in lstboxBookmarks.Items)
                {
                    lstboxPages.Items.Remove(lstboxPages.Items.FindByValue(item.Value));
                }
            }
        }

        public IQueryable<TeamsDto> Teams
        {
            set
            {
                cmbTeam.DataSource = value.ToList();
                cmbTeam.TextField = "Name";
                cmbTeam.ValueField = "Id";
                cmbTeam.DataBind();
            }
        }

        private ProfileManagementPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (presenter == null)
            {
                presenter = new ProfileManagementPresenter(this);
            }
            if (Page.IsPostBack)
            {
                return;
            }
            presenter.GetTeamsAll();
            presenter.GetAgentById(UserHelper.UserId);
            presenter.GetPagesByAgentId(UserHelper.UserId);
            presenter.GetPagesBookmarkedByAgentId(UserHelper.UserId);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            presenter.UpdateBookmarkedPages(UserHelper.UserId);

            JsPopup.Popup(this, Infrastructure.Enums.MessageType.Success, MessageHelper.CRUDMessage.SuccessUpdate("Sık kullanılan sayfa ayarları"));
        }
    }
}
