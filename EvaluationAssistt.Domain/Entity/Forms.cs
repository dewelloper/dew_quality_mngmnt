namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class Forms : IEntity
    {
        public Forms()
        {
            FormsCallsEvaluated = new HashSet<FormsCallsEvaluated>();
            FormsSections = new HashSet<FormsSections>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool RequiresComment { get; set; }
        public short MinimumScore { get; set; }
        public short MaximumScore { get; set; }
        public Nullable<bool> CategoriesBasedScore { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<bool> IsDisabled { get; set; }
        public virtual ICollection<FormsCallsEvaluated> FormsCallsEvaluated { get; set; }
        public virtual ICollection<FormsSections> FormsSections { get; set; }
    }
}
