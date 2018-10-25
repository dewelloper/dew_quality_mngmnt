using System;
using System.Collections.Generic;
using System.Linq;


namespace EvaluationAssistt.Domain.Dto
{
    public class QAnswerPerPercentDto
    {
        public int AgentId { get; set; }
        public string AgentName { get; set; }

        public int FormId { get; set; }
        public string FormNAme { get; set; }

        public string Question { get; set; }
        public int Quantity { get; set; }
        public double Point { get; set; }
        public double Percent { get; set; }

        public int QId { get; set; }
        public int AId { get; set; }

        public int FormScore { get; set; }
        public int AnswerScore { get; set; }
    }
}
