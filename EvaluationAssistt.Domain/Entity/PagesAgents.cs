namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class PagesAgents : IEntity
    {
        public int Id { get; set; }
        public int AgentId { get; set; }
        public int PageId { get; set; }
        public bool IsBookmarked { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Agents Agents { get; set; }
        public virtual Pages Pages { get; set; }
    }
}
