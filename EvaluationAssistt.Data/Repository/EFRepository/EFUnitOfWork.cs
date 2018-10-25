using System;
using EvaluationAssistt.Domain.Entity;
using EvaluationAssistt.Data.Interface;
using System.IO;
using System.Data.Objects;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Globalization;

namespace EvaluationAssistt.Data.Repository.EFRepository
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly EvaluationAssisttEntities _context;

        private readonly Lazy<IRepository<Agents>> _agentsRepository;
        private readonly Lazy<IRepository<AgentTypes>> _agentTypesRepository;
        private readonly Lazy<IRepository<Answers>> _answersRepository;
        private readonly Lazy<IRepository<AnswersCategoriesSettings>> _answersCategoriesSettingsRepository;
        private readonly Lazy<IRepository<AnswersQuestionsSettings>> _answersQuestionsSettingsRepository;
        private readonly Lazy<IRepository<AnswersSectionsSettings>> _answersSectionsSettingsRepository;
        private readonly Lazy<IRepository<CallsEvaluated>> _callsEvaluatedRepository;
        private readonly Lazy<IRepository<CallsRecorded>> _callsRecordedRepository;
        private readonly Lazy<IRepository<Categories>> _categoriesRepository;
        private readonly Lazy<IRepository<CategoriesQuestions>> _categoriesQuestionsRepository;
        private readonly Lazy<IRepository<Forms>> _formsRepository;
        private readonly Lazy<IRepository<FormsCallsEvaluated>> _formsCallsEvaluatedRepository;
        private readonly Lazy<IRepository<FormsSections>> _formsSectionsRepository;
        private readonly Lazy<IRepository<Groups>> _groupsRepository;
        private readonly Lazy<IRepository<Locations>> _locationsRepository;
        private readonly Lazy<IRepository<Messages>> _messagesRepository;
        private readonly Lazy<IRepository<MessagesAgents>> _messagesAgentsRepository;
        private readonly Lazy<IRepository<Pages>> _pagesRepository;
        private readonly Lazy<IRepository<PagesAgents>> _pagesAgentsRepository;
        private readonly Lazy<IRepository<Questions>> _questionsRepository;
        private readonly Lazy<IRepository<ScoreTypes>> _scoreTypesRepository;
        private readonly Lazy<IRepository<Sections>> _sectionsRepository;
        private readonly Lazy<IRepository<SectionsCategories>> _sectionsCategoriesRepository;
        private readonly Lazy<IRepository<Teams>> _teamsRepository;
        private readonly Lazy<IRepository<CallsTemporary>> _callsRepository;
        private readonly Lazy<IRepository<FormsCalls>> _formsCallsRepository;
        private readonly Lazy<IRepository<Flags>> _flagsRepository;
        private readonly Lazy<IRepository<EvaluatedDetailView>> _evaluatedDetailView;
        private readonly Lazy<IRepository<DetailFormView>> _detailFormView;


        public static EvaluationAssisttEntities GetContext()
        {
            var _cont = new EvaluationAssisttEntities();
            return _cont;
        }

        public virtual DataTable GetEvaluations(int AgentId, DateTime StartDate, DateTime EndDate, int FormId)
        {
            DataTable table = new DataTable();
            using (DbDataAdapter adapter = new SqlDataAdapter())
            {
                adapter.SelectCommand = _context.Database.Connection.CreateCommand();
                adapter.SelectCommand.Parameters.Clear();
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.CommandText = "GetEvaluations";

                SqlParameter aid = new SqlParameter("@AgentId", SqlDbType.Int);
                aid.Value = AgentId;
                SqlParameter sd = new SqlParameter("@StartDate", SqlDbType.DateTime);
                sd.Value = StartDate.Date;
                SqlParameter ed = new SqlParameter("@EndDate", SqlDbType.DateTime);
                ed.Value = EndDate.Date;
                SqlParameter fid = new SqlParameter("@FormId", SqlDbType.Int);
                fid.Value = FormId;

                adapter.SelectCommand.Parameters.Add(fid);
                adapter.SelectCommand.Parameters.Add(aid);
                adapter.SelectCommand.Parameters.Add(sd);
                adapter.SelectCommand.Parameters.Add(ed);
                adapter.Fill(table);
            }

            return table;
        }

        public virtual DataTable GetEvaluationDetail(int FormCallId)
        {
            DataTable table = new DataTable();
            using (DbDataAdapter adapter = new SqlDataAdapter())
            {
                adapter.SelectCommand = _context.Database.Connection.CreateCommand();
                adapter.SelectCommand.Parameters.Clear();
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.CommandText = "GetEvaluationDetail";

                SqlParameter aid = new SqlParameter("@FormCallId", SqlDbType.Int);
                aid.Value = FormCallId;


                adapter.SelectCommand.Parameters.Add(aid);
                adapter.Fill(table);
            }

            return table;
        }


        public virtual List<EvaluatedDetailView> GetEvaluatedDetailViews(int agentId, int formId, DateTime startDate, DateTime endDate)
        {
            var edvse = EFUnitOfWork.GetContext().GetCatAnswers(agentId, formId, startDate, endDate);

            var result = new List<EvaluatedDetailView>();
            foreach (GetCatAnswers_Result gr in edvse)
            {
                result.Add(new EvaluatedDetailView()
                {
                    CEAnswerId = gr.CEAnswerId,
                    CEComment = gr.CEComment,
                    CEFormCallId = gr.CEFormCallId,
                    CEIsDeleted = gr.CEIsDeleted,
                    CEQuestionId = gr.CEQuestionId,
                    FCAgentId = gr.FCAgentId,
                    FCEAgentId = gr.FCEAgentId,
                    FCEAgentNote = gr.FCEAgentNote,
                    FCEAgentSeen = gr.FCEAgentSeen,
                    FCEAgentSees = gr.FCEAgentSees,
                    FCECallId = gr.FCECallId,
                    FCECallState = gr.FCECallState,
                    FCEDate = gr.FCEDate,
                    FCEFormId = gr.FCEFormId,
                    FCEScore = gr.FCEScore,
                    Id = Convert.ToInt32(gr.Id),
                    IsDeleted = gr.IsDeleted
                });
            }

            return result;
        }

        public virtual IRepository<Agents> Agents
        {
            get
            {
                return _agentsRepository.Value;
            }
        }

        public virtual IRepository<AgentTypes> AgentTypes
        {
            get
            {
                return _agentTypesRepository.Value;
            }
        }

        public virtual IRepository<Answers> Answers
        {
            get
            {
                return _answersRepository.Value;
            }
        }

        public virtual IRepository<AnswersCategoriesSettings> AnswersCategoriesSettings
        {
            get
            {
                return _answersCategoriesSettingsRepository.Value;
            }
        }

        public virtual IRepository<AnswersQuestionsSettings> AnswersQuestionsSettings
        {
            get
            {
                return _answersQuestionsSettingsRepository.Value;
            }
        }

        public virtual IRepository<AnswersSectionsSettings> AnswersSectionsSettings
        {
            get
            {
                return _answersSectionsSettingsRepository.Value;
            }
        }

        public virtual IRepository<CallsEvaluated> CallsEvaluated
        {
            get
            {
                return _callsEvaluatedRepository.Value;
            }
        }

        public virtual IRepository<CallsRecorded> CallsRecorded
        {
            get
            {
                return _callsRecordedRepository.Value;
            }
        }

        public virtual IRepository<Categories> Categories
        {
            get
            {
                return _categoriesRepository.Value;
            }
        }

        public virtual IRepository<CategoriesQuestions> CategoriesQuestions
        {
            get
            {
                return _categoriesQuestionsRepository.Value;
            }
        }

        public virtual IRepository<Forms> Forms
        {
            get
            {
                return _formsRepository.Value;
            }
        }

        public virtual IRepository<FormsCallsEvaluated> FormsCallsEvaluated
        {
            get
            {
                return _formsCallsEvaluatedRepository.Value;
            }
        }

        public virtual IRepository<FormsSections> FormsSections
        {
            get
            {
                return _formsSectionsRepository.Value;
            }
        }

        public virtual IRepository<Groups> Groups
        {
            get
            {
                return _groupsRepository.Value;
            }
        }

        public virtual IRepository<Locations> Locations
        {
            get
            {
                return _locationsRepository.Value;
            }
        }

        public virtual IRepository<Messages> Messages
        {
            get
            {
                return _messagesRepository.Value;
            }
        }

        public virtual IRepository<MessagesAgents> MessagesAgents
        {
            get
            {
                return _messagesAgentsRepository.Value;
            }
        }

        public virtual IRepository<Pages> Pages
        {
            get
            {
                return _pagesRepository.Value;
            }
        }

        public virtual IRepository<PagesAgents> PagesAgents
        {
            get
            {
                return _pagesAgentsRepository.Value;
            }
        }

        public virtual IRepository<Questions> Questions
        {
            get
            {
                return _questionsRepository.Value;
            }
        }

        public virtual IRepository<ScoreTypes> ScoreTypes
        {
            get
            {
                return _scoreTypesRepository.Value;
            }
        }

        public virtual IRepository<Sections> Sections
        {
            get
            {
                return _sectionsRepository.Value;
            }
        }

        public virtual IRepository<SectionsCategories> SectionsCategories
        {
            get
            {
                return _sectionsCategoriesRepository.Value;
            }
        }

        public virtual IRepository<Teams> Teams
        {
            get
            {
                return _teamsRepository.Value;
            }
        }

        public virtual IRepository<CallsTemporary> Calls
        {
            get
            {
                return _callsRepository.Value;
            }
        }

        public virtual IRepository<FormsCalls> FormsCalls
        {
            get
            {
                return _formsCallsRepository.Value;
            }
        }

        public virtual IRepository<Flags> Flags
        {
            get
            {
                return _flagsRepository.Value;
            }
        }

        public virtual IRepository<EvaluatedDetailView> EvaluatedDetailView
        {
            get
            {
                return _evaluatedDetailView.Value;
            }
        }

        public virtual IRepository<DetailFormView> DetailFormView
        {
            get
            {
                return _detailFormView.Value;
            }
        }


        public EFUnitOfWork()
            : this(new EvaluationAssisttEntities())
        {
        }

        public EFUnitOfWork(EvaluationAssisttEntities context)
        {
            _context = context;

            _agentsRepository = GetLazyRepository<Agents>(_context);
            _agentTypesRepository = GetLazyRepository<AgentTypes>(_context);
            _answersRepository = GetLazyRepository<Answers>(_context);
            _answersCategoriesSettingsRepository = GetLazyRepository<AnswersCategoriesSettings>(_context);
            _answersQuestionsSettingsRepository = GetLazyRepository<AnswersQuestionsSettings>(_context);
            _answersSectionsSettingsRepository = GetLazyRepository<AnswersSectionsSettings>(_context);
            _callsEvaluatedRepository = GetLazyRepository<CallsEvaluated>(_context);
            _callsRecordedRepository = GetLazyRepository<CallsRecorded>(_context);
            _categoriesRepository = GetLazyRepository<Categories>(_context);
            _categoriesQuestionsRepository = GetLazyRepository<CategoriesQuestions>(_context);
            _formsRepository = GetLazyRepository<Forms>(_context);
            _formsCallsEvaluatedRepository = GetLazyRepository<FormsCallsEvaluated>(_context);
            _formsSectionsRepository = GetLazyRepository<FormsSections>(_context);
            _groupsRepository = GetLazyRepository<Groups>(_context);
            _locationsRepository = GetLazyRepository<Locations>(_context);
            _messagesRepository = GetLazyRepository<Messages>(_context);
            _messagesAgentsRepository = GetLazyRepository<MessagesAgents>(_context);
            _pagesRepository = GetLazyRepository<Pages>(_context);
            _pagesAgentsRepository = GetLazyRepository<PagesAgents>(_context);
            _questionsRepository = GetLazyRepository<Questions>(_context);
            _scoreTypesRepository = GetLazyRepository<ScoreTypes>(_context);
            _sectionsRepository = GetLazyRepository<Sections>(_context);
            _sectionsCategoriesRepository = GetLazyRepository<SectionsCategories>(_context);
            _teamsRepository = GetLazyRepository<Teams>(_context);
            _callsRepository = GetLazyRepository<CallsTemporary>(_context);
            _formsCallsRepository = GetLazyRepository<FormsCalls>(_context);
            _flagsRepository = GetLazyRepository<Flags>(_context);
            _evaluatedDetailView = GetLazyRepository<EvaluatedDetailView>(_context);
            _detailFormView = GetLazyRepository<DetailFormView>(_context);
        }

        private static Lazy<IRepository<TEntity>> GetLazyRepository<TEntity>(EvaluationAssisttEntities context)
            where TEntity : class, IEntity
        {
            return new Lazy<IRepository<TEntity>>(() => new EFRepository<TEntity>(context));
        }

        public virtual void Save()
        {
            try
            {
                _context.SaveChanges();
                
            }
            catch (Exception ex)
            {
                var logg = new Log();
                logg.LogWrite(ex.Message);
            }
        }

        public virtual void Save(FormsCalls entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                var logg = new Log();
                logg.LogWrite(ex.Message);
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }

    public class Log
    {
        private static string _targetFileName = string.Empty;

        public Log()
        {
            var targetPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments, Environment.SpecialFolderOption.Create);
            var targetDirectory = targetPath + "\\Logger\\";
            var targetFileName = targetDirectory + DateTime.Now.ToString("yyyyMMdd") + "log.txt";


            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }
            if (!System.IO.File.Exists(targetFileName))
            {
                var myfile = System.IO.File.Create(targetFileName);
                myfile.Close();
            }

            _targetFileName = targetFileName;
        }
        internal void LogWrite(string Log)
        {
            using (var fs = new FileStream(_targetFileName, FileMode.Append, FileAccess.Write))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine(DateTime.Now + " --> " + Log);
                }
            }
        }
    }
}

