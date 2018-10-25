namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class CategoriesQuestions : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int QuestionId { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Categories Categories { get; set; }
        public virtual Questions Questions { get; set; }
    }
}
