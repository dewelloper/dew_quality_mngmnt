using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Presenters
{
    public class QuestionnairesPresenter
    {
        private readonly IQuestionnairesView view;

        private static FormsService _formsService;
        private static SectionsService _sectionsService;
        private static FormsSectionsService _formsSectionsService;
        private static SectionsCategoriesService _sectionsCategoriesService;
        private static CategoriesQuestionsService _categoriesQuestionsService;
        private static AnswersService _answersService;
        private static AnswersCategoriesSettingsService _answersCategoriesSettingsService;
        private static AnswersSectionsSettingService _answersSectionsSettingsService;
        private static AnswersQuestionsSettingsService _answersQuestionsSettingsService;
        private static CallsService _callsService;
        private static CallsEvaluatedService _callsEvaluatedService;

        public QuestionnairesPresenter(IQuestionnairesView view)
        {
            this.view = view;

            if (_formsService == null)
            {
                _formsService = new FormsService();
            }
            if (_sectionsService == null)
            {
                _sectionsService = new SectionsService();
            }
            if (_formsSectionsService == null)
            {
                _formsSectionsService = new FormsSectionsService();
            }
            if (_sectionsCategoriesService == null)
            {
                _sectionsCategoriesService = new SectionsCategoriesService();
            }
            if (_categoriesQuestionsService == null)
            {
                _categoriesQuestionsService = new CategoriesQuestionsService();
            }
            if (_answersQuestionsSettingsService == null)
            {
                _answersQuestionsSettingsService = new AnswersQuestionsSettingsService();
            }
            if (_answersService == null)
            {
                _answersService = new AnswersService();
            }
            if (_answersCategoriesSettingsService == null)
            {
                _answersCategoriesSettingsService = new AnswersCategoriesSettingsService();
            }
            if (_answersSectionsSettingsService == null)
            {
                _answersSectionsSettingsService = new AnswersSectionsSettingService();
            }
            if (_callsService == null)
            {
                _callsService = new CallsService();
            }
            if (_callsEvaluatedService == null)
            {
                _callsEvaluatedService = new CallsEvaluatedService();
            }
        }

        public void GetForms()
        {
            var auth = 0;
            if (EvaluationAssistt.Infrastructure.Helpers.UserHelper.Type == Infrastructure.Enums.UserType.QualityExpert || EvaluationAssistt.Infrastructure.Helpers.UserHelper.Type == Infrastructure.Enums.UserType.Admin)
            {
                auth = 1;
            }
            var result = _formsService.GetFormsNameValueCollection(auth);

            view.Forms = result;
        }

        public void GetFormById(int FormId)
        {
            view.FormSelected = _formsService.GetFormById(FormId);
        }

        public void GetSectionsByFormId()
        {
            var result = _formsSectionsService.GetSectionsByFormId(view.FormId);

            view.Sections = result;
        }

        public IQueryable<CategoriesDto> GetCategoriesBySectionId(int sectionId)
        {
            return _sectionsCategoriesService.GetCategoriesBySectionId(sectionId);
        }

        public IQueryable<QuestionsDto> GetQuestionsByCategoryId(int categoryId)
        {
            return _categoriesQuestionsService.GetQuestionsByCategoryId(categoryId);
        }

        public ICollection<AnswersDto> GetAnswersByQuestionId(int questionId)
        {
            return _answersService.GetAnswersByQuestionId(questionId).ToList();
        }

        public List<int> GetCategoriesToToggleByAnswerId(int p)
        {
            return _answersCategoriesSettingsService.GetCategoriesToToggleByAnswerId(p);
        }

        public List<int> GetSectionsToToggleByAnswerId(int p)
        {
            return _answersSectionsSettingsService.GetSectionsToToggleByAnswerId(p);
        }

        public List<int> GetQuestionsToToggleByAnswerId(int p)
        {
            return _answersQuestionsSettingsService.GetQuestionsToToggleByAnswerId(p);
        }

        public void GetCallDetails()
        {
            var result = _callsService.GetCallById(view.CallId);

            view.AgentName = result.AgentName;
            view.DateStarted = result.DateStarted.Value.ToString();
            view.FileName = result.FileName;
            view.Marked = result.Marked;

            if(result.IsIncoming == "OUT")
                view.CallPhone = result.CalledDeviceId;
            else view.CallPhone = result.CallingDeviceId;
        }

        public void GetFlags()
        {
            var result = _formsService.GetFlags();
            view.Flags = result;
        }

        public bool ISUsedCallId(int callId)
        {
            return _formsService.ISUsedCallId(callId);
        }

        public string IsAllReplied(List<int> radio_ids, string cancelledParts)
        {
            var isallreplied = _answersService.IsAllQuestionReplied(radio_ids, cancelledParts);
            var allReplyExtension = string.Empty;
            if (isallreplied != null)
            {
                foreach (int reply in isallreplied)
                {
                    allReplyExtension += reply.ToString() + ",";
                }
            }
            return allReplyExtension;
        }

        public string CalculateScore(List<int> radio_ids, List<int> check_ids, string _formId)
        {
            var radio = _answersService.CalculateScores(radio_ids);
            var check = _answersService.CalculateScores(check_ids);

            var formId = int.Parse(_formId);
            var form = _formsService.GetFormById(formId);

            var result = radio + check;

            result = result > form.MaximumScore ? form.MaximumScore : result;

            result = result < form.MinimumScore ? form.MinimumScore : result;

            return (result).ToString();
        }

        public void SubmitForm(Dictionary<int, int> answers, Dictionary<int, string> comments, int formId, string callId, int agentId, int score, bool isInsertOrUpdate, string evalutaionNote)
        {
            var insertedId = _formsService.SubmitForm(answers, comments, formId, callId, agentId, score, isInsertOrUpdate, 0, evalutaionNote);
            view.InsertedId = insertedId;
        }

        public bool GetIfFormIsEvaluated()
        {
            return _formsService.GetFormCallId(view.CallId, view.FormId) != 0;
        }

        public void MarkCall(bool marked, string callId)
        {
            _callsService.MarkForm(marked, callId);
        }

        public void SaveFlags(int formsCallsEvaluatedId, List<int> flagIds)
        {
            _formsService.SaveFlags(formsCallsEvaluatedId, flagIds);
        }
    }
}
