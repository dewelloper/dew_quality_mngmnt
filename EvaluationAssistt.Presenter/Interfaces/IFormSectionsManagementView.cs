using EvaluationAssistt.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Interfaces
{
    public interface IFormSectionsManagementView
    {
        int FormId { get; }

        IQueryable<FormsDto> Forms { set; }

        IQueryable<SectionsDto> Sections { set; }

        IQueryable<FormsSectionsDto> FormSections { get; set; }
    }
}
