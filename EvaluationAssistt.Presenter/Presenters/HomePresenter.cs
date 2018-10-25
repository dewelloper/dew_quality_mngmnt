using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvaluationAssistt.Presenter.Presenters
{
    public class HomePresenter
    {
        private readonly IHomeView view;

        private static CallsService _callsService;
        private static TeamsService _teamsService;
        private static FormsCallsService _formsCallsService;

        public HomePresenter()
        {
            if (_callsService == null)
            {
                _callsService = new CallsService();
            }
            if (_teamsService == null)
            {
                _teamsService = new TeamsService();
            }
            if (_formsCallsService == null)
            {
                _formsCallsService = new FormsCallsService();
            }
        }

        public HomePresenter(IHomeView view)
        {
            this.view = view;

            if (_callsService == null)
            {
                _callsService = new CallsService();
            }
            if (_teamsService == null)
            {
                _teamsService = new TeamsService();
            }
            if (_formsCallsService == null)
            {
                _formsCallsService = new FormsCallsService();
            }
        }

        public void GetCallSummary()
        {
            var result = _callsService.GetCallSummary(view.AgentId, view.DateMin, view.DateMax);

            view.AgentCallCount = result.Item1;
            view.AgentAverageCallDuration = (int)result.Item2;
        }

        public string GetCallSummaryAjax(DateTime dateMin, DateTime dateMax)
        {
            var result = _callsService.GetCallSummary(view.AgentId, dateMin, dateMax);

            return String.Format("{0}-{1}", result.Item1.ToString("n0"), result.Item2.Value.ToString("n0"));
        }

        public void GetCallsEvaluatedLast30Days()
        {
            var result = _formsCallsService.GetCallsEvaluatedByAgentIdLast30Days(view.AgentId);

            view.CallsEvaluatedLast30Days = result;
        }

        public void GetTeamCallSummary()
        {
            var startDate = view.DateTeamLeaderMin;
            var endDate = view.DateTeamLeaderMax;
            if (view.DateTeamLeaderMin.ToString().Contains("0001"))
            {
                startDate = DateTime.Now.AddDays(-1).Date;
                endDate = DateTime.Now;
            }
            var result = _callsService.GetTeamCallSummary(view.TeamId, startDate, endDate);

            view.TeamCallSummaries = result;
        }

        public string GetTeamCallSummaryAjax(DateTime dateMin, DateTime dateMax)
        {
            var result = _callsService.GetTeamCallSummary(view.TeamId, dateMin, dateMax).OrderBy(x => x.AgentName);

            var sb =
                new StringBuilder(String.Format("<tr><td colspan=\"3\" align=\"center\"><span class=\"label\">{0} - {1}</span></td></tr>",
                                dateMin.ToShortDateString(), dateMax.ToShortDateString()) +
                                     "<tr><td align=\"left\"><span class=\"label\"><b>Asistan</b></span></td>" +
                                      "<td align=\"center\"><span class=\"label\"><b>Çağrı Sayısı</b></span></td>" +
                                      "<td align=\"center\"><span class=\"label\"><b>Görüşme Süresi</b></span></td></tr>");

            foreach (var item in result)
            {
                sb.Append(String.Format("<tr><td align=\"left\"><span class=\"label\">{0}</span></td><td align=\"center\"><span class=\"label\">{1}</span></td><td align=\"right\"><span class=\"label\">{2}</span></td></tr>",
                    item.AgentName, item.TotalCall.ToString("n0"), item.TotalDuration.ToString("n0")));
            }

            return sb.ToString();
        }

        public void GetCallsEvaluatedByTeamsAndDate(List<int> teams, DateTime minDate, DateTime maxDate, int evaluatorId)
        {
            var result = _formsCallsService.GetCallsEvaluatedByTeamsAndDate(teams, minDate, maxDate, evaluatorId);

            view.CallsEvaluatedByTeamsAndDate = result;
        }

        public void GetTeamLeaderCallEvaluatedSummary()
        {
            var startDate = view.DateTeamLeaderMin;
            var endDate = view.DateTeamLeaderMax;
            if (view.DateTeamLeaderMin.ToString().Contains("0001"))
            {
                startDate = DateTime.Now.AddDays(-7).Date;
                endDate = DateTime.Now;
            }

            var result = _callsService.GetTeamLeaderCallEvaluatedSummary(view.AgentId, startDate, endDate);

            view.TeamLeaderCallEvaluatedSummaries = result;
        }

        public string GetTeamLeaderCallEvaluatedSummaryAjax(DateTime dateMin, DateTime dateMax)
        {
            var result = _callsService.GetTeamLeaderCallEvaluatedSummary(view.AgentId, dateMin, dateMax).OrderBy(x => x.FormName);

            var sb =
               new StringBuilder(String.Format("<tr><td colspan=\"3\" align=\"center\"><span class=\"label\">{0} - {1}</span></td></tr>",
                               dateMin.ToShortDateString(), dateMax.ToShortDateString()) +
                                    "<tr><td align=\"left\"><span class=\"label\"><b>Form Adı</b></span></td>" +
                                     "<td align=\"center\"><span class=\"label\"><b>Değerlendirme Sayısı</b></span></td>" +
                                     "<td align=\"center\"><span class=\"label\"><b>Ortalama</b></span></td></tr>");

            foreach (var item in result)
            {
                sb.Append(String.Format("<tr><td align=\"left\"><span class=\"label\">{0}</span></td><td align=\"center\"><span class=\"label\">{1}</span></td><td align=\"center\"><span class=\"label\">{2}</span></td></tr>",
                    item.FormName, item.TotalCallEvaluated.Value.ToString("n0"), item.Percentage.Value.ToString("P0")));
            }

            return sb.ToString();
        }

        public void GetCallsEvaluatedWithRemarks(int userTypeId, DateTime startDate, DateTime endDate)
        {
            var evaluationSearchAuthenticationIsLinked = view.EvaluationSearchIsAuthenticated;
            var userId = view.AgentId;
            var result = _formsCallsService.GetCallsEvaluatedWithRemarks(view.TeamId, userTypeId, startDate, endDate, evaluationSearchAuthenticationIsLinked, userId);

            view.CallsEvaluatedWithRemarks = result;
        }

        public void GetGroupCallSummary()
        {
            var result = _callsService.GetGroupCallSummary(view.GroupId, view.DateGroupMin, view.DateGroupMax);

            view.GroupLeaderCallSummaries = result;
        }

        public string GetGroupCallSummaryAjax(DateTime dMin, DateTime dMax)
        {
            var result = _callsService.GetGroupCallSummary(view.GroupId, dMin, dMax);


            var sb =
                 new StringBuilder(String.Format("<tr><td colspan=\"3\" align=\"center\"><span class=\"label\">{0} - {1}</span></td></tr>",
                                 dMin.ToShortDateString(), dMax.ToShortDateString()) +
                                      "<tr><td align=\"left\"><span class=\"label\"><b>Takım</b></span></td>" +
                                          "<td align=\"center\"><span class=\"label\"><b>Çağrı Sayısı</b></span></td>" +
                                          "<td align=\"center\"><span class=\"label\"><b>Görüşme Süresi</b></span></td></tr>");

            foreach (var item in result)
            {
                sb.Append(String.Format("<tr><td align=\"left\"><span class=\"label\"> <a href=\"javascript:void(0)\" onclick=\"javascript:GetTeamCallSummaryFromGroup({3});\">{0}</a></span></td><td align=\"center\"><span class=\"label\">{1}</span></td><td align=\"right\"><span class=\"label\">{2}</span></td></tr>",
                    item.TeamName, item.TotalCall.Value.ToString("n0"), item.TotalDuration.Value.ToString("n0"), item.Id));
            }

            return sb.ToString();
        }

        public string GetTeamCallSummaryAjax(int teamId, DateTime dMin, DateTime dMax)
        {
            var result = _callsService.GetTeamCallSummary(teamId, dMin, dMax).OrderBy(x => x.AgentName);

            var sb =
                new StringBuilder(String.Format("<tr><td colspan=\"3\" align=\"center\"><span class=\"label\">{0} - {1}</span></td></tr>",
                                dMin.ToShortDateString(), dMax.ToShortDateString()) +
                                     "<tr><td align=\"left\"><span class=\"label\"><b>Asistan</b></span></td>" +
                                      "<td align=\"center\"><span class=\"label\"><b>Çağrı Sayısı</b></span></td>" +
                                      "<td align=\"center\"><span class=\"label\"><b>Görüşme Süresi</b></span></td></tr>");

            foreach (var item in result)
            {
                sb.Append(String.Format("<tr><td align=\"left\"><span class=\"label\">{0}</span></td><td align=\"center\"><span class=\"label\">{1}</span></td><td align=\"right\"><span class=\"label\">{2}</span></td></tr>",
                    item.AgentName, item.TotalCall.ToString("n0"), item.TotalDuration.ToString("n0")));
            }

            return sb.ToString();
        }
    }
}
