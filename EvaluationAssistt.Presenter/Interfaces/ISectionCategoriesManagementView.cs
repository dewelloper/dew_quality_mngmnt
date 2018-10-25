using EvaluationAssistt.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Interfaces
{
    public interface ISectionCategoriesManagementView
    {
        int SectionId { get; }

        IQueryable<SectionsDto> Sections { set; }

        IQueryable<CategoriesDto> Categories { set; }

        IQueryable<SectionsCategoriesDto> SectionCategories { get; set; }
    }
}
