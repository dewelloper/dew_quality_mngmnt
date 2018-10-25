using EvaluationAssistt.Data.Interface;
using EvaluationAssistt.Domain.Entity;
using EvaluationAssistt.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using EvaluationAssistt.Domain.Dto;

namespace EvaluationAssistt.Service.Services
{
    public class ScoreTypesService
    {
        private static IUnitOfWork _unitOfWork;
        private static IRepository<ScoreTypes> _scoreTypesRepository;

        public ScoreTypesService()
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = UnityHelper.Container.Resolve<IUnitOfWork>();
            }
            if (_scoreTypesRepository == null)
            {
                _scoreTypesRepository = _unitOfWork.ScoreTypes;
            }
        }

        public IQueryable<ScoreTypesDto> GetScoreTypesAll()
        {
            var result = _scoreTypesRepository.All()
                            .Select(x => new ScoreTypesDto()
                            {
                                Id = x.Id,
                                Name = x.Name
                            });
            return result;
        }
    }
}
