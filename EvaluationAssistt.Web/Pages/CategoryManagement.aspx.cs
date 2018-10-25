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
    public partial class CategoryManagement : EvaluationAssisttPage, ICategoryManagementView
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

        public IQueryable<CategoriesDto> Categories
        {
            set
            {
                gridviewCategories.DataSource = value.ToList();
                gridviewCategories.DataBind();
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

        public CategoriesDto Dto
        {
            get
            {
                var dto = new CategoriesDto()
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

        private CategoryManagementPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (presenter == null)
            {
                presenter = new CategoryManagementPresenter(this);
            }
            presenter.GetCategoriesAll();
            presenter.GetScoreTypesAll();

            if (EntitySelect)
            {
                presenter.GetCategoryById(EntityId);
                NewEntryUI();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Id == 0)
            {
                presenter.InsertCategory();
                JsPopup.Popup(this, MessageType.Success, MessageHelper.CRUDMessage.SuccessInsert("Kategori"));
            }
            else
            {
                presenter.UpdateCategoy();
                JsPopup.Popup(this, MessageType.Success, MessageHelper.CRUDMessage.SuccessUpdate("Kategori"));
            }

            presenter.GetCategoriesAll();
            CancelEntryUI();
        }

        [WebMethod]
        public static void DeleteCategory(int id)
        {
            var presenter =
                new CategoryManagementPresenter(HttpContext.Current.Handler as CategoryManagement);

            presenter.DeleteCategory(id);
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
