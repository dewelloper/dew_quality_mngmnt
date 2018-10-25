namespace EvaluationAssistt.Domain.Entity
{
    using System;

    public partial class ufnCallEvaluatedTeamLeaderSummaries_Result
    {
        public string FormName { get; set; }
        public Nullable<int> TotalCallEvaluated { get; set; }
        public Nullable<double> Percentage { get; set; }
    }
}
