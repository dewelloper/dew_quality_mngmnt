using EvaluationAssistt.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Interfaces
{
    public interface ILocationManagementView
    {
        int Id { get; set; }
        string Name { get; set; }

        IQueryable<LocationsDto> Locations { set; }

        LocationsDto Dto { get; }
    }
}
