using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Domain.Dto
{
    [Serializable]
    public class FormsDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool RequiresComment { get; set; }

        public short MinimumScore { get; set; }

        public short MaximumScore { get; set; }

        public bool? CategoriesBasedScore { get; set; }

        public int CategoriesTotalScore { get; set; }

        public bool? IsDisabled { get; set; }
    }
}
