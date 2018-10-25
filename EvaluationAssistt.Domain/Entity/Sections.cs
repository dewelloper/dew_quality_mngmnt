namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class Sections : IEntity
    {
        public Sections()
        {
            AnswersSectionsSettings = new HashSet<AnswersSectionsSettings>();
            FormsSections = new HashSet<FormsSections>();
            SectionsCategories = new HashSet<SectionsCategories>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDisabled { get; set; }
        public short MaximumScore { get; set; }
        public short MinimumScore { get; set; }
        public int ScoreTypeId { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<AnswersSectionsSettings> AnswersSectionsSettings { get; set; }
        public virtual ICollection<FormsSections> FormsSections { get; set; }
        public virtual ScoreTypes ScoreTypes { get; set; }
        public virtual ICollection<SectionsCategories> SectionsCategories { get; set; }
    }
}
