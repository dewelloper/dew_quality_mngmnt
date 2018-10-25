using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Domain.Dto
{
    [Serializable]
    public class SectionsDto
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public string Name { get; set; }

        public bool IsDisabled { get; set; }

        public short MaximumScore { get; set; }

        public short MinimumScore { get; set; }

        public int ScoreTypeId { get; set; }

        public string ScoreTypeName { get; set; }

        public List<CategoriesDto> Categories { get; set; }
    }
}
