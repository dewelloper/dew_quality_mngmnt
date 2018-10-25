using System;
using System.Collections.Generic;
using System.Linq;
using EvaluationAssistt.Domain.Dto;

namespace EvaluationAssistt.Presenter.Interfaces
{
    public interface ICategoryManagementView
    {
        int Id { get; set; }
        string Name { get; set; }
        bool IsDisabled { get; set; }
        short MaximumScore { get; set; }
        short MinimumScore { get; set; }
        int ScoreTypeId { get; set; }

        IQueryable<CategoriesDto> Categories { set; }
        IQueryable<ScoreTypesDto> ScoreTypes { set; }

        CategoriesDto Dto { get; }
    }
}
