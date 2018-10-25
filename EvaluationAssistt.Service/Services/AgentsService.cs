using EvaluationAssistt.Data.Interface;
using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Domain.Entity;
using EvaluationAssistt.Infrastructure.Enums;
using EvaluationAssistt.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Service.Services
{
    public class AgentsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private static IRepository<Agents> _agentsRepository;
        private static IRepository<AgentTypes> _agentTypesRepository;
        private static IRepository<Teams> _teamsRepository;
        private static IRepository<Groups> _groupsRepository;
        private static IRepository<FormsCallsEvaluated> _formsCallsEvaluatedRepository;
        private static IRepository<CallsTemporary> _callsRepository;

        public AgentsService()
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = UnityHelper.Container.Resolve<IUnitOfWork>();
            }
            if (_agentsRepository == null)
            {
                _agentsRepository = _unitOfWork.Agents;
            }
            if (_agentTypesRepository == null)
            {
                _agentTypesRepository = _unitOfWork.AgentTypes;
            }
            if (_teamsRepository == null)
            {
                _teamsRepository = _unitOfWork.Teams;
            }
            if (_groupsRepository == null)
            {
                _groupsRepository = _unitOfWork.Groups;
            }
            if (_formsCallsEvaluatedRepository == null)
            {
                _formsCallsEvaluatedRepository = _unitOfWork.FormsCallsEvaluated;
            }
            if (_callsRepository == null)
            {
                _callsRepository = _unitOfWork.Calls;
            }
        }

        public IQueryable<AgentsDto> GetAgentsAll()
        {
            var query = _agentsRepository.Find(k => k.Resignation == false)
                            .Select(x => new AgentsDto()
                            {
                                Id = x.Id,
                                LoginId = x.LoginId,
                                FirstName = x.FirstName,
                                LastName = x.LastName,
                                TeamId = x.TeamId,
                                TeamName = x.Teams.Name,
                                RegisterNumber = x.RegisterNumber,
                                LastViewDate = x.LastViewDate,
                                ViewCount = x.ViewCount,
                                AgentTypeName = x.AgentTypes.Name,
                                GroupName = x.Teams.Groups.Name,
                                LocationName = x.Teams.Groups.Locations.Name,
                                Resignation = x.Resignation,
                                IPPhone = x.IpPhone
                            });

            return query;
        }

        public IQueryable<AgentsDto> GetAgentsAllWithResignation()
        {
            var query = _agentsRepository.All()
                            .Select(x => new AgentsDto()
                            {
                                Id = x.Id,
                                LoginId = x.LoginId,
                                FirstName = x.FirstName,
                                LastName = x.LastName,
                                TeamId = x.TeamId,
                                TeamName = x.Teams.Name,
                                RegisterNumber = x.RegisterNumber,
                                LastViewDate = x.LastViewDate,
                                ViewCount = x.ViewCount,
                                AgentTypeName = x.AgentTypes.Name,
                                GroupName = x.Teams.Groups.Name,
                                LocationName = x.Teams.Groups.Locations.Name,
                                Resignation = x.Resignation,
                                IPPhone = x.IpPhone
                            });

            return query;
        }

        public IQueryable<AgentsDto> GetAgentsAllForCombo()
        {
            var query = _agentsRepository.Find(k => k.Resignation == false)
                            .Select(x => new AgentsDto()
                            {
                                Id = x.Id,
                                LoginId = x.LoginId,
                                FirstName = x.FirstName + " " + x.LastName,
                                LastName = x.LastName,
                                TeamId = x.TeamId,
                                TeamName = x.Teams.Name,
                                RegisterNumber = x.RegisterNumber,
                                LastViewDate = x.LastViewDate,
                                ViewCount = x.ViewCount,
                                AgentTypeName = x.AgentTypes.Name,
                                GroupName = x.Teams.Groups.Name,
                                LocationName = x.Teams.Groups.Locations.Name,
                                IPPhone = x.IpPhone
                            });

            return query.OrderBy(k => k.FirstName).AsQueryable();
        }

        public IQueryable<AgentsDto> GetAgentsNameValueCollection()
        {
            var query = _agentsRepository.Find(x => x.AgentTypeId == (int)UserType.Agent)
                            .Select(x => new AgentsDto()
                            {
                                Id = x.Id,
                                FirstName = x.FirstName,
                                LastName = x.LastName,
                                LoginId = x.LoginId
                            }).OrderBy(x => x.FirstName);

            return query;
        }

        public IQueryable<AgentsDto> GetTeamLeadersNameValueCollection()
        {
            var query = _agentsRepository.Find(x => x.AgentTypeId == (int)UserType.TeamLeader)
                           .Select(x => new AgentsDto()
                           {
                               Id = x.Id,
                               FirstName = x.FirstName,
                               LastName = x.LastName,
                               LoginId = x.LoginId
                           }).OrderBy(x => x.FirstName);

            return query;
        }

        public IQueryable<AgentsDto> GetGroupLeadersNameValueCollection()
        {
            var query = _agentsRepository.Find(x => x.AgentTypeId == (int)UserType.GroupLeader)
                            .Select(x => new AgentsDto()
                            {
                                Id = x.Id,
                                FirstName = x.FirstName,
                                LastName = x.LastName,
                                LoginId = x.LoginId
                            }).OrderBy(x => x.FirstName);

            return query;
        }

        public AgentsDto GetAgentById(int agentId)
        {
            var agent = _agentsRepository.FindById(agentId);

            var result = new AgentsDto()
            { Id = agent.Id,
                LoginId = agent.LoginId,
                FirstName = agent.FirstName,
                LastName = agent.LastName,
                TeamId = agent.TeamId,
                RegisterNumber = agent.RegisterNumber,
                AgentTypeId = agent.AgentTypeId,
                IPPhone = agent.IpPhone
            };

            var teamLeaderName = String.Empty;

            if (agent.TeamId != null)
            {
                var teamLeader = _teamsRepository.Find(x => x.Id == (int)agent.TeamId).FirstOrDefault().Agents1;

                teamLeaderName = teamLeader.FirstName + " " + teamLeader.LastName;
            }
            else
            {
                teamLeaderName = "Takımı bulunmamaktadır";
            }

            result.TeamLeaderName = teamLeaderName;

            return result;
        }

        public int InsertAgent(AgentsDto dto)
        {
            var entity = new Agents()
            { LoginId = dto.LoginId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                RegisterNumber = dto.RegisterNumber,
                IpPhone = dto.IPPhone,
                TeamId = dto.TeamId,
                AgentTypeId = dto.AgentTypeId,
                AllGroupsAccess = dto.AllGroupsAccess
            };

            _agentsRepository.Insert(entity);

            _unitOfWork.Save();

            return entity.Id;
        }

        public void UpdateAgent(AgentsDto dto)
        {
            var entity = _agentsRepository.FindById(dto.Id);

            entity.LoginId = dto.LoginId;
            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;
            entity.RegisterNumber = dto.RegisterNumber;
            entity.TeamId = dto.TeamId;
            entity.AgentTypeId = dto.AgentTypeId;
            entity.AllGroupsAccess = dto.AllGroupsAccess;
            entity.IpPhone = dto.IPPhone;

            _unitOfWork.Save();
        }

        public void DeleteAgent(int id)
        {
            var entity = _agentsRepository.FindById(id);

            entity.Resignation = true;

            _unitOfWork.Save();
        }

        public void ResignationAgent(int id)
        {
            var entity = _agentsRepository.FindById(id);
            if (entity.Resignation != null && Convert.ToBoolean(entity.Resignation))
            {
                entity.Resignation = false;
            }
            else
            {
                entity.Resignation = true;
            }
            _unitOfWork.Save();
        }

        public AgentsDto ValidateUser(string loginId)
        {
            var result = _agentsRepository.Find(x => x.LoginId == loginId && x.Resignation == false)
                  .Select(x => new AgentsDto()
                  {
                      Id = x.Id,
                      LoginId = x.LoginId,
                      AgentTypeId = x.AgentTypeId,
                      AgentTypeName = x.AgentTypes.Name,
                      FirstName = x.FirstName,
                      LastName = x.LastName,
                      RegisterNumber = x.RegisterNumber,
                      TeamId = x.TeamId,
                      TeamName = x.Teams.Name,
                      AllGroupsAccess = x.AllGroupsAccess,
                      IPPhone = x.IpPhone
                  }).FirstOrDefault();

            if (result == null)
            {
                return null;
            }
            switch (result.AgentTypeId)
            {
                case (int)UserType.TeamLeader:
                    result.TeamIdsAssociated = _teamsRepository.Find(x => x.Id == result.TeamId).Select(x => x.Id).ToList();
                    break;

                case (int)UserType.GroupLeader:
                    var group = _groupsRepository.Find(x => x.AgentId == result.Id).FirstOrDefault();
                    if (group != null)
                    {
                        result.GroupId = group.Id;
                        result.GroupName = group.Name;
                        result.TeamIdsAssociated = _teamsRepository.Find(x => x.GroupId == result.GroupId).Select(x => x.Id).ToList();
                    }
                    else
                    {
                        result.TeamIdsAssociated = _teamsRepository.Find(x => x.Id == result.TeamId).Select(x => x.Id).ToList();
                    }
                    break;

                case (int)UserType.QualityExpert:
                    result.TeamIdsAssociated = _teamsRepository.All().Select(x => x.Id).ToList();
                    break;

                case (int)UserType.Admin:
                    result.TeamIdsAssociated = _teamsRepository.All().Select(x => x.Id).ToList();
                    break;
            }

            if (result.AllGroupsAccess)
            {
                result.TeamIdsAssociated = _teamsRepository.All().Select(x => x.Id).ToList();
            }

            return result;
        }

        public int GetUncheckedAgentsCount(List<int> teams)
        {
            return _agentsRepository.Find(x => x.LastViewDate.Value.Month != DateTime.Now.Month
                                            && x.AgentTypeId == (int)UserType.Agent
                                            && teams.Contains((int)x.TeamId))
                                            .Count();
        }

        public IQueryable<AgentsDto> GetUncheckedAgentsName(List<int> teams)
        {
            var result = _agentsRepository.Find(x => (x.LastViewDate.Value.Month != DateTime.Now.Month
                                            && x.AgentTypeId == (int)UserType.Agent
                                            && teams.Contains((int)x.TeamId)) || (x.LastViewDate == null))
                                            .Select(x => new AgentsDto()
                                            {
                                                Id = x.Id,
                                                FirstName = x.FirstName,
                                                LastName = x.LastName
                                            });

            return result;
        }

        public IQueryable<AgentsDto> GetAgentsByTeamId(int teamId)
        {
            var result = _agentsRepository.Find(x => x.Resignation == false && x.TeamId == teamId && x.AgentTypeId == (int)UserType.Agent, "Teams")
                            .Select(x => new AgentsDto()
                            {
                                Id = x.Id,
                                FirstName = x.FirstName,
                                LastName = x.LastName,
                                EvaluatedCallCount = x.EvaluatedCallCount
                            });

            return result;
        }

        public IQueryable<AgentsDto> GetAgentsByGroupId(int groupId)
        {
            var result = _agentsRepository.Find(x => x.Resignation == false && x.Teams.GroupId == groupId && x.AgentTypeId == (int)UserType.Agent, "Teams", "Groups")
                            .Select(x => new AgentsDto()
                            {
                                Id = x.Id,
                                FirstName = x.FirstName,
                                LastName = x.LastName,
                                EvaluatedCallCount = x.EvaluatedCallCount
                            });

            return result;
        }

        public IQueryable<AgentsDto> GetAgentsByLocationId(int locationId)
        {
            var result = _agentsRepository.Find(x => x.Resignation == false && x.Teams.Groups.LocationId == locationId && x.AgentTypeId == (int)UserType.Agent, "Teams", "Groups", "Locations", "FormsCallsEvaluated")
                            .Select(x => new AgentsDto()
                            {
                                Id = x.Id,
                                FirstName = x.FirstName,
                                LastName = x.LastName,
                                EvaluatedCallCount = x.EvaluatedCallCount
                            });

            return result;
        }

        public IQueryable<AgentsDto> GetAgentsByTeamIds(List<int> list)
        {
            var result = _agentsRepository.Find(x => x.Resignation == false && list.Contains(x.Teams.Id) || x.AgentTypeId == (int)UserType.TeamLeader)
                        .Select(x => new AgentsDto()
                        {
                            Id = x.Id,
                            FirstName = x.FirstName,
                            LastName = x.LastName,
                            TeamName = x.Teams.Name
                        });

            return result;
        }

        public IQueryable<AgentTypesDto> GetAgentTypesNameValueCollection()
        {
            var result = _agentTypesRepository.All()
                            .Select(x => new AgentTypesDto()
                            {
                                Id = x.Id,
                                Name = x.Name
                            });

            return result;
        }

        public IQueryable<AgentTypesDto> GetAgentTypesNameValueCollection(int userId)
        {
            var result = _agentTypesRepository.Find(k => k.Id != 1)
                            .Select(x => new AgentTypesDto()
                            {
                                Id = x.Id,
                                Name = x.Name
                            });

            return result;
        }
        public int GetEvaluatedCallCountByAgentId(int agentId)
        {
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;

            return _formsCallsEvaluatedRepository.Find(x => x.Date.Month == month && x.Date.Year == year && x.AgentId == agentId).Count();
        }

        public bool TransferToTeam(int transfererUserId, int teamId, int transferedUserId)
        {
            try
            {
                var agtId = _agentsRepository.Find(k => k.Id == transfererUserId).FirstOrDefault().AgentTypeId;
                if (agtId > 2)
                {
                    return false;
                }
                var targetAgent = _agentsRepository.Find(k => k.Id == transferedUserId).FirstOrDefault();
                targetAgent.TeamId = teamId;
                _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
