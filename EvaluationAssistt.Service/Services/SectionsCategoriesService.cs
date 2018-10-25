using EvaluationAssistt.Data.Interface;
using EvaluationAssistt.Domain.Entity;
using EvaluationAssistt.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using EvaluationAssistt.Domain.Dto;

namespace EvaluationAssistt.Service.Services
{
    public class SectionsCategoriesService
    {
        private static IUnitOfWork _unitOfWork;
        private static IRepository<SectionsCategories> _sectionsCategoriesRepository;
        private static IRepository<Categories> _categoriesRepository;

        public SectionsCategoriesService()
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = UnityHelper.Container.Resolve<IUnitOfWork>();
            }
            if (_sectionsCategoriesRepository == null)
            {
                _sectionsCategoriesRepository = _unitOfWork.SectionsCategories;
            }
            if (_categoriesRepository == null)
            {
                _categoriesRepository = _unitOfWork.Categories;
            }
        }

        public void InsertSectionsCategories(IQueryable<SectionsCategoriesDto> collection)
        {
            var sectionId = collection.FirstOrDefault().SectionId;

            var listToDelete = _sectionsCategoriesRepository
                                                    .Find(x => x.SectionId == sectionId);

            foreach (var item in listToDelete)
            {
                _sectionsCategoriesRepository.Delete(item, true);
            }


            var list = collection
                                                .Select(x => new SectionsCategories()
            { SectionId = x.SectionId,
                                                    CategoryId = x.CategoryId
            });

            foreach (var item in list)
            {
                _sectionsCategoriesRepository.Insert(item);
            }

            _unitOfWork.Save();
        }

        public void DeleteSectionsCategories(int sectionId)
        {
            var listToDelete = _sectionsCategoriesRepository
                                                .Find(x => x.SectionId == sectionId);

            foreach (var item in listToDelete)
            {
                _sectionsCategoriesRepository.Delete(item, true);
            }

            _unitOfWork.Save();
        }

        public IQueryable<CategoriesDto> GetCategoriesBySectionId(int sectionId)
        {
            var categoryIds = _sectionsCategoriesRepository.Find(x => x.SectionId == sectionId)
                                        .Select(x => x.CategoryId).ToList();

            var result = _categoriesRepository.Find(x => categoryIds.Contains(x.Id))
                                                .Select(x => new CategoriesDto()
                                                {
                                                    Id = x.Id,
                                                    Name = x.Name,
                                                    IsDisabled = x.IsDisabled,
                                                    MinimumScore = x.MinimumScore,
                                                    MaximumScore = x.MaximumScore,
                                                    ScoreTypeId = x.ScoreTypeId,
                                                    ScoreTypeName = x.ScoreTypes.Name
                                                });

            return result;
        }
    }
}
