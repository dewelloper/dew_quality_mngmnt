namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class AgentTypes : IEntity
    {
        public AgentTypes()
        {
            Agents = new HashSet<Agents>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Agents> Agents { get; set; }
    }
}
