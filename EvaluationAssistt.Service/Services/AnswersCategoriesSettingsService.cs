using EvaluationAssistt.Data.Interface;
using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Domain.Entity;
using EvaluationAssistt.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Service.Services
{
    public class AnswersCategoriesSettingsService
    {
        private static IUnitOfWork _unitOfWork;
        private static IRepository<AnswersCategoriesSettings> _answersCategoriesSettingsRepository;

        public AnswersCategoriesSettingsService()
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = UnityHelper.Container.Resolve<IUnitOfWork>();
            }
            if (_answersCategoriesSettingsRepository == null)
            {
                _answersCategoriesSettingsRepository = _unitOfWork.AnswersCategoriesSettings;
            }
        }

        public IQueryable<AnswersCategoriesSettingsDto> GetCategoriesSettingsByAnswerId(int answerId)
        {
            var result = _answersCategoriesSettingsRepository.Find(x => x.AnswerId == answerId)
                            .Select(x => new AnswersCategoriesSettingsDto()
                            {
                                AnswerId = x.AnswerId,
                                CategoryId = x.CategoryId,
                                DoesDisable = x.DoesDisable,
                                DoesZeroize = x.DoesZeroize,
                                CategoryName = x.Categories.Name,
                                AnswerText = x.Answers.AnswerText
                            }).AsQueryable();

            return result;
        }

        public void SaveAnswersCategoriesSettings(IQueryable<AnswersCategoriesSettingsDto> dto)
        {
            var answerId = dto.FirstOrDefault().AnswerId;

            var listToDelete
            = _answersCategoriesSettingsRepository.Find(x => x.AnswerId == answerId);

            foreach (var item in listToDelete)
            {
                _answersCategoriesSettingsRepository.Delete(item, true);
            }

            var list =
                dto.Select(x => new AnswersCategoriesSettings()
            { AnswerId = x.AnswerId,
                    CategoryId = x.CategoryId,
                    DoesDisable = x.DoesDisable,
                    DoesZeroize = x.DoesZeroize
            });

            foreach (var item in list)
            {
                _answersCategoriesSettingsRepository.Insert(item);
            }

            _unitOfWork.Save();
        }

        public void DeleteAnswersCategoriesSettings(int answerId)
        {
            var listToDelete =
                _answersCategoriesSettingsRepository.Find(x => x.AnswerId == answerId);

            foreach (var item in listToDelete)
            {
                _answersCategoriesSettingsRepository.Delete(item, true);
            }

            _unitOfWork.Save();
        }

        public List<int> GetCategoriesToToggleByAnswerId(int p)
        {
            return _answersCategoriesSettingsRepository.Find(x => x.AnswerId == p && x.DoesDisable == true).Select(x => x.CategoryId).ToList();
        }
    }
}
