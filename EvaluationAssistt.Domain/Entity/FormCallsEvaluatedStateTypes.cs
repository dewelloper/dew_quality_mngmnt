namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class FormCallsEvaluatedStateTypes
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public Nullable<int> StateValue { get; set; }
    }
}
