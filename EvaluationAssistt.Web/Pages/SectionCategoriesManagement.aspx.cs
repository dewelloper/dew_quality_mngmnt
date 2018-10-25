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
    public partial class SectionCategoriesManagement : EvaluationAssisttPage, ISectionCategoriesManagementView
    {
        public int SectionId
        {
            get
            {
                return Convert.ToInt32(cmbSections.Value);
            }
        }

        public IQueryable<SectionsDto> Sections
        {
            set
            {
                cmbSections.DataSource = value.ToList();
                cmbSections.TextField = "Name";
                cmbSections.ValueField = "Id";
                cmbSections.DataBind();
            }
        }

        public IQueryable<CategoriesDto> Categories
        {
            set
            {
                lstboxCategories.DataSource = value.ToList();
                lstboxCategories.TextField = "Name";
                lstboxCategories.ValueField = "Id";
                lstboxCategories.DataBind();
            }
        }

        public IQueryable<SectionsCategoriesDto> SectionCategories
        {
            get
            {
                var sectionCategories = new List<SectionsCategoriesDto>();

                var sectionId = Convert.ToInt32(cmbSections.Value);

                foreach (ListEditItem item in lstboxSectionCategories.Items)
                {
                    sectionCategories.Add(new SectionsCategoriesDto()
                    {
                        SectionId = sectionId,
                        CategoryId = Convert.ToInt32(item.Value)
                    });
                }

                return sectionCategories.AsQueryable();
            }
            set
            {
                lstboxSectionCategories.DataSource = value.ToList();
                lstboxSectionCategories.TextField = "CategoryName";
                lstboxSectionCategories.ValueField = "CategoryId";
                lstboxSectionCategories.DataBind();

                foreach (ListEditItem item in lstboxSectionCategories.Items)
                {
                    lstboxCategories.Items.Remove(lstboxCategories.Items.FindByValue(item.Value));
                }
            }
        }

        private SectionCategoriesManagementPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (presenter == null)
            {
                presenter = new SectionCategoriesManagementPresenter(this);
            }
            presenter.GetSectionsAll();
        }

        protected void cmbSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.GetCategoriesAll();

            var sectionId = Convert.ToInt32(cmbSections.Value);

            presenter.GetSectionCategoriesBySectionId(sectionId);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Operation == OperationType.Save)
            {
                presenter.SaveSectionCategories();
            }
            else
            {
                if (Operation == OperationType.Delete)
                {
                    presenter.DeleteSectionCategories();
                }
            }
            JsPopup.Popup(this, MessageType.Success, MessageHelper.CRUDMessage.SuccessUpdate("BÃ¶lÃ¼m - kategori eÅŸleÅŸtirmesi"));
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
                return lstboxSectionCategories.Items.Count > 0 ? OperationType.Save : OperationType.Delete;
            }
        }
    }
}
