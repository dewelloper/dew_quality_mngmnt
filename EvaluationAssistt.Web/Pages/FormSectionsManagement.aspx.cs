using DevExpress.Web;
using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Infrastructure.Enums;
using EvaluationAssistt.Infrastructure.Helpers;
using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Presenter.Presenters;
using EvaluationAssistt.Web.JsHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Web.Pages
{
    public partial class FormSectionsManagement : EvaluationAssisttPage, IFormSectionsManagementView
    {
        public int FormId
        {
            get
            {
                return Convert.ToInt32(cmbForms.Value);
            }
        }

        public IQueryable<FormsDto> Forms
        {
            set
            {
                cmbForms.DataSource = value.ToList();
                cmbForms.TextField = "Name";
                cmbForms.ValueField = "Id";
                cmbForms.DataBind();
            }
        }

        public IQueryable<SectionsDto> Sections
        {
            set
            {
                lstboxSections.DataSource = value.ToList();
                lstboxSections.TextField = "Name";
                lstboxSections.ValueField = "Id";
                lstboxSections.DataBind();
            }
        }

        public IQueryable<FormsSectionsDto> FormSections
        {
            get
            {
                var formSections = new List<FormsSectionsDto>();

                var formId = Convert.ToInt32(cmbForms.Value);

                foreach (ListEditItem item in lstboxFormSections.Items)
                {
                    formSections.Add(new FormsSectionsDto()
                    {
                        FormId = formId,
                        SectionId = Convert.ToInt32(item.Value)
                    });
                }

                return formSections.AsQueryable();
            }
            set
            {
                lstboxFormSections.DataSource = value.ToList();
                lstboxFormSections.TextField = "SectionName";
                lstboxFormSections.ValueField = "SectionId";
                lstboxFormSections.DataBind();

                foreach (ListEditItem item in lstboxFormSections.Items)
                {
                    lstboxSections.Items.Remove(lstboxSections.Items.FindByValue(item.Value));
                }
            }
        }

        private FormSectionsManagementPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (presenter == null)
            {
                presenter = new FormSectionsManagementPresenter(this);
            }
            presenter.GetFormsAll();
        }

        protected void cmbForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.GetSectionsAll();

            var formId = Convert.ToInt32(cmbForms.Value);

            presenter.GetFormSectionsByFormId(formId);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Operation == OperationType.Save)
            {
                presenter.SaveFormSections();
            }
            else
            {
                if (Operation == OperationType.Delete)
                {
                    presenter.DeleteFormSections();
                }
            }
            JsPopup.Popup(this, MessageType.Success, MessageHelper.CRUDMessage.SuccessUpdate("Form - bÃ¶lÃ¼m eÅŸleÅŸtirmesi"));
        }

        private enum OperationType
        {
            Delete,
            Save
        }

        private OperationType Operation
        {
            get
            {
                return lstboxFormSections.Items.Count > 0 ? OperationType.Save : OperationType.Delete;
            }
        }
    }
}
