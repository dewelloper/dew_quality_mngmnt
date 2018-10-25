namespace EvaluationAssistt.Domain.Entity
{
    using System;

    public partial class ufnCallSummaries_Result
    {
        public string AgentName { get; set; }
        public int TotalCall { get; set; }
        public int TotalDuration { get; set; }
    }
}
