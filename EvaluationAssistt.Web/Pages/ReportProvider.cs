using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Presenter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Web.Pages
{
    public class ReportProvider : IReportingView
    {
        public int Id { get; set; }
        public string LoginId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RegisterNumber { get; set; }
        public int? TeamId { get; set; }
        public int AgentTypeId { get; set; }

        public IQueryable<FormsCallsDto> FormsCalls
        {
            set
            {
            }
            get
            {
                return null;
            }
        }

        public IQueryable<TeamCallsDto> TeamCalls
        {
            set
            {
            }
            get
            {
                return null;
            }
        }

        public IQueryable<CallsOfAgentDto> CallsOfAgents
        {
            set
            {
            }
            get
            {
                return null;
            }
        }

        public IQueryable<AgentsDto> Agents { get; set; }
        public IQueryable<FormsDto> Forms { get; set; }
    }
}
