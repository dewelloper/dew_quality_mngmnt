using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Domain.Dto
{
    [Serializable]
    public class FlagsDto
    {
        public int Id { get; set; }

        public string FlagName { get; set; }

        public int FlagType { get; set; }
    }
}
