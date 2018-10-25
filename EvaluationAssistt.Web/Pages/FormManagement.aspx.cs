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
    public partial class FormManagement : EvaluationAssisttPage, IFormManagementView
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

        public bool RequiresComment
        {
            get
            {
                return cbRequiresComment.Checked;
            }
            set
            {
                cbRequiresComment.Checked = value;
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

        public bool? CategoriesBasedScore
        {
            get
            {
                return cbCategoriesTotal.Checked;
            }
            set
            {
                cbCategoriesTotal.Checked = value.Value;
            }
        }

        public bool? IsDisabled
        {
            get
            {
                return chkFormAppearnce.Checked;
            }
            set
            {
                chkFormAppearnce.Checked = (value == null || value.Value == null || value == false) ? false : true;
            }
        }

        public IQueryable<Domain.Dto.FormsDto> Forms
        {
            set
            {
                gridviewForms.DataSource = value.ToList();
                gridviewForms.DataBind();
            }
        }

        public FormsDto Dto
        {
            get
            {
                var dto = new FormsDto()
                { Id = Id,
                    Name = Name,
                    RequiresComment = RequiresComment,
                    MinimumScore = MinimumScore,
                    MaximumScore = MaximumScore,
                    CategoriesBasedScore = CategoriesBasedScore,
                    IsDisabled = Convert.ToBoolean(IsDisabled)
                };

                return dto;
            }
        }

        private FormManagementPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlHelper.SelectMenu(this, "liForm");

            if (presenter == null)
            {
                presenter = new FormManagementPresenter(this);
            }
            presenter.GetFormsAll();

            if (EntitySelect)
            {
                presenter.GetFormById(EntityId);
                NewEntryUI();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Id == 0)
            {
                presenter.InsertForm();
                JsPopup.Popup(this, MessageType.Success, MessageHelper.CRUDMessage.SuccessInsert("Form"));
            }
            else
            {
                presenter.UpdateForm();
                JsPopup.Popup(this, MessageType.Success, MessageHelper.CRUDMessage.SuccessUpdate("Form"));
            }

            presenter.GetFormsAll();
            CancelEntryUI();
        }

        [WebMethod]
        public static void DeleteForm(int id)
        {
            var presenter =
                new FormManagementPresenter(HttpContext.Current.Handler as FormManagement);

            presenter.DeleteForm(id);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            NewEntryUI();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            CancelEntryUI();
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
