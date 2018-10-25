
using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Service.Services;

namespace EvaluationAssistt.Presenter.Presenters
{
    public class AgentManagementPresenter
    {
        private readonly IAgentManagementView view;

        private static AgentsService _agentsService;
        private static TeamsService _teamsService;
        private static PagesService _pagesService;

        public AgentManagementPresenter(IAgentManagementView view)
        {
            this.view = view;

            if (_agentsService == null)
            {
                _agentsService = new AgentsService();
            }
            if (_teamsService == null)
            {
                _teamsService = new TeamsService();
            }
            if (_pagesService == null)
            {
                _pagesService = new PagesService();
            }
        }

        public void GetAgentsAll()
        {
            var result = _agentsService.GetAgentsAll();

            view.Agents = result;
        }

        public void GetAgentsAllWithResignation()
        {
            var result = _agentsService.GetAgentsAllWithResignation();

            view.Agents = result;
        }

        public void GetAgentById(int agentId)
        {
            var result = _agentsService.GetAgentById(agentId);

            view.Id = result.Id;
            view.FirstName = result.FirstName;
            view.LastName = result.LastName;
            view.TeamId = result.TeamId;
            view.RegisterNumber = result.RegisterNumber;
            view.IPPhone = result.IPPhone;
            view.LoginId = result.LoginId;
            view.AgentTypeId = result.AgentTypeId;
            view.AllGroupsAccess = result.AllGroupsAccess;
        }

        public void GetTeamsNameValueCollection()
        {
            var result = _teamsService.GetTeamsNameValueCollection();

            view.Teams = result;
        }

        public void InsertAgent()
        {
            var dto = view.Dto;

            var id = _agentsService.InsertAgent(dto);

            view.Id = id;
        }

        public void UpdateAgent()
        {
            var dto = view.Dto;

            _agentsService.UpdateAgent(dto);
        }

        public void DeleteAgent(int id)
        {
            _agentsService.DeleteAgent(id);
        }

        public void ResignationAgent(int id)
        {
            _agentsService.ResignationAgent(id);
        }

        public void GetPages()
        {
            var result = _pagesService.GetPagesNameValueCollection();

            view.Pages = result;
        }

        public void GetPagesAgentsByAgentId(int agentId)
        {
            var result = _pagesService.GetPagesByAgentId(agentId);

            view.PagesAgents = result;
        }

        public void GetAgentTypesAll()
        {
            var result = _agentsService.GetAgentTypesNameValueCollection();

            view.AgentTypes = result;
        }

        public void GetAgentTypesAllByGroup(int userId)
        {
            var result = _agentsService.GetAgentTypesNameValueCollection(userId);

            view.AgentTypes = result;
        }

        public void UpdateAgentPages()
        {
            _pagesService.UpdateAgentPagesByAgentId(view.Id, view.PagesAgents);
        }

        public bool TransferToTeam(int transfererUserId, int teamId, int transferedUserId)
        {
            return _agentsService.TransferToTeam(transfererUserId, teamId, transferedUserId);
        }
    }
}
