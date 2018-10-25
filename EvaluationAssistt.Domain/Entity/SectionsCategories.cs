namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class SectionsCategories : IEntity
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Categories Categories { get; set; }
        public virtual Sections Sections { get; set; }
    }
}
