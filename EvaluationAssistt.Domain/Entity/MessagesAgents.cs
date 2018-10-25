namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class MessagesAgents : IEntity
    {
        public int Id { get; set; }
        public int MessageId { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public bool IsRead { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Agents Agents { get; set; }
        public virtual Agents Agents1 { get; set; }
        public virtual Messages Messages { get; set; }
    }
}
