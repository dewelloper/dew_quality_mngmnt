namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class AnswersQuestionsSettings : IEntity
    {
        public int Id { get; set; }
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public bool DoesZeroize { get; set; }
        public bool DoesDisable { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Answers Answers { get; set; }
        public virtual Questions Questions { get; set; }
    }
}
