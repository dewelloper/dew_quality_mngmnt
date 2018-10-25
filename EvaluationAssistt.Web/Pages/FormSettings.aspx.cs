using DevExpress.Web;
using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Domain.Entity;
using EvaluationAssistt.Infrastructure.Enums;
using EvaluationAssistt.Infrastructure.Extensions;
using EvaluationAssistt.Infrastructure.Helpers;
using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Presenter.Presenters;
using EvaluationAssistt.Web.JsHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace EvaluationAssistt.Web.Pages
{
    public partial class FormSettings : EvaluationAssisttPage, IFormSettingsView
    {
        public int FormId
        {
            get
            {
                return Convert.ToInt32(cmbForms.Value);
            }
            set
            {
                cmbForms.SelectedItem = cmbForms.Items.FindByValue(value);
            }
        }
        public int SectionId
        {
            get
            {
                return Convert.ToInt32(cmbSections.Value);
            }
            set
            {
                cmbSections.SelectedItem = cmbSections.Items.FindByValue(value);
            }
        }
        public int CategoryId
        {
            get
            {
                return Convert.ToInt32(cmbCategories.Value);
            }
            set
            {
                cmbCategories.SelectedItem = cmbCategories.Items.FindByValue(value);
            }
        }
        public int QuestionId
        {
            get
            {
                return Convert.ToInt32(cmbQuestions.Value);
            }
            set
            {
                cmbQuestions.SelectedItem = cmbQuestions.Items.FindByValue(value);
            }
        }
        public int AnswerId
        {
            get
            {
                if (lstboxAnswers.SelectedItem != null)
                {
                    return Convert.ToInt32(lstboxAnswers.SelectedItem.Value);
                }
                return 0;
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
        public IQueryable<FormsSectionsDto> Sections
        {
            set
            {
                cmbSections.DataSource = value.ToList();
                cmbSections.TextField = "SectionName";
                cmbSections.ValueField = "SectionId";
                cmbSections.DataBind();
                cmbSections.SelectedItem = null;
            }
        }
        public IQueryable<SectionsCategoriesDto> Categories
        {
            set
            {
                cmbCategories.DataSource = value.ToList();
                cmbCategories.TextField = "CategoryName";
                cmbCategories.ValueField = "CategoryId";
                cmbCategories.DataBind();
                cmbCategories.SelectedItem = null;
            }
        }
        public IQueryable<CategoriesQuestionsDto> Questions
        {
            set
            {
                cmbQuestions.DataSource = value.ToList();
                cmbQuestions.TextField = "QuestionText";
                cmbQuestions.ValueField = "QuestionId";
                cmbQuestions.DataBind();
            }
        }
        public IQueryable<AnswersDto> Answers
        {
            set
            {
                lstboxAnswers.DataSource = value.ToList();
                lstboxAnswers.TextField = "AnswerFormat";
                lstboxAnswers.ValueField = "Id";
                lstboxAnswers.DataBind();
            }
        }
        public IQueryable<ScoreTypesDto> ScoreTypes
        {
            set
            {
                cmbScoreTypesSection.DataSource = value.ToList();
                cmbScoreTypesSection.TextField = "Name";
                cmbScoreTypesSection.ValueField = "Id";
                cmbScoreTypesSection.DataBind();

                cmbScoreTypesCategory.DataSource = value.ToList();
                cmbScoreTypesCategory.TextField = "Name";
                cmbScoreTypesCategory.ValueField = "Id";
                cmbScoreTypesCategory.DataBind();
            }
        }
        public SectionsDto SectionDetails
        {
            set
            {
                SectionId = value.Id;
                lblMinScoreSection.Text = value.MinimumScore.ToString();
                lblMaxScoreSection.Text = value.MaximumScore.ToString();
                cbIsDisabledSection.Checked = value.IsDisabled;
                cmbScoreTypesSection.SelectedItem = cmbScoreTypesSection.Items.FindByValue(value.ScoreTypeId);
            }
        }


        public CategoriesDto CategoryDetails
        {
            set
            {
                CategoryId = value.Id;
                lblMinScoreCategory.Text = value.MinimumScore.ToString();
                lblMaxScoreCategory.Text = value.MaximumScore.ToString();
                cbIsDisabledCategory.Checked = value.IsDisabled;
                cmbScoreTypesCategory.SelectedItem = cmbScoreTypesCategory.Items.FindByValue(value.ScoreTypeId);
            }
        }
        public IQueryable<FormsSectionsDto> SectionsSettingsToLoad
        {
            set
            {
                gridviewSectionSettings.DataSource = value.ToList();
                gridviewSectionSettings.DataBind();
            }
        }
        public IQueryable<SectionsCategoriesDto> CategoriesSettingsToLoad
        {
            set
            {
                gridviewCategorySettings.DataSource = value.ToList();
                gridviewCategorySettings.DataBind();
            }
        }
        public IQueryable<CategoriesQuestionsDto> QuestionsSettingsToLoad
        {
            set
            {
                gridviewQuestionSettings.DataSource = value.ToList();
                gridviewQuestionSettings.DataBind();
            }
        }
        public IQueryable<AnswersSectionsSettingsDto> AnswersSectionsSettings
        {
            get
            {
                var list = new List<AnswersSectionsSettingsDto>();

                for (var i = 0; i < gridviewSectionSettings.VisibleRowCount; i++)
                {
                    var answerId = AnswerId;
                    var sectionId = (int)gridviewSectionSettings.GetRowValues(i, "SectionId");
                    var doesDisable =
                    (gridviewSectionSettings.FindRowCellTemplateControl(i, null, "cbDoesDisable") as CheckBox).Checked;
                    var doesZeroize =
                    (gridviewSectionSettings.FindRowCellTemplateControl(i, null, "cbDoesZeroize") as CheckBox).Checked;

                    if (!doesDisable && !doesZeroize)
                    {
                        continue;
                    }
                    list.Add(new AnswersSectionsSettingsDto()
                        {
                            AnswerId = answerId,
                            SectionId = sectionId,
                            DoesDisable = doesDisable,
                            DoesZeroize = doesZeroize
                        });
                }

                return list.AsQueryable();
            }
            set
            {
                var list = value.ToList();

                for (var i = 0; i < gridviewSectionSettings.VisibleRowCount; i++)
                {
                    var sectionId = (int)gridviewSectionSettings.GetRowValues(i, "SectionId");
                    var answerId = AnswerId;

                    var item =
                        list.Where(x => x.SectionId == sectionId && x.AnswerId == answerId).FirstOrDefault();

                    if (item == null)
                    {
                        continue;
                    }
                    var cbDoesDisable = gridviewSectionSettings.FindRowCellTemplateControl(i, null, "cbDoesDisable") as CheckBox;
                    var cbDoesZeroize = gridviewSectionSettings.FindRowCellTemplateControl(i, null, "cbDoesZeroize") as CheckBox;

                    cbDoesDisable.Checked = item.DoesDisable;
                    cbDoesZeroize.Checked = item.DoesZeroize;
                }
            }
        }
        public IQueryable<AnswersCategoriesSettingsDto> AnswersCategoriesSettings
        {
            get
            {
                var list = new List<AnswersCategoriesSettingsDto>();

                for (var i = 0; i < gridviewCategorySettings.VisibleRowCount; i++)
                {
                    var answerId = AnswerId;
                    var categoryId = (int)gridviewCategorySettings.GetRowValues(i, "CategoryId");
                    var doesDisable =
                    (gridviewCategorySettings.FindRowCellTemplateControl(i, null, "cbDoesDisable") as CheckBox).Checked;
                    var doesZeroize =
                    (gridviewCategorySettings.FindRowCellTemplateControl(i, null, "cbDoesZeroize") as CheckBox).Checked;

                    if (!doesDisable && !doesZeroize)
                    {
                        continue;
                    }
                    list.Add(new AnswersCategoriesSettingsDto()
                    {
                        AnswerId = answerId,
                        CategoryId = categoryId,
                        DoesDisable = doesDisable,
                        DoesZeroize = doesZeroize
                    });
                }

                return list.AsQueryable();
            }
            set
            {
                var list = value.ToList();

                for (var i = 0; i < gridviewCategorySettings.VisibleRowCount; i++)
                {
                    var categoryId = (int)gridviewCategorySettings.GetRowValues(i, "CategoryId");
                    var answerId = AnswerId;

                    var item =
                        list.Where(x => x.CategoryId == categoryId && x.AnswerId == answerId).FirstOrDefault();

                    if (item == null)
                    {
                        continue;
                    }
                    var cbDoesDisable = gridviewCategorySettings.FindRowCellTemplateControl(i, null, "cbDoesDisable") as CheckBox;
                    var cbDoesZeroize = gridviewCategorySettings.FindRowCellTemplateControl(i, null, "cbDoesZeroize") as CheckBox;

                    cbDoesDisable.Checked = item.DoesDisable;
                    cbDoesZeroize.Checked = item.DoesZeroize;
                }
            }
        }
        public IQueryable<AnswersQuestionsSettingsDto> AnswersQuestionsSettings
        {
            get
            {
                var list = new List<AnswersQuestionsSettingsDto>();

                for (var i = 0; i < gridviewQuestionSettings.VisibleRowCount; i++)
                {
                    var answerId = AnswerId;
                    var questionId = (int)gridviewQuestionSettings.GetRowValues(i, "QuestionId");
                    var doesDisable =
                    (gridviewQuestionSettings.FindRowCellTemplateControl(i, null, "cbDoesDisable") as CheckBox).Checked;
                    var doesZeroize =
                    (gridviewQuestionSettings.FindRowCellTemplateControl(i, null, "cbDoesZeroize") as CheckBox).Checked;

                    if (!doesDisable && !doesZeroize)
                    {
                        continue;
                    }
                    list.Add(new AnswersQuestionsSettingsDto()
                    {
                        AnswerId = answerId,
                        QuestionId = questionId,
                        DoesDisable = doesDisable,
                        DoesZeroize = doesDisable
                    });
                }

                return list.AsQueryable();
            }
            set
            {
                var list = value.ToList();

                for (var i = 0; i < gridviewQuestionSettings.VisibleRowCount; i++)
                {
                    var questionId = (int)gridviewQuestionSettings.GetRowValues(i, "CategoryId");
                    var answerId = AnswerId;

                    var item =
                        list.Where(x => x.QuestionId == questionId && x.AnswerId == answerId).FirstOrDefault();

                    if (item == null)
                    {
                        continue;
                    }
                    var cbDoesDisable = gridviewQuestionSettings.FindRowCellTemplateControl(i, null, "cbDoesDisable") as CheckBox;
                    var cbDoesZeroize = gridviewQuestionSettings.FindRowCellTemplateControl(i, null, "cbDoesZeroize") as CheckBox;

                    cbDoesDisable.Checked = item.DoesDisable;
                    cbDoesZeroize.Checked = item.DoesZeroize;
                }
            }
        }
        public IQueryable<ufnFormSettings_Result> FormSettingsList
        {
            set
            {
                gridviewFormSettings.DataSource = value.ToList();
                gridviewFormSettings.DataBind();
            }
        }

        private FormSettingsPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlHelper.SelectMenu(this, "liSettings");

            if (presenter == null)
            {
                presenter = new FormSettingsPresenter(this);
            }
            if (!Page.IsPostBack)
            {
                presenter.GetFormsAll();
            }
            presenter.GetScoreTypesAll();
        }

        protected void cmbForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSection();
            ClearCategory();
            ClearQuestion();
            presenter.GetSectionsByFormId();
            presenter.GetFormSettings();
        }

        protected void cmbSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearCategory();
            presenter.GetSectionDetailsById();
            presenter.GetCategoriesBySectionId();
        }

        protected void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearQuestion();
            presenter.GetCategoryDetailsById();
            presenter.GetQuestionsByCategoryId();
        }

        protected void cmbQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.GetAnswersByQuestionId();
            presenter.GetSectionsForSettings();
            presenter.GetCategoriesForSettings();
            presenter.GetQuestionsForSettings();
        }

        protected void lstboxAnswers_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.GetSectionsForSettings();
            presenter.GetCategoriesForSettings();

            presenter.GetAnswersSectionsSettings();
            presenter.GetAnswersCategoriesSettings();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            presenter.SaveSectionScore(SectionId, Convert.ToInt32(cmbScoreTypesSection.SelectedItem.Value));

            if (AnswerId == 0)
            {
                JsPopup.Popup(this, MessageType.Success, "Form ve bÃ¶lÃ¼me ait Artan - Azalan ayarlarÄ± gÃ¼ncellendi");
                return;
            }

            presenter.SaveAnswersSectionsSettings();
            presenter.SaveAnswersCategoriesSettings();
            presenter.SaveAnswersQuestionSettings();

            JsPopup.Popup(this, MessageType.Success, MessageHelper.CRUDMessage.SuccessUpdate("Soru/Cevap ayarlarÄ±"));
        }

        private void ClearSection()
        {
            ClearCollection(cmbSections.Items);
            pnlSection.Clear();
        }

        private void ClearCategory()
        {
            ClearCollection(cmbCategories.Items);
            pnlCategory.Clear();
        }

        private void ClearQuestion()
        {
            ClearCollection(cmbQuestions.Items);
            ClearCollection(lstboxAnswers.Items);
            pnlQuestion.Clear();
        }

        private void ClearCollection(ListEditItemCollection items)
        {
            while (items.Count > 0)
            {
                items.RemoveAt(0);
            }
        }
    }
}
