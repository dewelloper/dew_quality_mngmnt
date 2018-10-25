using EvaluationAssistt.Data.Interface;
using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Domain.Entity;
using EvaluationAssistt.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Service.Services
{
    public class QuestionsService
    {
        private static IUnitOfWork _unitOfWork;
        private static IRepository<Questions> _questionsRepository;
        private static IRepository<Answers> _answersRepository;
        private static IRepository<CallsEvaluated> _callsEvaluatedRepository;

        public QuestionsService()
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = UnityHelper.Container.Resolve<IUnitOfWork>();
            }
            if (_questionsRepository == null)
            {
                _questionsRepository = _unitOfWork.Questions;
            }
            if (_answersRepository == null)
            {
                _answersRepository = _unitOfWork.Answers;
            }
            if (_callsEvaluatedRepository == null)
            {
                _callsEvaluatedRepository = _unitOfWork.CallsEvaluated;
            }
        }

        public IQueryable<QuestionsDto> GetQuestionsAll()
        {
            var result = _questionsRepository.All()
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

        public IQueryable<QuestionsDto> GetQuestionsNameValueCollection()
        {
            var result = _questionsRepository.All()
                         .Select(x => new QuestionsDto()
                         {
                             Id = x.Id,
                             QuestionText = x.QuestionText
                         });

            return result;
        }

        public QuestionsDto GetQuestionById(int id)
        {
            var question = _questionsRepository.FindById(id);

            var result = new QuestionsDto()
            { Id = question.Id,
                QuestionText = question.QuestionText,
                HasComment = question.HasComment,
                RequiresComment = question.RequiresComment,
                HasVisibleScore = question.HasVisibleScore,
                HasMultipleAnswers = question.HasMultipleAnswers };

            ICollection<AnswersDto> answers = new List<AnswersDto>();
            foreach (var item in question.Answers)
            {
                answers.Add(new AnswersDto()
                {
                    AnswerText = item.AnswerText,
                    Score = item.Score,
                    IsDefault = item.IsDefault
                });
            }

            result.Answers = answers;

            return result;
        }

        public void InsertQuestions(QuestionsDto dto)
        {
            var entity = new Questions()
            { QuestionText = dto.QuestionText,
                HasComment = dto.HasComment,
                RequiresComment = dto.RequiresComment,
                HasVisibleScore = dto.HasVisibleScore,
                HasMultipleAnswers = dto.HasMultipleAnswers
            };

            var answers = dto.Answers.
                                    Select(x => new Answers()
            { AnswerText = x.AnswerText,
                                          Score = x.Score,
                                          IsDefault = x.IsDefault
            }).ToList();

            entity.Answers = answers;

            _questionsRepository.Insert(entity);

            _unitOfWork.Save();
        }

        public void UpdateQuestions(QuestionsDto dto)
        {
            var entity = _questionsRepository.FindById(dto.Id);

            entity.QuestionText = dto.QuestionText;
            entity.HasComment = dto.HasComment;
            entity.RequiresComment = dto.RequiresComment;
            entity.HasVisibleScore = dto.HasVisibleScore;
            entity.HasMultipleAnswers = dto.HasMultipleAnswers;

            var questionId = entity.Id;
            var answers = dto.Answers.
                                   Select(x => new Answers()
            { AnswerText = x.AnswerText,
                                       Score = x.Score,
                                       IsDefault = x.IsDefault,
                                       QuestionId = questionId
            }).ToList();

            var entityAnsIds = entity.Answers.Select(k => k.Id).ToList();
            var evaluedtedAnsIds = _callsEvaluatedRepository.Find(k => entityAnsIds.Contains(k.AnswerId)).Select(m => m.AnswerId).ToList();
            if (evaluedtedAnsIds != null && evaluedtedAnsIds.Count <= 0)
            {
                _answersRepository.DeleteChildCollection(entity.Answers);
                entity.Answers = answers;
            }
            else
            {
                foreach (Answers ans in entity.Answers)
                {
                    foreach (AnswersDto ansd in dto.Answers)
                    {
                        if (ans.AnswerText == ansd.AnswerText)
                        {
                            ans.Score = ansd.Score;
                            ans.IsDefault = ansd.IsDefault;
                            ans.IsDeleted = ansd.IsDeleted;
                        }
                    }
                }
            }

            _unitOfWork.Save();
        }

        public void DeleteQuestion(int id)
        {
            var entity = _questionsRepository.FindById(id);

            _answersRepository.DeleteChildCollection(entity.Answers);
            _questionsRepository.Delete(entity, true);

            _unitOfWork.Save();
        }

        public IQueryable<AnswersDto> GetAnswersByQuestionId(int id)
        {
            var question = _questionsRepository.FindById(id);

            ICollection<AnswersDto> answers = new List<AnswersDto>();
            foreach (var item in question.Answers)
            {
                answers.Add(new AnswersDto()
                {
                    Id = item.Id,
                    QuestionId = item.QuestionId,
                    AnswerText = item.AnswerText,
                    Score = item.Score
                });
            }

            return answers.AsQueryable();
        }
    }
}
