namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class Pages : IEntity
    {
        public Pages()
        {
            PagesAgents = new HashSet<PagesAgents>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCommon { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<PagesAgents> PagesAgents { get; set; }
    }
}
