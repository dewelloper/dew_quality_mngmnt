namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class Messages : IEntity
    {
        public Messages()
        {
            MessagesAgents = new HashSet<MessagesAgents>();
        }
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public System.DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<MessagesAgents> MessagesAgents { get; set; }
    }
}
