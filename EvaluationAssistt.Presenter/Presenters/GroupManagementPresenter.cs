using EvaluationAssistt.Presenter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using EvaluationAssistt.Service.Services;

namespace EvaluationAssistt.Presenter.Presenters
{
    public class GroupManagementPresenter
    {
        private readonly IGroupManagementView view;

        private static GroupsService _groupsService;
        private static LocationsService _locationsService;
        private static AgentsService _agentsService;

        public GroupManagementPresenter(IGroupManagementView view)
        {
            this.view = view;

            if (_groupsService == null)
            {
                _groupsService = new GroupsService();
            }
            if (_locationsService == null)
            {
                _locationsService = new LocationsService();
            }
            if (_agentsService == null)
            {
                _agentsService = new AgentsService();
            }
        }

        public void GetGroupsAll()
        {
            var result = _groupsService.GetGroupsAll();

            view.Groups = result;
        }

        public void GetGroupById(int id)
        {
            var result = _groupsService.GetGroupById(id);

            view.Id = result.Id;
            view.Name = result.Name;
            view.LocationId = result.LocationId;
            view.AgentId = result.AgentId;
        }

        public void InsertGroup()
        {
            var dto = view.Dto;

            _groupsService.InsertGroup(dto);
        }

        public void UpdateGroup()
        {
            var dto = view.Dto;

            _groupsService.UpdateGroup(dto);
        }

        public void DeleteGroup(int id)
        {
            _groupsService.DeleteGroup(id);
        }

        public void GetLocationsNameValueCollection()
        {
            var result = _locationsService.GetLocationsNameValueCollection();

            view.Locations = result;
        }

        public void GetAgentsNameValueCollection()
        {
            var result = _agentsService.GetGroupLeadersNameValueCollection();

            view.Agents = result;
        }
    }
}
