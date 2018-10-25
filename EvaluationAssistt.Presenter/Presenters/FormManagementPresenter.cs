using EvaluationAssistt.Presenter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using EvaluationAssistt.Service.Services;

namespace EvaluationAssistt.Presenter.Presenters
{
    public class FormManagementPresenter
    {
        private readonly IFormManagementView view;

        private static FormsService _formsService;

        public FormManagementPresenter(IFormManagementView view)
        {
            this.view = view;

            if (_formsService == null)
            {
                _formsService = new FormsService();
            }
        }

        public void GetFormsAll()
        {
            var result = _formsService.GetFormsAll();

            view.Forms = result;
        }

        public void GetFormById(int id)
        {
            var result = _formsService.GetFormById(id);

            view.Id = result.Id;
            view.Name = result.Name;
            view.RequiresComment = result.RequiresComment;
            view.MinimumScore = result.MinimumScore;
            view.MaximumScore = result.MaximumScore;
            view.CategoriesBasedScore = result.CategoriesBasedScore;
            view.IsDisabled = result.IsDisabled;
        }

        public void InsertForm()
        {
            var dto = view.Dto;

            _formsService.InsertForm(dto);
        }

        public void UpdateForm()
        {
            var dto = view.Dto;

            _formsService.UpdateForm(dto);
        }

        public void DeleteForm(int id)
        {
            _formsService.DeleteForm(id);
        }
    }
}
