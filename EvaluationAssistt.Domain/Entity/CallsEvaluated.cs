namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class CallsEvaluated : IEntity
    {
        public int Id { get; set; }
        public int FormCallId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public string Comment { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Answers Answers { get; set; }
        public virtual FormsCallsEvaluated FormsCallsEvaluated { get; set; }
        public virtual Questions Questions { get; set; }
    }
}
