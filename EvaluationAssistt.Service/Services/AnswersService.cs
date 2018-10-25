using EvaluationAssistt.Data.Interface;
using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Domain.Entity;
using EvaluationAssistt.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Service.Services
{
    public class AnswersService
    {
        private static IUnitOfWork _unitOfWork;
        private static IRepository<Answers> _answersRepository;
        private static IRepository<AnswersCategoriesSettings> _answersCategoriesRepository;
        private static IRepository<AnswersSectionsSettings> _answersSectionsRepository;
        private static IRepository<Questions> _questionsRepository;
        private static IRepository<CategoriesQuestions> _categoryQuestionsRepository;
        private static IRepository<SectionsCategories> _sectionsCategoriesRepository;
        private static IRepository<FormsSections> _formSectionsRepository;
        private static IRepository<Sections> _sectionsRepository;

        public AnswersService()
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = UnityHelper.Container.Resolve<IUnitOfWork>();
            }
            if (_answersRepository == null)
            {
                _answersRepository = _unitOfWork.Answers;
            }
            if (_answersCategoriesRepository == null)
            {
                _answersCategoriesRepository = _unitOfWork.AnswersCategoriesSettings;
            }
            if (_answersSectionsRepository == null)
            {
                _answersSectionsRepository = _unitOfWork.AnswersSectionsSettings;
            }
            if (_questionsRepository == null)
            {
                _questionsRepository = _unitOfWork.Questions;
            }
            if (_categoryQuestionsRepository == null)
            {
                _categoryQuestionsRepository = _unitOfWork.CategoriesQuestions;
            }
            if (_sectionsCategoriesRepository == null)
            {
                _sectionsCategoriesRepository = _unitOfWork.SectionsCategories;
            }
            if (_formSectionsRepository == null)
            {
                _formSectionsRepository = _unitOfWork.FormsSections;
            }
            if (_sectionsRepository == null)
            {
                _sectionsRepository = _unitOfWork.Sections;
            }
        }

        public IQueryable<AnswersDto> GetAnswersByQuestionId(int Id)
        {
            var result = _answersRepository.Find(x => x.QuestionId == Id)
                            .Select(x => new AnswersDto()
                            {
                                Id = x.Id,
                                AnswerText = x.AnswerText,
                                QuestionId = x.QuestionId,
                                Score = x.Score,
                                IsDefault = x.IsDefault
                            });

            return result;
        }

        public List<int> IsAllQuestionReplied(List<int> answerIds, string cancelledCatIdsParts)
        {
            var cancelledCatIdsStr = cancelledCatIdsParts.Split(',').ToList();
            var cancelledCatIds = new List<int>();
            if (cancelledCatIdsParts.Trim() != string.Empty)
            {
                foreach (string catIdst in cancelledCatIdsStr)
                {
                    cancelledCatIds.Add(Convert.ToInt32(catIdst));
                }
            }

            var answerQuestionIds = _answersRepository.Find(k => answerIds.Contains(k.Id)).Select(m => m.QuestionId).Distinct().ToList();

            SectionsCategories sec = new SectionsCategories();
            List<Int32> catIdss = _categoryQuestionsRepository.Find(k => answerQuestionIds.Contains(k.QuestionId)).Select(m => m.CategoryId).Distinct().ToList();
            int catId = 0;
            foreach (int catid in catIdss)
            {
                sec = _sectionsCategoriesRepository.Find(k => k.CategoryId == catid).FirstOrDefault();
                if (sec != null)
                {
                    catId = catid;
                    break;
                }
            }

            var emptyResult = new List<int>();
            emptyResult.Add(0);
            if (catId == 0 || sec == null)
            {
                return emptyResult;
            }
            var sectionId = sec.SectionId;
            var formId = _formSectionsRepository.Find(k => k.SectionId == sectionId).FirstOrDefault().FormId;
            var sectionIds = _formSectionsRepository.Find(k => k.FormId == formId).Select(m => m.SectionId).ToList();
            var pureSectionIds = _sectionsRepository.Find(k => sectionIds.Contains(k.Id) && k.IsDisabled != true).Select(m => m.Id).ToList();
            var catIds = _sectionsCategoriesRepository.Find(k => pureSectionIds.Contains(k.SectionId)).Select(m => m.CategoryId).ToList();

            var pureCatIds = new List<int>();
            foreach (int cid in catIds)
            {
                if (!cancelledCatIds.Contains(cid))
                {
                    pureCatIds.Add(cid);
                }
            }
            var result = _categoryQuestionsRepository.Find(x => !answerQuestionIds.Contains(x.QuestionId) && pureCatIds.Contains(x.CategoryId)).Select(x => x.QuestionId).Distinct().ToList();

            return result;
        }

        public int CalculateScores(List<int> answerIds)
        {
            var categoriesToZeroize = _answersCategoriesRepository.Find(x => answerIds.Contains(x.AnswerId) && x.DoesZeroize == true).Select(x => x.CategoryId).ToList();
            var questionsToZeroizeFromCategories = _categoryQuestionsRepository.Find(x => categoriesToZeroize.Contains(x.CategoryId)).Select(x => x.QuestionId).ToList();

            var scoreReducedFromCategories = _answersRepository.Find(x => questionsToZeroizeFromCategories.Contains(x.QuestionId)).Sum(x => (short?)x.Score);

            var sectionsToZeroize = _answersSectionsRepository.Find(x => answerIds.Contains(x.AnswerId) && x.DoesZeroize == true).Select(x => x.SectionId).ToList();
            var categoriesToZeroizeFromSections = _sectionsCategoriesRepository.Find(x => sectionsToZeroize.Contains(x.SectionId)).Select(x => x.CategoryId).ToList();
            var questionsToZeroizeFromSections = _categoryQuestionsRepository.Find(x => categoriesToZeroizeFromSections.Contains(x.CategoryId)
                && !questionsToZeroizeFromCategories.Contains(x.QuestionId)).Select(x => x.QuestionId).ToList();

            var scoreReducedFromSections = _answersRepository.Find(x => questionsToZeroizeFromSections.Contains(x.QuestionId)).Sum(x => (short?)x.Score);

            var sum = _answersRepository.Find(x => answerIds.Contains(x.Id)).Sum(x => (short?)x.Score);

            scoreReducedFromCategories = scoreReducedFromCategories ?? 0;
            scoreReducedFromSections = scoreReducedFromSections ?? 0;
            sum = sum ?? 0;

            var result = sum - (scoreReducedFromCategories + scoreReducedFromSections);

            return result ?? 0;
        }
    }
}
