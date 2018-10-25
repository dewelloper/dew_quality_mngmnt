using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Domain.Dto
{
    public class CallsDto
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public int? AgentId { get; set; }

        public string AgentName { get; set; }

        public string LoginID { get; set; }

        public string LocationName { get; set; }

        public string IpPhone { get; set; }

        public DateTime? DateStarted { get; set; }

        public double? Duration { get; set; }

        public string DurationFormat
        {
            get
            {
                var ts = new TimeSpan(0, 0, 0, 0, Convert.ToInt32(Duration));
                return ts.ToString().Split('.')[0];
            }
        }

        public string GloballyUniqueCallLinkageID { get; set; }

        public string DeviceId { get; set; }

        public string AnsweringDeviceId { get; set; }

        public string CallingDeviceId { get; set; }

        public string CalledDeviceId { get; set; }

        public string VdnName { get; set; }

        public string VdnExtension { get; set; }

        public string AcdGroup { get; set; }

        public bool? Marked { get; set; }

        public string IsIncoming { get; set; }
    }
}
