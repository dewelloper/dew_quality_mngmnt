namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class Flags : IEntity
    {
        public int Id { get; set; }
        public string FlagName { get; set; }
        public int FlagType { get; set; }
        public System.DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
    }
}
