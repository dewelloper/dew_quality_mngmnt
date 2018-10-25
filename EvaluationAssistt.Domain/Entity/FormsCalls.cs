namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class FormsCalls : IEntity
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public string FormName { get; set; }
        public Nullable<System.DateTime> DateStarted { get; set; }
        public int CallId { get; set; }
        public int EvaluatorId { get; set; }
        public string EvaluatorFirstName { get; set; }
        public string EvaluatorLastName { get; set; }
        public int AgentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<int> TeamId { get; set; }
        public int Score { get; set; }
        public System.DateTime Date { get; set; }
        public string AgentNote { get; set; }
        public Nullable<bool> AgentNoteSeen { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<int> CallState { get; set; }
        public string TLComment { get; set; }
        public string ISMComment { get; set; }
        public string EvaluationDetailNote { get; set; }
        public Nullable<int> AgentSees { get; set; }
        public int Duration { get; set; }
    }
}
