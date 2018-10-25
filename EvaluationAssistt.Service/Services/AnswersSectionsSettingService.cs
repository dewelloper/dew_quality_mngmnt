using EvaluationAssistt.Data.Interface;
using EvaluationAssistt.Domain.Entity;
using EvaluationAssistt.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using EvaluationAssistt.Domain.Dto;

namespace EvaluationAssistt.Service.Services
{
    public class AnswersSectionsSettingService
    {
        private static IUnitOfWork _unitOfWork;
        private static IRepository<AnswersSectionsSettings> _answersSectionsSettingsRepository;

        public AnswersSectionsSettingService()
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = UnityHelper.Container.Resolve<IUnitOfWork>();
            }
            if (_answersSectionsSettingsRepository == null)
            {
                _answersSectionsSettingsRepository = _unitOfWork.AnswersSectionsSettings;
            }
        }

        public IQueryable<AnswersSectionsSettingsDto> GetSectionsSettingsByAnswerId(int answerId)
        {
            var result = _answersSectionsSettingsRepository.Find(x => x.AnswerId == answerId)
                            .Select(x => new AnswersSectionsSettingsDto()
                            {
                                AnswerId = x.AnswerId,
                                SectionId = x.SectionId,
                                DoesDisable = x.DoesDisable,
                                DoesZeroize = x.DoesZeroize,
                                SectionName = x.Sections.Name,
                                AnswerText = x.Answers.AnswerText
                            }).AsQueryable();

            return result;
        }

        public void SaveAnswersSectionsSettings(IQueryable<AnswersSectionsSettingsDto> dto)
        {
            var answerId = dto.FirstOrDefault().AnswerId;

            var listToDelete =
                _answersSectionsSettingsRepository.Find(x => x.AnswerId == answerId);

            foreach (var item in listToDelete)
            {
                _answersSectionsSettingsRepository.Delete(item, true);
            }

            var list =
                dto.Select(x => new AnswersSectionsSettings()
            { AnswerId = x.AnswerId,
                    SectionId = x.SectionId,
                    DoesDisable = x.DoesDisable,
                    DoesZeroize = x.DoesZeroize
            });

            foreach (var item in list)
            {
                _answersSectionsSettingsRepository.Insert(item);
            }

            _unitOfWork.Save();
        }

        public void DeleteAnswersSectionsSettings(int answerId)
        {
            var listToDelete
            = _answersSectionsSettingsRepository.Find(x => x.AnswerId == answerId);

            foreach (var item in listToDelete)
            {
                _answersSectionsSettingsRepository.Delete(item, true);
            }

            _unitOfWork.Save();
        }

        public List<int> GetSectionsToToggleByAnswerId(int p)
        {
            return _answersSectionsSettingsRepository.Find(x => x.AnswerId == p && x.DoesDisable == true).Select(x => x.SectionId).ToList();
        }
    }
}
