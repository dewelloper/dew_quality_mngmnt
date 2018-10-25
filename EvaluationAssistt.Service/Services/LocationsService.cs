using EvaluationAssistt.Data.Interface;
using EvaluationAssistt.Domain.Entity;
using EvaluationAssistt.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using EvaluationAssistt.Domain.Dto;

namespace EvaluationAssistt.Service.Services
{
    public class LocationsService
    {
        private static IUnitOfWork _unitOfWork;
        private static IRepository<Locations> _locationsRepository;

        public LocationsService()
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = UnityHelper.Container.Resolve<IUnitOfWork>();
            }
            if (_locationsRepository == null)
            {
                _locationsRepository = _unitOfWork.Locations;
            }
        }

        public IQueryable<LocationsDto> GetLocationsAll()
        {
            var result = _locationsRepository.All()
                            .Select(x => new LocationsDto()
                            {
                                Id = x.Id,
                                Name = x.Name
                            });

            return result;
        }

        public LocationsDto GetLocationById(int locationId)
        {
            var location = _locationsRepository.FindById(locationId);

            var result = new LocationsDto()
            { Id = location.Id,
                Name = location.Name
            };

            return result;
        }

        public IQueryable<LocationsDto> GetLocationsNameValueCollection()
        {
            var result = _locationsRepository.All()
                           .Select(x => new LocationsDto()
                           {
                               Id = x.Id,
                               Name = x.Name
                           });

            return result;
        }

        public void InsertLocation(LocationsDto dto)
        {
            var entity = new Locations()
            { Name = dto.Name
            };

            _locationsRepository.Insert(entity);

            _unitOfWork.Save();
        }

        public void UpdateLocation(LocationsDto dto)
        {
            var entity = _locationsRepository.FindById(dto.Id);

            entity.Name = dto.Name;

            _unitOfWork.Save();
        }

        public void DeleteLocation(int id)
        {
            var entity = _locationsRepository.FindById(id);

            _locationsRepository.Delete(entity);

            _unitOfWork.Save();
        }
    }
}
