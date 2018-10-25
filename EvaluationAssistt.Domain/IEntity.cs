using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Domain.Entity
{
    public interface IEntity
    {
        int Id { get; set; }

        bool IsDeleted { get; set; }
    }
}
