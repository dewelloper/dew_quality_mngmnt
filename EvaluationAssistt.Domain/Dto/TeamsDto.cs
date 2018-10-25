using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Domain.Dto
{
    public class TeamsDto : BaseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public int AgentId { get; set; }

        public string AgentName { get; set; }

        public string TeamAgentName
        {
            get
            {
                return String.Format("{0} - {1}", Name, AgentName);
            }
        }
    }
}
