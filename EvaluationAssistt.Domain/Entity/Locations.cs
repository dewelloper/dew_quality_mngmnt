namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class Locations : IEntity
    {
        public Locations()
        {
            Groups = new HashSet<Groups>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Groups> Groups { get; set; }
    }
}
