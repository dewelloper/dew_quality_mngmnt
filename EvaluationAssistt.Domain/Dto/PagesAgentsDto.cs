using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Domain.Dto
{
    public class PagesAgentsDto
    {
        public int Id { get; set; }

        public int AgentId { get; set; }

        public int PageId { get; set; }

        public string AgentName { get; set; }

        public string PageName { get; set; }

        public string PageDescription { get; set; }

        public bool IsBookmarked { get; set; }
    }
}
