using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Presenters
{
    public class CallManagementPresenter
    {
        private readonly ICallManagementView view;

        private static  AgentsService _agentsService;
        private static CallsService _callsService;
        private static LocationsService _locationsService;
        private static GroupsService _groupsService;
        private static TeamsService _teamsService;

        public CallManagementPresenter(ICallManagementView view)
        {
            this.view = view;

            if (_agentsService == null)
            {
                _agentsService = new AgentsService();
            }
            if (_callsService == null)
            {
                _callsService = new CallsService();
            }
            if (_locationsService == null)
            {
                _locationsService = new LocationsService();
            }
            if (_groupsService == null)
            {
                _groupsService = new GroupsService();
            }
            if (_teamsService == null)
            {
                _teamsService = new TeamsService();
            }
        }

        public void GetCalls(List<int> teamIds, string locName, int groupId, int teamId, int assistantId,
            int numMinDurationP, int numMaxDurationP, string callingPhone, string ucid, int userId, bool CallResultShowTypeId, string scillNo, string loginId)
        {
            var agentId = view.AgentId == 0 ? null : view.AgentId;
            var minDuration = view.MinDuration * 1000;
            var maxDuration = view.MaxDuration * 1000;

            var minDate = view.MinDate.Value;
            var maxDate = view.MaxDate.Value;
            var callingDeviceId = view.CallingDeviceId;
            var remark = view.Remark;

            var result = _callsService.GetCalls(teamIds, agentId, minDuration, maxDuration, minDate, maxDate, callingDeviceId, remark, ucid, locName, groupId, teamId, assistantId,
                numMinDurationP, numMaxDurationP, callingPhone, userId, CallResultShowTypeId, scillNo, loginId);

            view.Calls = result;
        }

        public void GetCallsRandom(DateTime startDate, int randomCallCount)
        {
            var result = _callsService.CallsRandom(startDate, randomCallCount);

            view.CallsRandom = result;
        }

        public void GetCallsByAgentIdForThisMonth()
        {
            var result = _callsService.GetCallsByAgentIdForThisMonth(view.AgentId);
            view.MinDate = (DateTime?)new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            view.MaxDate = (DateTime?)new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), 23, 59, 59);
            view.MinDuration = 1;
            view.MaxDuration = 1800;

            view.Calls = result;
        }

        public void GetInstantNotes()
        {
            var result = _callsService.GetCallsByAgentIdForThisMonth(view.AgentId);
            view.MinDate = (DateTime?)new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            view.MaxDate = (DateTime?)new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), 23, 59, 59);
            view.MinDuration = 1;
            view.MaxDuration = 1800;

            view.Calls = result;
        }

        public void GetLocations()
        {
            var result = _locationsService.GetLocationsNameValueCollection();

            view.Locations = result;

            GetAgents();
        }

        public void GetGroups(int uid)
        {
            var result = _groupsService.GetGroupsByLocationId(view.LocationId, uid);

            view.Groups = result;
        }

        public void GetTeams(int uid)
        {
            var result = _teamsService.GetTeamsByGroupId(view.GroupId, uid);

            view.Teams = result;

            //GetAgents();
        }

        public void GetAgents()
        {
            IQueryable<AgentsDto> result = null;

            if (view.TeamId != 0)
            {
                result = _agentsService.GetAgentsByTeamId(view.TeamId);
            }
            else
            {
                if (view.GroupId != 0)
                {
                    // Commented for stable combox in callmanagement page
                    //result = _agentsService.GetAgentsByGroupId(view.GroupId);
                }
                else
                {
                    if (view.LocationId != 0)
                    {
                        result = _agentsService.GetAgentsByLocationId(view.LocationId);
                    }
                    else
                    {
                        result = null;
                    }
                }
            }
            if (result != null)
            {
                view.Agents = result;
            }
        }

        public void GetAgentsAll()
        {
            var result = _agentsService.GetAgentsNameValueCollection();

            view.Agents = result;
        }

        public string GetFileName(int callId)
        {
            var result = _callsService.GetFileNameById(callId);

            return result;
        }
    }
}
