namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class Groups : IEntity
    {
        public Groups()
        {
            Teams = new HashSet<Teams>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public int AgentId { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Agents Agents { get; set; }
        public virtual Locations Locations { get; set; }
        public virtual ICollection<Teams> Teams { get; set; }
    }
}
