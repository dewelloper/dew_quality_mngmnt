using EvaluationAssistt.Data.Interface;
using EvaluationAssistt.Domain.Entity;
using EvaluationAssistt.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using EvaluationAssistt.Domain.Dto;

namespace EvaluationAssistt.Service.Services
{
    public class CategoriesQuestionsService
    {
        private static IUnitOfWork _unitOfWork;
        private static IRepository<CategoriesQuestions> _categoriesQuestionsRepository;
        private static IRepository<Questions> _questionsRepository;

        public CategoriesQuestionsService()
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = UnityHelper.Container.Resolve<IUnitOfWork>();
            }
            if (_categoriesQuestionsRepository == null)
            {
                _categoriesQuestionsRepository = _unitOfWork.CategoriesQuestions;
            }
            if (_questionsRepository == null)
            {
                _questionsRepository = _unitOfWork.Questions;
            }
        }

        public void InsertCategoriesQuestions(IQueryable<CategoriesQuestionsDto> collection)
        {
            var categoryId = collection.FirstOrDefault().CategoryId;

            var listToDelete = _categoriesQuestionsRepository
                                                    .Find(x => x.CategoryId == categoryId);

            foreach (var item in listToDelete)
            {
                _categoriesQuestionsRepository.Delete(item, true);
            }


            var list = collection
                                                .Select(x => new CategoriesQuestions()
            { CategoryId = x.CategoryId,
                                                    QuestionId = x.QuestionId
            });

            foreach (var item in list)
            {
                _categoriesQuestionsRepository.Insert(item);
            }

            _unitOfWork.Save();
        }

        public void DeleteCategoriesQuestions(int categoryId)
        {
            var listToDelete =
                _categoriesQuestionsRepository.Find(x => x.CategoryId == categoryId);

            foreach (var item in listToDelete)
            {
                _categoriesQuestionsRepository.Delete(item, true);
            }

            _unitOfWork.Save();
        }

        public IQueryable<QuestionsDto> GetQuestionsByCategoryId(int categoryId)
        {
            var questionIds = _categoriesQuestionsRepository.Find(x => x.CategoryId == categoryId)
                                        .Select(x => x.QuestionId).ToList();

            var result = _questionsRepository.Find(x => questionIds.Contains(x.Id))
                                                .Select(x => new QuestionsDto()
                                                {
                                                    Id = x.Id,
                                                    QuestionText = x.QuestionText,
                                                    HasComment = x.HasComment,
                                                    HasMultipleAnswers = x.HasMultipleAnswers,
                                                    HasVisibleScore = x.HasVisibleScore,
                                                    RequiresComment = x.RequiresComment
                                                });

            return result;
        }
    }
}
