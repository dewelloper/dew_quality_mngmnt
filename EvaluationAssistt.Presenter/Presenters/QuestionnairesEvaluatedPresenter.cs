using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Presenters
{
    public class QuestionnairesEvaluatedPresenter
    {
        private readonly IQuestionnairesEvaluatedView view;

        private static FormsSectionsService _formsSectionsService;
        private static FormsService _formsService;
        private static SectionsCategoriesService _sectionsCategoriesService;
        private static CategoriesQuestionsService _categoriesQuestionsService;
        private static AnswersService _answersService;
        private static CallsService _callsService;
        private static CallsEvaluatedService _callsEvaluatedService;
        private static FormsCallsService _formsCallsService;
        private static AnswersCategoriesSettingsService _answersCategoriesSettingsService;
        private static AnswersSectionsSettingService _answersSectionsSettingsService;
        private static AnswersQuestionsSettingsService _answersQuestionsSettingsService;

        public QuestionnairesEvaluatedPresenter(IQuestionnairesEvaluatedView view)
        {
            this.view = view;

            if (_formsSectionsService == null)
            {
                _formsSectionsService = new FormsSectionsService();
            }
            if (_formsService == null)
            {
                _formsService = new FormsService();
            }
            if (_sectionsCategoriesService == null)
            {
                _sectionsCategoriesService = new SectionsCategoriesService();
            }
            if (_categoriesQuestionsService == null)
            {
                _categoriesQuestionsService = new CategoriesQuestionsService();
            }
            if (_answersService == null)
            {
                _answersService = new AnswersService();
            }
            if (_callsService == null)
            {
                _callsService = new CallsService();
            }
            if (_callsEvaluatedService == null)
            {
                _callsEvaluatedService = new CallsEvaluatedService();
            }
            if (_formsCallsService == null)
            {
                _formsCallsService = new FormsCallsService();
            }
            if (_answersQuestionsSettingsService == null)
            {
                _answersQuestionsSettingsService = new AnswersQuestionsSettingsService();
            }
            if (_answersCategoriesSettingsService == null)
            {
                _answersCategoriesSettingsService = new AnswersCategoriesSettingsService();
            }
            if (_answersSectionsSettingsService == null)
            {
                _answersSectionsSettingsService = new AnswersSectionsSettingService();
            }
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

        public void GetCallDetails()
        {
            var result = _callsService.GetCallById(view.CallId);

            view.AgentName = result.AgentName;
            view.DateStarted = result.DateStarted.Value.ToString();
            view.FileName = result.FileName;

            if (result.IsIncoming == "1")
                view.CallPhone = result.CalledDeviceId;
            else view.CallPhone = result.CallingDeviceId;
        }

        public void GetEvaluationDetails()
        {
            var result = _formsCallsService.GetCallEvaluated(view.CallId, view.FormId, view.Fceid);

            view.EvaluatorName = result.EvaluatorName;
            view.EvaluationDate = result.EvaluationDate.ToShortDateString();
            view.TotalScore = _formsService.GetFormById(view.FormId).MaximumScore.ToString();
            view.CalculatedScore = result.Score.ToString();
        }

        public void GetFormNameById()
        {
            var result = _formsService.GetFormNameById(view.FormId);

            view.FormName = result;
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

        public int GetFormCallId(int callId, int formId)
        {
            return _formsService.GetFormCallId(callId, formId);
        }

        public Tuple<bool, string> GetIfAnswerExists(int formCallId, int questionId, int answerId)
        {
            return _callsEvaluatedService.GetIfAnswerExists(formCallId, questionId, answerId);
        }

        public string GetFormNote()
        {
            var formCallId = GetFormCallId(view.CallId, view.FormId);

            var note = _formsCallsService.GetFormCallNote(formCallId);

            return note;
        }

        public string GetFormTLNote()
        {
            var note = _formsCallsService.GetFormTLNote(view.Fceid);

            return note;
        }

        public string GetFormISMNote()
        {
            var note = _formsCallsService.GetFormISMNote(view.Fceid);

            return note;
        }

        public string GetEvaluationNote()
        {
            var note = _formsCallsService.GetEvaluationNote(view.Fceid);

            return note;
        }

        public void SaveNote(int callId, int formId, string note)
        {
            _formsCallsService.SaveNote(callId, formId, note);
        }

        public void SaveInstantancy(int callId, int formId, string selection, string editedScore, string ISMNote, string TLNote, Dictionary<int, int> answers, int fceid)
        {
            var entity = _formsCallsService.GetCallEvaluated(callId, formId, 0);
            _formsCallsService.SaveInstantancy(callId, formId, selection, editedScore, ISMNote, TLNote, answers, entity.Id, fceid);
        }

        public void SetNoteSeen(int callId, int formId)
        {
            _formsCallsService.SetNoteSeen(callId, formId);
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

        public void SubmitForm(Dictionary<int, int> answers, Dictionary<int, string> comments, int formId, string callId, int agentId, int score, int Fceid)
        {
            _formsCallsService.GetCallEvaluated(int.Parse(callId), formId, Fceid);
            _formsService.SubmitForm(answers, comments, formId, callId, agentId, score, false, Fceid);
        }

        public bool DeleteFormCallsById(int fcid)
        {
            _formsCallsService.DeleteEvaluation(fcid);
            return true;
        }
    }
}
