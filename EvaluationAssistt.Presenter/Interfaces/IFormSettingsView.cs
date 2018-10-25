using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Interfaces
{
    public interface IFormSettingsView
    {
        int FormId { get; set; }
        int SectionId { get; set; }
        int CategoryId { get; set; }
        int QuestionId { get; set; }
        int AnswerId { get; }

        IQueryable<FormsDto> Forms { set; }
        IQueryable<FormsSectionsDto> Sections { set; }
        IQueryable<SectionsCategoriesDto> Categories { set; }
        IQueryable<CategoriesQuestionsDto> Questions { set; }
        IQueryable<AnswersDto> Answers { set; }
        IQueryable<ScoreTypesDto> ScoreTypes { set; }
        SectionsDto SectionDetails { set; }
        CategoriesDto CategoryDetails { set; }
        IQueryable<FormsSectionsDto> SectionsSettingsToLoad { set; }
        IQueryable<SectionsCategoriesDto> CategoriesSettingsToLoad { set; }
        IQueryable<CategoriesQuestionsDto> QuestionsSettingsToLoad { set; }
        IQueryable<AnswersSectionsSettingsDto> AnswersSectionsSettings { get; set; }
        IQueryable<AnswersCategoriesSettingsDto> AnswersCategoriesSettings { get; set; }
        IQueryable<AnswersQuestionsSettingsDto> AnswersQuestionsSettings { get; set; }
        IQueryable<ufnFormSettings_Result> FormSettingsList { set; }
    }
}
