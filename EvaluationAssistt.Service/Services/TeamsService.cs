using EvaluationAssistt.Data.Interface;
using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Domain.Entity;
using EvaluationAssistt.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Service.Services
{
    public class TeamsService
    {
        private static IUnitOfWork _unitOfWork;
        private static IRepository<Teams> _teamsRepository;
        private static IRepository<Agents> _agentsRepository;

        public TeamsService()
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = UnityHelper.Container.Resolve<IUnitOfWork>();
            }
            if (_teamsRepository == null)
            {
                _teamsRepository = _unitOfWork.Teams;
            }
            if (_agentsRepository == null)
            {
                _agentsRepository = _unitOfWork.Agents;
            }
        }

        public IQueryable<TeamsDto> GetTeamsAll()
        {
            var result = _teamsRepository.All("Groups", "Agents")
                            .Select(x => new TeamsDto()
                            {
                                Id = x.Id,
                                Name = x.Name,
                                GroupId = x.GroupId,
                                GroupName = x.Groups.Name,
                                AgentId = x.AgentId,
                                AgentName = x.Agents1.FirstName + " " + x.Agents1.LastName
                            });

            return result.OrderBy(k=> k.AgentName).AsQueryable();
        }

        public IQueryable<TeamsDto> GetTeamsNameValueCollection()
        {
            var query = _teamsRepository.All()
                            .Select(x => new TeamsDto()
                            {
                                Id = x.Id,
                                Name = x.Name,
                                GroupId = x.GroupId,
                                GroupName = x.Groups.Name,
                                AgentId = x.AgentId,
                                AgentName = x.Agents1.FirstName + " " + x.Agents1.LastName
                            });

            return query;
        }

        public TeamsDto GetTeamById(int teamId)
        {
            var team = _teamsRepository.FindById(teamId, "Groups", "Agents");

            var result = new TeamsDto()
            { Id = team.Id,
                Name = team.Name,
                GroupId = team.GroupId,
                GroupName = team.Groups.Name,
                AgentId = team.AgentId,
                AgentName = team.Agents1.FirstName + " " + team.Agents1.LastName
            };

            return result;
        }


        public IQueryable<TeamsDto> GetTeamsByGroupId(int groupId, int uid)
        {
            var agent = _agentsRepository.Find(k => k.Id == uid).FirstOrDefault();
            List<TeamsDto> result = null;
            if (agent != null && agent.TeamId != null)
            {
                result = _teamsRepository.Find(x => x.GroupId == groupId && x.IsDeleted == false)
                .Select(x => new TeamsDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    AgentName = x.Agents1.FirstName + " " + x.Agents1.LastName,
                    AgentId = x.AgentId
                }).ToList();
            }
            else
            {
                result = _teamsRepository.Find(x => x.GroupId == groupId && x.IsDeleted == false)
                                .Select(x => new TeamsDto()
                                {
                                    Id = x.Id,
                                    Name = x.Name,
                                    AgentName = x.Agents1.FirstName + " " + x.Agents1.LastName,
                                    AgentId = x.AgentId
                                }).ToList();
            }

            List<int> aids = result.Select(k => k.AgentId).Distinct().ToList();
            List<int> activeaids = _agentsRepository.Find(k => aids.Contains(k.Id) && k.Resignation == false && k.IsDeleted == false).Select(m => m.Id).ToList();
            return result.Where(k => activeaids.Contains(k.AgentId)).OrderBy(m=> m.AgentName).AsQueryable<TeamsDto>();
        }

        public void InsertTeam(TeamsDto dto)
        {
            var entity = new Teams()
            { Name = dto.Name,
                GroupId = dto.GroupId,
                AgentId = dto.AgentId
            };

            _teamsRepository.Insert(entity);

            _unitOfWork.Save();
        }

        public void UpdateTeam(TeamsDto dto)
        {
            var entity = _teamsRepository.FindById(dto.Id);

            entity.Name = dto.Name;
            entity.GroupId = dto.GroupId;
            entity.AgentId = dto.AgentId;

            _unitOfWork.Save();
        }

        public void DeleteTeam(int id)
        {
            var entity = _teamsRepository.FindById(id);

            _teamsRepository.Delete(entity, true);

            _unitOfWork.Save();
        }
    }
}
