namespace EvaluationAssistt.Domain.Entity
{
    using System;

    public partial class ufnCallEvaluatedSummaries_Result
    {
        public string AgentName { get; set; }
        public Nullable<int> TotalCallsEvaluated { get; set; }
        public double TotalCallsEvaluatedPercentage { get; set; }
    }
}
