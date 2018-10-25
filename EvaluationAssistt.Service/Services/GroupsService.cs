using EvaluationAssistt.Data.Interface;
using EvaluationAssistt.Domain.Entity;
using EvaluationAssistt.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using EvaluationAssistt.Domain.Dto;

namespace EvaluationAssistt.Service.Services
{
    public class GroupsService
    {
        private static IUnitOfWork _unitOfWork;
        private static IRepository<Groups> _groupsRepository;

        public GroupsService()
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = UnityHelper.Container.Resolve<IUnitOfWork>();
            }
            if (_groupsRepository == null)
            {
                _groupsRepository = _unitOfWork.Groups;
            }
        }

        public IQueryable<GroupsDto> GetGroupsAll()
        {
            var query = _groupsRepository.All("Locations", "Agents")
                            .Select(x => new GroupsDto()
                            {
                                Id = x.Id,
                                Name = x.Name,
                                LocationId = x.LocationId,
                                LocationName = x.Locations.Name,
                                AgentId = x.AgentId,
                                AgentName = x.Agents.FirstName + " " + x.Agents.LastName
                            });

            return query;
        }

        public GroupsDto GetGroupById(int groupId)
        {
            var group = _groupsRepository.FindById(groupId);

            var result = new GroupsDto()
            { Id = group.Id,
                Name = group.Name,
                LocationId = group.LocationId,
                AgentId = group.AgentId };

            return result;
        }

        public IQueryable<GroupsDto> GetGroupsNameValueCollection()
        {
            var query = _groupsRepository.All()
                            .Select(x => new GroupsDto()
                            {
                                Id = x.Id,
                                Name = x.Name,
                                AgentName = x.Agents.FirstName + " " + x.Agents.LastName
                            });

            return query;
        }


        public IQueryable<GroupsDto> GetGroupsByLocationId(int locationId, int uid)
        {
            var result = _groupsRepository.Find(x => x.LocationId == locationId)
                            .Select(x => new GroupsDto()
                            {
                                Id = x.Id,
                                Name = x.Name,
                                AgentName = x.Agents.FirstName + " " + x.Agents.LastName
                            });

            return result;
        }

        public void InsertGroup(GroupsDto dto)
        {
            var entity = new Groups()
            { Name = dto.Name,
                LocationId = dto.LocationId,
                AgentId = dto.AgentId
            };

            _groupsRepository.Insert(entity);

            _unitOfWork.Save();
        }

        public void UpdateGroup(GroupsDto dto)
        {
            var entity = _groupsRepository.FindById(dto.Id);

            entity.Name = dto.Name;
            entity.LocationId = dto.LocationId;
            entity.AgentId = dto.AgentId;

            _unitOfWork.Save();
        }

        public void DeleteGroup(int id)
        {
            var entity = _groupsRepository.FindById(id);

            _groupsRepository.Delete(entity, true);

            _unitOfWork.Save();
        }
    }
}
