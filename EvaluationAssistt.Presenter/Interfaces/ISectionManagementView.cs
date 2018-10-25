using System;
using System.Collections.Generic;
using System.Linq;
using EvaluationAssistt.Domain.Dto;

namespace EvaluationAssistt.Presenter.Interfaces
{
    public interface ISectionManagementView
    {
        int Id { get; set; }
        string Name { get; set; }
        bool IsDisabled { get; set; }
        short MaximumScore { get; set; }
        short MinimumScore { get; set; }
        int ScoreTypeId { get; set; }

        IQueryable<SectionsDto> Sections { set; }
        IQueryable<ScoreTypesDto> ScoreTypes { set; }

        SectionsDto Dto { get; }
    }
}
