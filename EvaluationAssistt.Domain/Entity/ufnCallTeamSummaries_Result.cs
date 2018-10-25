namespace EvaluationAssistt.Domain.Entity
{
    using System;

    public partial class ufnCallTeamSummaries_Result
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public Nullable<int> TotalCall { get; set; }
        public Nullable<long> TotalDuration { get; set; }
    }
}
