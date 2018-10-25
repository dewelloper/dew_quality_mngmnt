namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class Calls : IEntity
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string LocationName { get; set; }
        public int AgentId { get; set; }
        public string LoginId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IpPhone { get; set; }
        public Nullable<System.DateTime> DateStarted { get; set; }
        public int Duration { get; set; }
        public string GloballyUniqueCallLinkageID { get; set; }
        public string DeviceId { get; set; }
        public string AnsweringDeviceId { get; set; }
        public string CallingDeviceId { get; set; }
        public string CalledDeviceId { get; set; }
        public string VdnName { get; set; }
        public string VdnExtension { get; set; }
        public string Remark { get; set; }
        public string AcdGroup { get; set; }
        public Nullable<bool> Marked { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<int> OnEstablishedEventIx { get; set; }
        public string IsIncoming { get; set; }
    }
}
