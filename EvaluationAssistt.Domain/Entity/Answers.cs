namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class Answers : IEntity
    {
        public Answers()
        {
            AnswersCategoriesSettings = new HashSet<AnswersCategoriesSettings>();
            AnswersQuestionsSettings = new HashSet<AnswersQuestionsSettings>();
            AnswersSectionsSettings = new HashSet<AnswersSectionsSettings>();
            CallsEvaluated = new HashSet<CallsEvaluated>();
        }
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public int QuestionId { get; set; }
        public short Score { get; set; }
        public bool IsDefault { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Questions Questions { get; set; }
        public virtual ICollection<AnswersCategoriesSettings> AnswersCategoriesSettings { get; set; }
        public virtual ICollection<AnswersQuestionsSettings> AnswersQuestionsSettings { get; set; }
        public virtual ICollection<AnswersSectionsSettings> AnswersSectionsSettings { get; set; }
        public virtual ICollection<CallsEvaluated> CallsEvaluated { get; set; }
    }
}
