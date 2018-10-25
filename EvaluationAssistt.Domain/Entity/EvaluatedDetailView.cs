namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class EvaluatedDetailView : IEntity
    {
        public int Id { get; set; }
        public int FCEId { get; set; }
        public int FCEFormId { get; set; }
        public int FCECallId { get; set; }
        public int FCEAgentId { get; set; }
        public int FCEScore { get; set; }
        public System.DateTime FCEDate { get; set; }
        public string FCEAgentNote { get; set; }
        public Nullable<bool> FCEAgentSeen { get; set; }
        public bool FCEIsDeleted { get; set; }
        public string FCETLComment { get; set; }
        public string FCEISMComment { get; set; }
        public Nullable<int> FCECallState { get; set; }
        public string FCEFlagId { get; set; }
        public Nullable<int> FCEAgentSees { get; set; }
        public string FCEEvaluationDetailNote { get; set; }
        public string FCEEvaluationResultNote { get; set; }
        public Nullable<int> CEFormCallId { get; set; }
        public Nullable<int> CEQuestionId { get; set; }
        public Nullable<int> CEAnswerId { get; set; }
        public string CEComment { get; set; }
        public Nullable<bool> CEIsDeleted { get; set; }
        public int FCAgentId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
