using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Domain.Dto
{
    public class FormsCallsDto
    {
        public int Id { get; set; }

        public int FormID { get; set; }

        public string FormName { get; set; }

        public int CallId { get; set; }

        public DateTime? CallDate { get; set; }

        public int EvaluatorId { get; set; }

        public string EvaluatorName { get; set; }

        public int AgentId { get; set; }

        public string AgentName { get; set; }

        public string CalledNumber { get; set; }

        public DateTime? CalledDate { get; set; }

        public int Score { get; set; }

        public DateTime EvaluationDate { get; set; }

        public string AgentNote { get; set; }

        public bool AgentNoteSeen { get; set; }

        public int? CallState { get; set; }

        public int Duration { get; set; }

        public string IsmComment { get; set; }

        public string TLComment { get; set; }

        public string Note { get; set; }

        public string EvaluationDetailNote { get; set; }
    }
}
