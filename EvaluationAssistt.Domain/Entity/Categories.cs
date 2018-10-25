namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class Categories : IEntity
    {
        public Categories()
        {
            AnswersCategoriesSettings = new HashSet<AnswersCategoriesSettings>();
            CategoriesQuestions = new HashSet<CategoriesQuestions>();
            SectionsCategories = new HashSet<SectionsCategories>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDisabled { get; set; }
        public short MaximumScore { get; set; }
        public short MinimumScore { get; set; }
        public int ScoreTypeId { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<AnswersCategoriesSettings> AnswersCategoriesSettings { get; set; }
        public virtual ScoreTypes ScoreTypes { get; set; }
        public virtual ICollection<CategoriesQuestions> CategoriesQuestions { get; set; }
        public virtual ICollection<SectionsCategories> SectionsCategories { get; set; }
    }
}
