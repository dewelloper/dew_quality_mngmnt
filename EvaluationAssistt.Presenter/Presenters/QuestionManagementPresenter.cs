using EvaluationAssistt.Presenter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using EvaluationAssistt.Service.Services;

namespace EvaluationAssistt.Presenter.Presenters
{
    public class QuestionManagementPresenter
    {
        private readonly IQuestionManagementView view;

        private static QuestionsService _questionsService;

        public QuestionManagementPresenter(IQuestionManagementView view)
        {
            this.view = view;

            if (_questionsService == null)
            {
                _questionsService = new QuestionsService();
            }
        }

        public void GetQuestionsAll()
        {
            var result = _questionsService.GetQuestionsAll();

            view.Questions = result;
        }

        public void GetQuestionById(int id)
        {
            var result = _questionsService.GetQuestionById(id);

            view.Id = result.Id;
            view.QuestionText = result.QuestionText;
            view.HasComment = result.HasComment;
            view.RequiresComment = result.RequiresComment;
            view.HasVisibleScore = result.HasVisibleScore;
            view.HasMultipleAnswers = result.HasMultipleAnswers;
            view.Answers = result.Answers;
        }

        public void InsertQuestion()
        {
            var dto = view.Dto;

            _questionsService.InsertQuestions(dto);
        }

        public void UpdateQuestion()
        {
            var dto = view.Dto;
            _questionsService.UpdateQuestions(dto);
        }

        public void DeleteQuestion(int id)
        {
            _questionsService.DeleteQuestion(id);
        }
    }
}
