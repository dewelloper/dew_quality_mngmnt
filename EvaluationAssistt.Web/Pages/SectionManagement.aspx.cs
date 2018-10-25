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
    public partial class SectionManagement : EvaluationAssisttPage, ISectionManagementView
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

        public bool IsDisabled
        {
            get
            {
                return cbIsDisabled.Checked;
            }
            set
            {
                cbIsDisabled.Checked = value;
            }
        }

        public short MaximumScore
        {
            get
            {
                return Convert.ToInt16(numMaxScore.Value);
            }
            set
            {
                numMaxScore.Value = value;
            }
        }

        public short MinimumScore
        {
            get
            {
                return Convert.ToInt16(numMinScore.Value);
            }
            set
            {
                numMinScore.Value = value;
            }
        }

        public int ScoreTypeId
        {
            get
            {
                return Convert.ToInt32(cmbScoreType.Value);
            }
            set
            {
                cmbScoreType.SelectedItem = cmbScoreType.Items.FindByValue(value);
            }
        }

        public IQueryable<SectionsDto> Sections
        {
            set
            {
                gridviewSections.DataSource = value.ToList();
                gridviewSections.DataBind();
            }
        }

        public IQueryable<ScoreTypesDto> ScoreTypes
        {
            set
            {
                cmbScoreType.DataSource = value.ToList();
                cmbScoreType.TextField = "Name";
                cmbScoreType.ValueField = "Id";
                cmbScoreType.DataBind();
            }
        }

        public SectionsDto Dto
        {
            get
            {
                var dto = new SectionsDto()
                { Id = Id,
                    Name = Name,
                    IsDisabled = IsDisabled,
                    MaximumScore = MaximumScore,
                    MinimumScore = MinimumScore,
                    ScoreTypeId = ScoreTypeId
                };

                return dto;
            }
        }

        private SectionManagementPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (presenter == null)
            {
                presenter = new SectionManagementPresenter(this);
            }
            presenter.GetSectionsAll();
            presenter.GetScoreTypesAll();

            if (EntitySelect)
            {
                presenter.GetSectionById(EntityId);
                NewEntryUI();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Id == 0)
            {
                presenter.InsertSection();
                JsPopup.Popup(this, MessageType.Success, MessageHelper.CRUDMessage.SuccessInsert("BÃ¶lÃ¼m"));
            }
            else
            {
                presenter.UpdateSection();
                JsPopup.Popup(this, MessageType.Success, MessageHelper.CRUDMessage.SuccessUpdate("BÃ¶lÃ¼m"));
            }

            presenter.GetSectionsAll();
            CancelEntryUI();
        }

        [WebMethod]
        public static void DeleteSection(int id)
        {
            var presenter =
                new SectionManagementPresenter(HttpContext.Current.Handler as SectionManagement);

            presenter.DeleteSection(id);
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
