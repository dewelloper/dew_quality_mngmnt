namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class Teams : IEntity
    {
        public Teams()
        {
            Agents = new HashSet<Agents>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public int AgentId { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Agents> Agents { get; set; }
        public virtual Agents Agents1 { get; set; }
        public virtual Groups Groups { get; set; }
    }
}
