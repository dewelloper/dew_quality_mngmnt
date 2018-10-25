namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class ScoreTypes : IEntity
    {
        public ScoreTypes()
        {
            Categories = new HashSet<Categories>();
            Sections = new HashSet<Sections>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Categories> Categories { get; set; }
        public virtual ICollection<Sections> Sections { get; set; }
    }
}
