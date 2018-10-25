using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Presenters
{
    public class QuestionnairesEvaluatedListPresenter
    {
        private IQuestionnairesEvaluatedListView view;

        private static FormsCallsService _formsCallsService;

        public QuestionnairesEvaluatedListPresenter(IQuestionnairesEvaluatedListView view)
        {
            this.view = view;

            if (_formsCallsService == null)
            {
                _formsCallsService = new FormsCallsService();
            }
        }

        public void GetCallsEvaluated(int? minScore, int? maxScore)
        {
            var evaluationtype = view.Evaluationtype;
            var userId = view.AgentId;
            var result = _formsCallsService.GetCallsEvaluatedByTeams(view.Teams, minScore, maxScore, evaluationtype, userId);

            view.Calls = result;
        }

        public void DeleteEvaluation(int id)
        {
            _formsCallsService.DeleteEvaluation(id);
        }
    }
}
