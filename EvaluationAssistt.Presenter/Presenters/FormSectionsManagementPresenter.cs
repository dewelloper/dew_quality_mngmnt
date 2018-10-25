
using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Presenters
{
    public class FormSectionsManagementPresenter
    {
        private readonly IFormSectionsManagementView view;

        private static FormsService _formsService;
        private static SectionsService _sectionsService;
        private static FormsSectionsService _formsSectionsService;

        public FormSectionsManagementPresenter(IFormSectionsManagementView view)
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
            if (_formsSectionsService == null)
            {
                _formsSectionsService = new FormsSectionsService();
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

        public void GetSectionsAll()
        {
            var result = _sectionsService.GetSectionsNameValueCollection();

            view.Sections = result;
        }

        public void GetFormSectionsByFormId(int id)
        {
            var result = _formsService.GetFormSectionsById(id);

            view.FormSections = result;
        }

        public void SaveFormSections()
        {
            var dto = view.FormSections;

            _formsSectionsService.InsertFormsSections(dto);
        }

        public void DeleteFormSections()
        {
            var formId = view.FormId;

            _formsSectionsService.DeleteFormsSections(formId);
        }
    }
}
