using System;
using System.Collections.Generic;
using System.Linq;
using EvaluationAssistt.Domain.Dto;

namespace EvaluationAssistt.Presenter.Interfaces
{
    public interface IFormManagementView
    {
        int Id { get; set; }
        string Name { get; set; }
        bool RequiresComment { get; set; }
        short MinimumScore { get; set; }
        short MaximumScore { get; set; }
        bool? CategoriesBasedScore { get; set; }
        bool? IsDisabled { get; set; }

        IQueryable<FormsDto> Forms { set; }

        FormsDto Dto { get; }
    }
}
