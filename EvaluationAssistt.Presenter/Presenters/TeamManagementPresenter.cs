
using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Presenters
{
    public class TeamManagementPresenter
    {
        private readonly ITeamManagementView view;

        private static TeamsService _teamsService;
        private static GroupsService _groupsService;
        private static AgentsService _agentsService;

        public TeamManagementPresenter(ITeamManagementView view)
        {
            this.view = view;

            if (_teamsService == null)
            {
                _teamsService = new TeamsService();
            }
            if (_groupsService == null)
            {
                _groupsService = new GroupsService();
            }
            if (_agentsService == null)
            {
                _agentsService = new AgentsService();
            }
        }

        public void GetTeamsAll()
        {
            var result = _teamsService.GetTeamsAll();

            view.Teams = result;
        }

        public void GetTeamById(int teamId)
        {
            var result = _teamsService.GetTeamById(teamId);

            view.Id = result.Id;
            view.Name = result.Name;
            view.GroupId = result.GroupId;
            view.AgentId = result.AgentId;
        }

        public void InsertTeam()
        {
            var dto = view.Dto;

            _teamsService.InsertTeam(dto);
        }

        public void UpdateTeam()
        {
            var dto = view.Dto;

            _teamsService.UpdateTeam(dto);
        }

        public void DeleteAgent(int id)
        {
            _teamsService.DeleteTeam(id);
        }

        public void GetGroupsNameValueCollection()
        {
            var result = _groupsService.GetGroupsNameValueCollection();

            view.Groups = result;
        }

        public void GetAgentsNameValueCollection()
        {
            var result = _agentsService.GetTeamLeadersNameValueCollection();

            view.Agents = result;
        }
    }
}
