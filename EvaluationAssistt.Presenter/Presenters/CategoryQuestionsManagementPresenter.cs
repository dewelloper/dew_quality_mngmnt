
using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Presenters
{
    public class CategoryQuestionsManagementPresenter
    {
        private readonly ICategoryQuestionsManagementView view;

        private static CategoriesService _categoriesService;
        private static QuestionsService _questionsService;
        private static CategoriesQuestionsService _categoriesQuestionsService;

        public CategoryQuestionsManagementPresenter(ICategoryQuestionsManagementView view)
        {
            this.view = view;

            if (_categoriesService == null)
            {
                _categoriesService = new CategoriesService();
            }
            if (_questionsService == null)
            {
                _questionsService = new QuestionsService();
            }
            if (_categoriesQuestionsService == null)
            {
                _categoriesQuestionsService = new CategoriesQuestionsService();
            }
        }

        public void GetCategoriesAll()
        {
            var result = _categoriesService.GetCategoriesNameValueCollection();

            view.Categories = result;
        }

        public void GetQuestionsAll()
        {
            var result = _questionsService.GetQuestionsNameValueCollection();

            view.Questions = result;
        }

        public void GetCategoryQuestionsByCategoryId(int id)
        {
            var result = _categoriesService.GetCategoryQuestionsById(id);

            view.CategoryQuestions = result;
        }

        public void SaveCategoryQuestions()
        {
            var dto = view.CategoryQuestions;

            _categoriesQuestionsService.InsertCategoriesQuestions(dto);
        }

        public void DeleteCategoryQuestions()
        {
            var categoryId = view.CategoryId;

            _categoriesQuestionsService.DeleteCategoriesQuestions(categoryId);
        }
    }
}
