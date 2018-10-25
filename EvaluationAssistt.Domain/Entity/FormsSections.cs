namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class FormsSections : IEntity
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public int SectionId { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<bool> IsDisabled { get; set; }
        public virtual Forms Forms { get; set; }
        public virtual Sections Sections { get; set; }
    }
}
