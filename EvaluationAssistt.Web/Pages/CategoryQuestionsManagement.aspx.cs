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
    public partial class CategoryQuestionsManagement : EvaluationAssisttPage, ICategoryQuestionsManagementView
    {
        public int CategoryId
        {
            get
            {
                return Convert.ToInt32(cmbCategories.Value);
            }
        }

        public IQueryable<CategoriesDto> Categories
        {
            set
            {
                cmbCategories.DataSource = value.ToList();
                cmbCategories.TextField = "Name";
                cmbCategories.ValueField = "Id";
                cmbCategories.DataBind();
            }
        }

        public IQueryable<QuestionsDto> Questions
        {
            set
            {
                lstboxQuestions.DataSource = value.ToList();
                lstboxQuestions.TextField = "QuestionText";
                lstboxQuestions.ValueField = "Id";
                lstboxQuestions.DataBind();
            }
        }

        public IQueryable<CategoriesQuestionsDto> CategoryQuestions
        {
            get
            {
                var categoryQuestions = new List<CategoriesQuestionsDto>();

                var categoryId = Convert.ToInt32(cmbCategories.Value);

                foreach (ListEditItem item in lstboxCategoryQuestions.Items)
                {
                    categoryQuestions.Add(new CategoriesQuestionsDto()
                    {
                        CategoryId = categoryId,
                        QuestionId = Convert.ToInt32(item.Value)
                    });
                }

                return categoryQuestions.AsQueryable();
            }
            set
            {
                lstboxCategoryQuestions.DataSource = value.ToList();
                lstboxCategoryQuestions.TextField = "QuestionText";
                lstboxCategoryQuestions.ValueField = "QuestionId";
                lstboxCategoryQuestions.DataBind();

                foreach (ListEditItem item in lstboxCategoryQuestions.Items)
                {
                    lstboxQuestions.Items.Remove(lstboxQuestions.Items.FindByValue(item.Value));
                }
            }
        }

        private CategoryQuestionsManagementPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (presenter == null)
            {
                presenter = new CategoryQuestionsManagementPresenter(this);
            }
            presenter.GetCategoriesAll();
        }

        protected void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.GetQuestionsAll();

            var categoryId = Convert.ToInt32(cmbCategories.Value);

            presenter.GetCategoryQuestionsByCategoryId(categoryId);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Operation == OperationType.Save)
            {
                presenter.SaveCategoryQuestions();
            }
            else
            {
                if (Operation == OperationType.Delete)
                {
                    presenter.DeleteCategoryQuestions();
                }
            }
            JsPopup.Popup(this, MessageType.Success, MessageHelper.CRUDMessage.SuccessUpdate("Kategori - soru eÅŸleÅŸtirmesi"));
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
                return lstboxCategoryQuestions.Items.Count > 0 ? OperationType.Save : OperationType.Delete;
            }
        }
    }
}
