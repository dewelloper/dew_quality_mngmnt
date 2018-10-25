using EvaluationAssistt.Presenter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using EvaluationAssistt.Service.Services;

namespace EvaluationAssistt.Presenter.Presenters
{
    public class SectionManagementPresenter
    {
        private readonly ISectionManagementView view;

        private static SectionsService _sectionsService;
        private static ScoreTypesService _scoreTypesService;

        public SectionManagementPresenter(ISectionManagementView view)
        {
            this.view = view;

            if (_sectionsService == null)
            {
                _sectionsService = new SectionsService();
            }
            if (_scoreTypesService == null)
            {
                _scoreTypesService = new ScoreTypesService();
            }
        }

        public void GetSectionsAll()
        {
            var result = _sectionsService.GetSectionsAll();

            view.Sections = result;
        }

        public void GetSectionById(int id)
        {
            var result = _sectionsService.GetSectionById(id);

            view.Id = result.Id;
            view.Name = result.Name;
            view.IsDisabled = result.IsDisabled;
            view.MaximumScore = result.MaximumScore;
            view.MinimumScore = result.MinimumScore;
            view.ScoreTypeId = result.ScoreTypeId;
        }

        public void InsertSection()
        {
            var dto = view.Dto;

            _sectionsService.InsertSection(dto);
        }

        public void UpdateSection()
        {
            var dto = view.Dto;

            _sectionsService.UpdateSection(dto);
        }

        public void DeleteSection(int id)
        {
            _sectionsService.DeleteSection(id);
        }

        public void GetScoreTypesAll()
        {
            var result = _scoreTypesService.GetScoreTypesAll();

            view.ScoreTypes = result;
        }
    }
}
