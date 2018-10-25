using EvaluationAssistt.Data.Interface;
using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Domain.Entity;
using EvaluationAssistt.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Service.Services
{
    public class CategoriesService
    {
        private static IUnitOfWork _unitOfWork;
        private static IRepository<Categories> _categoriesRepository;

        public CategoriesService()
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = UnityHelper.Container.Resolve<IUnitOfWork>();
            }
            if (_categoriesRepository == null)
            {
                _categoriesRepository = _unitOfWork.Categories;
            }
        }

        public IQueryable<CategoriesDto> GetCategoriesAll()
        {
            var result = _categoriesRepository.All()
                            .Select(x => new CategoriesDto()
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

        public IQueryable<CategoriesDto> GetCategoriesNameValueCollection()
        {
            var result = _categoriesRepository.All()
                         .Select(x => new CategoriesDto()
                         {
                             Id = x.Id,
                             Name = x.Name
                         });

            return result;
        }

        public CategoriesDto GetCategoryById(int id)
        {
            var category = _categoriesRepository.FindById(id);

            var result = new CategoriesDto()
            { Id = category.Id,
                Name = category.Name,
                IsDisabled = category.IsDisabled,
                MaximumScore = category.MaximumScore,
                MinimumScore = category.MinimumScore,
                ScoreTypeId = category.ScoreTypeId
            };

            return result;
        }

        public IQueryable<CategoriesQuestionsDto> GetCategoryQuestionsById(int id)
        {
            var result = _categoriesRepository.FindById(id, "CategoriesQuestions").CategoriesQuestions
                            .Select(x => new CategoriesQuestionsDto()
                            {
                                Id = x.Id,
                                CategoryId = x.CategoryId,
                                QuestionId = x.QuestionId,
                                QuestionText = x.Questions.QuestionText
                            }).AsQueryable();

            return result;
        }

        public void InsertCategory(CategoriesDto dto)
        {
            var entity = new Categories()
            { Id = dto.Id,
                Name = dto.Name,
                IsDisabled = dto.IsDisabled,
                MaximumScore = dto.MaximumScore,
                MinimumScore = dto.MinimumScore,
                ScoreTypeId = dto.ScoreTypeId
            };

            _categoriesRepository.Insert(entity);

            _unitOfWork.Save();
        }

        public void UpdateCategory(CategoriesDto dto)
        {
            var entity = _categoriesRepository.FindById(dto.Id);

            entity.Name = dto.Name;
            entity.IsDisabled = dto.IsDisabled;
            entity.MaximumScore = dto.MaximumScore;
            entity.MinimumScore = dto.MinimumScore;
            entity.ScoreTypeId = dto.ScoreTypeId;

            _unitOfWork.Save();
        }

        public void DeleteCategory(int id)
        {
            var entity = _categoriesRepository.FindById(id);

            _categoriesRepository.Delete(entity, true);

            _unitOfWork.Save();
        }
    }
}
