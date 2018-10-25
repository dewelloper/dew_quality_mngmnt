using EvaluationAssistt.Data.Interface;
using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Domain.Entity;
using EvaluationAssistt.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Service.Services
{
    public class SectionsService
    {
        private static IUnitOfWork _unitOfWork;
        private static IRepository<Sections> _sectionsRepository;

        public SectionsService()
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = UnityHelper.Container.Resolve<IUnitOfWork>();
            }
            if (_sectionsRepository == null)
            {
                _sectionsRepository = _unitOfWork.Sections;
            }
        }

        public IQueryable<SectionsDto> GetSectionsAll()
        {
            var result = _sectionsRepository.All()
                            .Select(x => new SectionsDto()
                            {
                                Id = x.Id,
                                Name = x.Name,
                                IsDisabled = x.IsDisabled,
                                MaximumScore = x.MaximumScore,
                                MinimumScore = x.MinimumScore,
                                ScoreTypeId = x.ScoreTypeId,
                                ScoreTypeName = x.ScoreTypes.Name
                            });

            return result;
        }

        public SectionsDto GetSectionById(int id)
        {
            var section = _sectionsRepository.FindById(id);

            var result = new SectionsDto()
            { Id = section.Id,
                Name = section.Name,
                IsDisabled = section.IsDisabled,
                MaximumScore = section.MaximumScore,
                MinimumScore = section.MinimumScore,
                ScoreTypeId = section.ScoreTypeId
            };

            return result;
        }

        public void InsertSection(SectionsDto dto)
        {
            var entity = new Sections()
            { Name = dto.Name,
                IsDisabled = dto.IsDisabled,
                MaximumScore = dto.MaximumScore,
                MinimumScore = dto.MinimumScore,
                ScoreTypeId = dto.ScoreTypeId
            };

            _sectionsRepository.Insert(entity);

            _unitOfWork.Save();
        }

        public void UpdateSection(SectionsDto dto)
        {
            var entity = _sectionsRepository.FindById(dto.Id);

            entity.Name = dto.Name;
            entity.IsDisabled = dto.IsDisabled;
            entity.MaximumScore = dto.MaximumScore;
            entity.MinimumScore = dto.MinimumScore;
            entity.ScoreTypeId = dto.ScoreTypeId;

            _unitOfWork.Save();
        }

        public void SaveSectionscore(int secId, int scoreTypeId)
        {
            var entity = _sectionsRepository.FindById(secId);

            entity.ScoreTypeId = scoreTypeId;

            _unitOfWork.Save();
        }

        public void DeleteSection(int id)
        {
            var entity = _sectionsRepository.FindById(id);

            _sectionsRepository.Delete(entity, true);

            _unitOfWork.Save();
        }

        public IQueryable<SectionsDto> GetSectionsNameValueCollection()
        {
            var result = _sectionsRepository.All()
                          .Select(x => new SectionsDto()
                          {
                              Id = x.Id,
                              Name = x.Name
                          });

            return result;
        }

        public IQueryable<SectionsCategoriesDto> GetSectionCategoriesById(int id)
        {
            var result = _sectionsRepository.FindById(id, "SectionsCategories").SectionsCategories
                            .Select(x => new SectionsCategoriesDto()
                            {
                                Id = x.Id,
                                SectionId = x.SectionId,
                                CategoryId = x.CategoryId,
                                CategoryName = x.Categories.Name
                            }).AsQueryable();

            return result;
        }

        public IQueryable<SectionsCategoriesDto> GetCategoriesBySectionId(int sectionId)
        {
            var result = _sectionsRepository.FindById(sectionId).SectionsCategories
                        .Select(x => new SectionsCategoriesDto()
                        {
                            Id = x.Id,
                            SectionId = x.SectionId,
                            CategoryId = x.CategoryId,
                            CategoryName = x.Categories.Name
                        }).AsQueryable();

            return result;
        }
    }
}
