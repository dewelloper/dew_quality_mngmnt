using EvaluationAssistt.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EvaluationAssistt.Data.Interface
{
    public interface IUnitOfWork
    {
        IRepository<Agents> Agents { get; }
        IRepository<AgentTypes> AgentTypes { get; }
        IRepository<Answers> Answers { get; }
        IRepository<AnswersCategoriesSettings> AnswersCategoriesSettings { get; }
        IRepository<AnswersSectionsSettings> AnswersSectionsSettings { get; }
        IRepository<AnswersQuestionsSettings> AnswersQuestionsSettings { get; }
        IRepository<CallsEvaluated> CallsEvaluated { get; }
        IRepository<CallsTemporary> Calls { get; }
        IRepository<Categories> Categories { get; }
        IRepository<CategoriesQuestions> CategoriesQuestions { get; }
        IRepository<Forms> Forms { get; }
        IRepository<FormsCalls> FormsCalls { get; }
        IRepository<FormsCallsEvaluated> FormsCallsEvaluated { get; }
        IRepository<FormsSections> FormsSections { get; }
        IRepository<Groups> Groups { get; }
        IRepository<Locations> Locations { get; }
        IRepository<Messages> Messages { get; }
        IRepository<MessagesAgents> MessagesAgents { get; }
        IRepository<Questions> Questions { get; }
        IRepository<Pages> Pages { get; }
        IRepository<PagesAgents> PagesAgents { get; }
        IRepository<ScoreTypes> ScoreTypes { get; }
        IRepository<Sections> Sections { get; }
        IRepository<SectionsCategories> SectionsCategories { get; }
        IRepository<Teams> Teams { get; }
        IRepository<Flags> Flags { get; }
        IRepository<EvaluatedDetailView> EvaluatedDetailView { get; }
        IRepository<DetailFormView> DetailFormView { get; }
        List<EvaluatedDetailView> GetEvaluatedDetailViews(int agentId, int formId, DateTime startDate, DateTime endDate);
        DataTable GetEvaluations(int agentId, DateTime startDate, DateTime endDate, int formId);
        DataTable GetEvaluationDetail(int formCallId);

        void Save();
        void Save(FormsCalls entity);

        void Dispose();
    }
}
