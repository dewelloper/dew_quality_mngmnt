namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class Agents : IEntity
    {
        public Agents()
        {
            FormsCallsEvaluated = new HashSet<FormsCallsEvaluated>();
            Groups = new HashSet<Groups>();
            MessagesAgents = new HashSet<MessagesAgents>();
            MessagesAgents1 = new HashSet<MessagesAgents>();
            PagesAgents = new HashSet<PagesAgents>();
            Teams1 = new HashSet<Teams>();
        }
        public int Id { get; set; }
        public int AgentTypeId { get; set; }
        public string LoginId { get; set; }
        public string IpPhone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<int> TeamId { get; set; }
        public string RegisterNumber { get; set; }
        public bool AllGroupsAccess { get; set; }
        public int ViewCount { get; set; }
        public Nullable<System.DateTime> LastViewDate { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<int> EvaluatedCallCount { get; set; }
        public bool Resignation { get; set; }
        public virtual AgentTypes AgentTypes { get; set; }
        public virtual Teams Teams { get; set; }
        public virtual ICollection<FormsCallsEvaluated> FormsCallsEvaluated { get; set; }
        public virtual ICollection<Groups> Groups { get; set; }
        public virtual ICollection<MessagesAgents> MessagesAgents { get; set; }
        public virtual ICollection<MessagesAgents> MessagesAgents1 { get; set; }
        public virtual ICollection<PagesAgents> PagesAgents { get; set; }
        public virtual ICollection<Teams> Teams1 { get; set; }
    }
}
