using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Domain.Dto
{
    public class AgentsDto : BaseDto, IComparable<AgentsDto>
    {
        public int Id { get; set; }

        public string LoginId { get; set; }

        public int AgentTypeId { get; set; }

        public string AgentTypeName { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? TeamId { get; set; }

        public string TeamName { get; set; }

        public string TeamLeaderName { get; set; }

        public int? GroupId { get; set; }

        public string GroupName { get; set; }

        public string LocationName { get; set; }

        public string RegisterNumber { get; set; }

        public string IPPhone { get; set; }

        public bool AllGroupsAccess { get; set; }

        public int? EvaluatedCallCount { get; set; }

        public int ViewCount { get; set; }

        public DateTime? LastViewDate { get; set; }

        public List<int> TeamIdsAssociated { get; set; }

        public bool Resignation { get; set; }

        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }

        public string CallManagementFormat
        {
            get
            {
                return String.Format("{0} {1} - {2}", FirstName, LastName, EvaluatedCallCount);
            }
        }

        public string AgentNameFormat
        {
            get
            {
                return String.Format("{0} {1} - {2}", FirstName, LastName, LoginId);
            }
        }

        public string AgentTeamFormat
        {
            get
            {
                return String.Format("{0} - {1}", TeamName, FullName);
            }
        }

        public int CompareTo(AgentsDto other)
        {
            return String.Compare(FirstName, other.FirstName);
        }
    }
}
