namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class AnswersCategoriesSettings : IEntity
    {
        public int Id { get; set; }
        public int AnswerId { get; set; }
        public int CategoryId { get; set; }
        public bool DoesZeroize { get; set; }
        public bool DoesDisable { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Answers Answers { get; set; }
        public virtual Categories Categories { get; set; }
    }
}
