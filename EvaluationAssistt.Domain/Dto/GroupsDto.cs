using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Domain.Dto
{
    public class GroupsDto : BaseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int LocationId { get; set; }

        public string LocationName { get; set; }

        public int AgentId { get; set; }

        public string AgentName { get; set; }

        public string GroupAgentName
        {
            get
            {
                return String.Format("{0} - {1}", Name, AgentName);
            }
        }
    }
}
