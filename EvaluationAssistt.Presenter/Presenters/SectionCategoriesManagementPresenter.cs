
using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Presenters
{
    public class SectionCategoriesManagementPresenter
    {
        private readonly ISectionCategoriesManagementView view;

        private static SectionsService _sectionsService;
        private static CategoriesService _categoriesService;
        private static SectionsCategoriesService _sectionsCategoriesService;

        public SectionCategoriesManagementPresenter(ISectionCategoriesManagementView view)
        {
            this.view = view;

            if (_sectionsService == null)
            {
                _sectionsService = new SectionsService();
            }
            if (_categoriesService == null)
            {
                _categoriesService = new CategoriesService();
            }
            if (_sectionsCategoriesService == null)
            {
                _sectionsCategoriesService = new SectionsCategoriesService();
            }
        }

        public void GetSectionsAll()
        {
            var result = _sectionsService.GetSectionsNameValueCollection();

            view.Sections = result;
        }

        public void GetCategoriesAll()
        {
            var result = _categoriesService.GetCategoriesNameValueCollection();

            view.Categories = result;
        }

        public void GetSectionCategoriesBySectionId(int id)
        {
            var result = _sectionsService.GetSectionCategoriesById(id);

            view.SectionCategories = result;
        }

        public void SaveSectionCategories()
        {
            var dto = view.SectionCategories;

            _sectionsCategoriesService.InsertSectionsCategories(dto);
        }

        public void DeleteSectionCategories()
        {
            var sectionId = view.SectionId;

            _sectionsCategoriesService.DeleteSectionsCategories(sectionId);
        }
    }
}
