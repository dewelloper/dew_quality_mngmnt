namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class FormsCallsEvaluated : IEntity
    {
        public FormsCallsEvaluated()
        {
            CallsEvaluated = new HashSet<CallsEvaluated>();
        }
        public int Id { get; set; }
        public int FormId { get; set; }
        public int CallId { get; set; }
        public int AgentId { get; set; }
        public int Score { get; set; }
        public System.DateTime Date { get; set; }
        public string AgentNote { get; set; }
        public Nullable<bool> AgentNoteSeen { get; set; }
        public bool IsDeleted { get; set; }
        public string TLComment { get; set; }
        public string ISMComment { get; set; }
        public Nullable<int> CallState { get; set; }
        public string FlagId { get; set; }
        public Nullable<int> AgentSees { get; set; }
        public string EvaluationDetailNote { get; set; }
        public string EvaluationResultNote { get; set; }
        public virtual Agents Agents { get; set; }
        public virtual ICollection<CallsEvaluated> CallsEvaluated { get; set; }
        public virtual CallsRecorded CallsRecorded { get; set; }
        public virtual Forms Forms { get; set; }
    }
}
