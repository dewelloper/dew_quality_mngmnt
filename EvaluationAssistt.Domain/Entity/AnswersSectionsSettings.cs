namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class AnswersSectionsSettings : IEntity
    {
        public int Id { get; set; }
        public int AnswerId { get; set; }
        public int SectionId { get; set; }
        public bool DoesZeroize { get; set; }
        public bool DoesDisable { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Answers Answers { get; set; }
        public virtual Sections Sections { get; set; }
    }
}
