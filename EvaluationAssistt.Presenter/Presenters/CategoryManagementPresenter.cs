using EvaluationAssistt.Presenter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using EvaluationAssistt.Service.Services;

namespace EvaluationAssistt.Presenter.Presenters
{
    public class CategoryManagementPresenter
    {
        private readonly ICategoryManagementView view;

        private static CategoriesService _categoriesService;
        private static ScoreTypesService _scoreTypesService;

        public CategoryManagementPresenter(ICategoryManagementView view)
        {
            this.view = view;

            if (_categoriesService == null)
            {
                _categoriesService = new CategoriesService();
            }
            if (_scoreTypesService == null)
            {
                _scoreTypesService = new ScoreTypesService();
            }
        }

        public void GetCategoriesAll()
        {
            var result = _categoriesService.GetCategoriesAll();

            view.Categories = result;
        }

        public void GetCategoryById(int id)
        {
            var result = _categoriesService.GetCategoryById(id);

            view.Id = result.Id;
            view.Name = result.Name;
            view.IsDisabled = result.IsDisabled;
            view.MaximumScore = result.MaximumScore;
            view.MinimumScore = result.MinimumScore;
            view.ScoreTypeId = result.ScoreTypeId;
        }

        public void GetScoreTypesAll()
        {
            var result = _scoreTypesService.GetScoreTypesAll();

            view.ScoreTypes = result;
        }

        public void InsertCategory()
        {
            var dto = view.Dto;

            _categoriesService.InsertCategory(dto);
        }

        public void UpdateCategoy()
        {
            var dto = view.Dto;

            _categoriesService.UpdateCategory(dto);
        }

        public void DeleteCategory(int id)
        {
            _categoriesService.DeleteCategory(id);
        }
    }
}
