namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class Questions : IEntity
    {
        public Questions()
        {
            Answers = new HashSet<Answers>();
            AnswersQuestionsSettings = new HashSet<AnswersQuestionsSettings>();
            CallsEvaluated = new HashSet<CallsEvaluated>();
            CategoriesQuestions = new HashSet<CategoriesQuestions>();
        }
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public bool HasComment { get; set; }
        public bool RequiresComment { get; set; }
        public bool HasVisibleScore { get; set; }
        public bool HasMultipleAnswers { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Answers> Answers { get; set; }
        public virtual ICollection<AnswersQuestionsSettings> AnswersQuestionsSettings { get; set; }
        public virtual ICollection<CallsEvaluated> CallsEvaluated { get; set; }
        public virtual ICollection<CategoriesQuestions> CategoriesQuestions { get; set; }
    }
}
