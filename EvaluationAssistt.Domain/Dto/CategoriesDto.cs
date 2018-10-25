using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Domain.Dto
{
    public class CategoriesDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDisabled { get; set; }

        public short MaximumScore { get; set; }

        public short MinimumScore { get; set; }

        public int ScoreTypeId { get; set; }

        public string ScoreTypeName { get; set; }

        public List<QuestionsDto> Questions { get; set; }
    }
}
