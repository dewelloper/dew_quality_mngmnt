using EvaluationAssistt.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using EvaluationAssistt.Infrastructure.Helpers;
using EvaluationAssistt.Data.Interface;
using EvaluationAssistt.Domain.Entity;

namespace EvaluationAssistt.Service.Services
{
    public class AnswersQuestionsSettingsService
    {
        private static IUnitOfWork _unitOfWork;
        private static IRepository<AnswersQuestionsSettings> _answersQuestionsSettingsRepository;

        public AnswersQuestionsSettingsService()
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = UnityHelper.Container.Resolve<IUnitOfWork>();
            }
            if (_answersQuestionsSettingsRepository == null)
            {
                _answersQuestionsSettingsRepository = _unitOfWork.AnswersQuestionsSettings;
            }
        }

        public void SaveAnswersQuestionsSettings(IQueryable<AnswersQuestionsSettingsDto> dto)
        {
            var answerId = dto.FirstOrDefault().AnswerId;

            var listToDelete
            = _answersQuestionsSettingsRepository.Find(x => x.AnswerId == answerId);

            foreach (var item in listToDelete)
            {
                _answersQuestionsSettingsRepository.Delete(item, true);
            }

            var list =
                dto.Select(x => new AnswersQuestionsSettings()
            { AnswerId = x.AnswerId,
                    QuestionId = x.QuestionId,
                    DoesDisable = x.DoesDisable,
                    DoesZeroize = x.DoesZeroize
            });

            foreach (var item in list)
            {
                _answersQuestionsSettingsRepository.Insert(item);
            }

            _unitOfWork.Save();
        }

        public void DeleteAnswersQuestionsSettings(int answerId)
        {
            var listToDelete =
                _answersQuestionsSettingsRepository.Find(x => x.AnswerId == answerId);

            foreach (var item in listToDelete)
            {
                _answersQuestionsSettingsRepository.Delete(item, true);
            }

            _unitOfWork.Save();
        }

        public List<int> GetQuestionsToToggleByAnswerId(int p)
        {
            return _answersQuestionsSettingsRepository.Find(x => x.AnswerId == p && x.DoesDisable == true).Select(x => x.QuestionId).ToList();
        }
    }
}
