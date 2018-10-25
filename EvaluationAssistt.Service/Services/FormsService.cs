using EvaluationAssistt.Data.Interface;
using EvaluationAssistt.Domain.Entity;
using EvaluationAssistt.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Data.Repository.EFRepository.ExtendedRepository;

namespace EvaluationAssistt.Service.Services
{
    public class FormsService
    {
        private static IUnitOfWork _unitOfWork;
        private static IRepository<Forms> _formsRepository;
        private static IRepository<SectionsCategories> _sectionsCategoriesRepository;
        private static IRepository<Categories> _categoriesRepository;
        private static IRepository<FormsCalls> _formsCallsRepository;
        private static IRepository<FormsCallsEvaluated> _formsCallsEvaluatedRepository;
        private static IRepository<CallsEvaluated> _callsEvaluatedRepository;
        private static IRepository<CategoriesQuestions> _categoriesQuestionsRepository;
        private static IRepository<Questions> _questionsRepository;
        private static CallsRepository _callsRepositoryCustom;
        private static IRepository<Flags> _flagRepository;


        public FormsService()
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = UnityHelper.Container.Resolve<IUnitOfWork>();
            }
            if (_formsRepository == null)
            {
                _formsRepository = _unitOfWork.Forms;
            }
            if (_sectionsCategoriesRepository == null)
            {
                _sectionsCategoriesRepository = _unitOfWork.SectionsCategories;
            }
            if (_categoriesRepository == null)
            {
                _categoriesRepository = _unitOfWork.Categories;
            }
            if (_formsCallsRepository == null)
            {
                _formsCallsRepository = _unitOfWork.FormsCalls;
            }
            if (_formsCallsEvaluatedRepository == null)
            {
                _formsCallsEvaluatedRepository = _unitOfWork.FormsCallsEvaluated;
            }
            if (_callsEvaluatedRepository == null)
            {
                _callsEvaluatedRepository = _unitOfWork.CallsEvaluated;
            }
            if (_categoriesQuestionsRepository == null)
            {
                _categoriesQuestionsRepository = _unitOfWork.CategoriesQuestions;
            }
            if (_questionsRepository == null)
            {
                _questionsRepository = _unitOfWork.Questions;
            }
            if (_flagRepository == null)
            {
                _flagRepository = _unitOfWork.Flags;
            }
            if (_callsRepositoryCustom == null)
            {
                _callsRepositoryCustom = new CallsRepository();
            }
        }

        public IQueryable<FormsDto> GetFormsAll()
        {
            var result = _formsRepository.All()
                            .Select(x => new FormsDto()
                            {
                                Id = x.Id,
                                Name = x.Name,
                                RequiresComment = x.RequiresComment,
                                IsDisabled = x.IsDisabled
                            });

            return result;
        }

        public IQueryable<FormsDto> GetFormsNameValueCollection(int auth)
        {
            var result = _formsRepository.Find(k => k.IsDisabled == false || k.IsDisabled == null || auth == 1)
                            .Select(x => new FormsDto()
                            {
                                Id = x.Id,
                                Name = x.Name
                            });

            return result;
        }

        public IQueryable<FlagsDto> GetFlags()
        {
            var result = _flagRepository.Find(k => k.IsDeleted == false).Select(x => new FlagsDto()
            {
                Id = x.Id,
                FlagName = x.FlagName,
                FlagType = x.FlagType
            });

            return result;
        }

        public bool ISUsedCallId(int callId)
        {
            var fce = _formsCallsEvaluatedRepository.Find(k => k.CallId == callId).ToList();
            if (fce.Count > 0)
            {
                return true;
            }
            return false;
        }

        public void SaveFlags(int formsCallsEvaluatedId, List<int> flagIds)
        {
            var fce = _formsCallsEvaluatedRepository.Find(k => k.Id == formsCallsEvaluatedId).FirstOrDefault();
            if (fce != null)
            {
                var arr = string.Empty;
                foreach (int id in flagIds)
                {
                    arr += id.ToString() + "|";
                }
                fce.FlagId = arr;
            }
            _unitOfWork.Save();
        }

        public FormsDto GetFormById(int id)
        {
            var form = _formsRepository.Find(k => k.Id == id).FirstOrDefault();
            if (form == null)
            {
                form = new Forms() { Name = string.Empty, RequiresComment = false, MinimumScore = 0, MaximumScore = 0, CategoriesBasedScore = false, IsDisabled = false };
            }
            var result = new FormsDto()
            { Id = form.Id,
                Name = form.Name,
                RequiresComment = form.RequiresComment,
                MinimumScore = form.MinimumScore,
                MaximumScore = form.MaximumScore,
                CategoriesBasedScore = form.CategoriesBasedScore,
                IsDisabled = form.IsDisabled
            };

            return result;
        }

        public IQueryable<FormsSectionsDto> GetFormSectionsById(int id)
        {
            var result = _formsRepository.FindById(id, "FormsSections").FormsSections
                            .Select(x => new FormsSectionsDto()
                            {
                                Id = x.Id,
                                FormId = x.FormId,
                                SectionId = x.SectionId,
                                SectionName = x.Sections.Name
                            }).AsQueryable();

            return result;
        }

        public void InsertForm(FormsDto dto)
        {
            var entity = new Forms()
            { Name = dto.Name,
                RequiresComment = dto.RequiresComment,
                MinimumScore = dto.MinimumScore,
                MaximumScore = dto.MaximumScore,
                CategoriesBasedScore = dto.CategoriesBasedScore
            };

            _formsRepository.Insert(entity);

            _unitOfWork.Save();
        }

        public void UpdateForm(FormsDto dto)
        {
            var entity = _formsRepository.FindById(dto.Id);

            entity.Name = dto.Name;
            entity.RequiresComment = dto.RequiresComment;
            entity.MinimumScore = dto.MinimumScore;
            entity.MaximumScore = dto.MaximumScore;
            entity.CategoriesBasedScore = dto.CategoriesBasedScore;
            entity.IsDisabled = dto.IsDisabled;

            _unitOfWork.Save();
        }

        public void DeleteForm(int id)
        {
            var entity = _formsRepository.FindById(id);

            _formsRepository.Delete(entity, true);

            _unitOfWork.Save();
        }

        public IQueryable<FormsSectionsDto> GetSectionsByFormId(int formId)
        {
            var result = _formsRepository.FindById(formId).FormsSections
                        .Select(x => new FormsSectionsDto()
                        {
                            SectionId = x.SectionId,
                            SectionName = x.Sections.Name
                        }).AsQueryable();

            return result;
        }

        public IQueryable<SectionsCategoriesDto> GetCategoriesByFormId(int formId)
        {
            var sectionIds = _formsRepository.FindById(formId).FormsSections
                        .Select(x => x.SectionId).ToList();


            var categoryIds = _sectionsCategoriesRepository.Find(x => sectionIds.Contains(x.SectionId)).Select(x => x.CategoryId).Distinct();

            var result = _categoriesRepository.Find(x => categoryIds.Contains(x.Id))
                        .Select(x => new SectionsCategoriesDto()
                        {
                            CategoryId = x.Id,
                            CategoryName = x.Name
                        }).AsQueryable();

            return result;
        }

        public IQueryable<CategoriesQuestionsDto> GetQuestionsByFormId(int formId)
        {
            var sections = _formsRepository.FindById(formId).FormsSections
                        .Select(x => x.SectionId).ToList();

            var categories = _sectionsCategoriesRepository.Find(x => sections.Contains(x.SectionId))
                        .Select(x => x.CategoryId).ToList();

            var questions = _categoriesQuestionsRepository.Find(x => categories.Contains(x.CategoryId))
                        .Select(x => x.QuestionId);

            var result = _questionsRepository.Find(x => questions.Contains(x.Id))
                        .Select(x => new CategoriesQuestionsDto()
                        {
                            QuestionId = x.Id,
                            QuestionText = x.QuestionText
                        });


            return result;
        }

        /// <summary>
        /// Saves Calculated Forms to db maybe changable according the parameters
        /// </summary>
        /// <param name="answers"></param>
        /// <param name="comments"></param>
        /// <param name="formId"></param>
        /// <param name="callId"></param>
        /// <param name="agentId"></param>
        /// <param name="score"></param>
        /// <param name="isInsertOrUpdate">True: will insert everytime  False: will insert if this callId not exist in FormsCallsEvaluated table otherwise will find and update it with its answers..
        /// </param>
        public int SubmitForm(Dictionary<int, int> answers, Dictionary<int, string> comments, int formId, string callId, int agentId, int score, bool isInsertOrUpdate = true, int Fceid = 0, string evalutaionNote = "")
        {
            var entity = new FormsCallsEvaluated()
            { FormId = formId,
                CallId = int.Parse(callId),
                AgentId = agentId,
                Score = score,
                Date = DateTime.Now,
                EvaluationDetailNote = evalutaionNote
            };

            if (isInsertOrUpdate)
            {
                _formsCallsEvaluatedRepository.Insert(entity);
            }
            else
            {
                var cId = Convert.ToInt32(callId);
                var fce = _formsCallsEvaluatedRepository.Find(k => k.CallId == cId && k.Id == Fceid).FirstOrDefault();
                if (fce == null)
                {
                    _formsCallsEvaluatedRepository.Insert(entity);
                }
                else
                {
                    if (fce.EvaluationDetailNote == string.Empty && evalutaionNote != string.Empty)
                    {
                        fce.EvaluationDetailNote = evalutaionNote;
                    }
                    fce.Score = score;
                    fce.Date = DateTime.Now;

                    var oldAnswers = _callsEvaluatedRepository.Find(k => k.FormCallId == fce.Id).ToList();
                    foreach (CallsEvaluated ce in oldAnswers)
                    {
                        var item = answers.Where(k => k.Key == ce.QuestionId).FirstOrDefault();
                        if (item.Value != null && item.Value != 0)
                        {
                            ce.AnswerId = item.Value;
                        }
                    }

                    _unitOfWork.Save();
                    return entity.Id;
                }
            }

            _unitOfWork.Save();

            foreach (KeyValuePair<int, int> item in answers)
            {
                _callsEvaluatedRepository.Insert(new CallsEvaluated()
                {
                    FormCallId = entity.Id,
                    QuestionId = item.Key,
                    AnswerId = item.Value,
                    Comment = comments.ContainsKey(item.Key) ? comments[item.Key] : null
                });
            }

            _unitOfWork.Save();
            return entity.Id;
        }

        public bool DeleteFormCallsById(int formsCallsId)
        {
            var fce = _unitOfWork.FormsCallsEvaluated.Find(k => k.Id == formsCallsId).FirstOrDefault();
            fce.IsDeleted = true;
            _unitOfWork.Save();

            return true;
        }

        public string GetFormNameById(int formId)
        {
            var result = _formsRepository.FindById(formId).Name;

            return result;
        }

        public string GetTLComment(int formsCallsId)
        {
            var fce = _unitOfWork.FormsCallsEvaluated.Find(k => k.Id == formsCallsId).FirstOrDefault();
            if (fce != null)
                return fce.TLComment;
            else return "";
        }

        public int GetFormCallId(int callId, int formId)
        {
            var formCall = _formsCallsRepository.Find(x => x.CallId == callId && x.FormId == formId).FirstOrDefault();

            if (formCall == null)
            {
                return 0;
            }
            return formCall.Id;
        }

        public IQueryable<ufnFormSettings_Result> GetFormSettings()
        {
            return _callsRepositoryCustom.GetFormSettings();
        }
    }
}
