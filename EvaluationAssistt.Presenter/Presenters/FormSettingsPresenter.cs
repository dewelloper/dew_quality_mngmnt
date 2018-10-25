using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Presenters
{
    public class FormSettingsPresenter
    {
        private readonly IFormSettingsView view;

        private static FormsService _formsService;
        private static SectionsService _sectionsService;
        private static CategoriesService _categoriesService;
        private static ScoreTypesService _scoreTypesService;
        private static QuestionsService _questionService;
        private static AnswersSectionsSettingService _answersSectionsSettingsService;
        private static AnswersCategoriesSettingsService _answersCategoriesSettingsService;
        private static AnswersQuestionsSettingsService _answersQuestionsSettingsService;

        public FormSettingsPresenter(IFormSettingsView view)
        {
            this.view = view;

            if (_formsService == null)
            {
                _formsService = new FormsService();
            }
            if (_sectionsService == null)
            {
                _sectionsService = new SectionsService();
            }
            if (_categoriesService == null)
            {
                _categoriesService = new CategoriesService();
            }
            if (_scoreTypesService == null)
            {
                _scoreTypesService = new ScoreTypesService();
            }
            if (_questionService == null)
            {
                _questionService = new QuestionsService();
            }
            if (_answersSectionsSettingsService == null)
            {
                _answersSectionsSettingsService = new AnswersSectionsSettingService();
            }
            if (_answersCategoriesSettingsService == null)
            {
                _answersCategoriesSettingsService = new AnswersCategoriesSettingsService();
            }
            if (_answersQuestionsSettingsService == null)
            {
                _answersQuestionsSettingsService = new AnswersQuestionsSettingsService();
            }
        }

        public void GetFormsAll()
        {
            var auth = 0;
            if (EvaluationAssistt.Infrastructure.Helpers.UserHelper.Type == Infrastructure.Enums.UserType.QualityExpert || EvaluationAssistt.Infrastructure.Helpers.UserHelper.Type == Infrastructure.Enums.UserType.Admin)
            {
                auth = 1;
            }
            var result = _formsService.GetFormsNameValueCollection(auth);

            view.Forms = result;
        }

        public void GetSectionsByFormId()
        {
            var result = _formsService.GetSectionsByFormId(view.FormId);

            view.Sections = result;
        }

        public void GetCategoriesBySectionId()
        {
            var result = _sectionsService.GetCategoriesBySectionId(view.SectionId);

            view.Categories = result;
        }

        public void GetSectionDetailsById()
        {
            var result = _sectionsService.GetSectionById(view.SectionId);

            view.SectionDetails = result;
        }

        public void GetCategoryDetailsById()
        {
            var result = _categoriesService.GetCategoryById(view.CategoryId);

            view.CategoryDetails = result;
        }

        public void GetScoreTypesAll()
        {
            var result = _scoreTypesService.GetScoreTypesAll();

            view.ScoreTypes = result;
        }

        public void GetQuestionsByCategoryId()
        {
            var result = _categoriesService.GetCategoryQuestionsById(view.CategoryId);

            view.Questions = result;
        }

        public void GetAnswersByQuestionId()
        {
            var result = _questionService.GetAnswersByQuestionId(view.QuestionId);

            view.Answers = result;
        }

        public void GetSectionsForSettings()
        {
            var result = _formsService.GetSectionsByFormId(view.FormId);

            view.SectionsSettingsToLoad = result;
        }

        public void GetCategoriesForSettings()
        {
            var result = _formsService.GetCategoriesByFormId(view.FormId);

            view.CategoriesSettingsToLoad = result;
        }

        public void GetQuestionsForSettings()
        {
            var result = _formsService.GetQuestionsByFormId(view.FormId);

            view.QuestionsSettingsToLoad = result;
        }

        public void GetAnswersSectionsSettings()
        {
            var result = _answersSectionsSettingsService.GetSectionsSettingsByAnswerId(view.AnswerId);

            view.AnswersSectionsSettings = result;
        }

        public void GetAnswersCategoriesSettings()
        {
            var result = _answersCategoriesSettingsService.GetCategoriesSettingsByAnswerId(view.AnswerId);

            view.AnswersCategoriesSettings = result;
        }

        public void SaveAnswersSectionsSettings()
        {
            var dto = view.AnswersSectionsSettings;

            if (dto.Count() > 0)
            {
                _answersSectionsSettingsService.SaveAnswersSectionsSettings(dto);
            }
            else
            {
                _answersSectionsSettingsService.DeleteAnswersSectionsSettings(view.AnswerId);
            }
        }

        public void SaveSectionScore(int secId, int scoreTypeId)
        {
            _sectionsService.SaveSectionscore(secId, scoreTypeId);
        }

        public void SaveAnswersCategoriesSettings()
        {
            var dto = view.AnswersCategoriesSettings;

            if (dto.Count() > 0)
            {
                _answersCategoriesSettingsService.SaveAnswersCategoriesSettings(dto);
            }
            else
            {
                _answersCategoriesSettingsService.DeleteAnswersCategoriesSettings(view.AnswerId);
            }
        }

        public void SaveAnswersQuestionSettings()
        {
            var dto = view.AnswersQuestionsSettings;

            if (dto.Count() > 0)
            {
                _answersQuestionsSettingsService.SaveAnswersQuestionsSettings(dto);
            }
            else
            {
                _answersQuestionsSettingsService.DeleteAnswersQuestionsSettings(view.AnswerId);
            }
        }

        public void GetFormSettings()
        {
            view.FormSettingsList = _formsService.GetFormSettings();
        }
    }
}
