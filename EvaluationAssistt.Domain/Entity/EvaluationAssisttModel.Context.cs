namespace EvaluationAssistt.Domain.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;

    public partial class EvaluationAssisttEntities : DbContext
    {
        public EvaluationAssisttEntities()
            : base("name=EvaluationAssisttEntities")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        public DbSet<Agents> Agents { get; set; }
        public DbSet<AgentTypes> AgentTypes { get; set; }
        public DbSet<Answers> Answers { get; set; }
        public DbSet<AnswersCategoriesSettings> AnswersCategoriesSettings { get; set; }
        public DbSet<AnswersQuestionsSettings> AnswersQuestionsSettings { get; set; }
        public DbSet<AnswersSectionsSettings> AnswersSectionsSettings { get; set; }
        public DbSet<CallsEvaluated> CallsEvaluated { get; set; }
        public DbSet<CallsRecorded> CallsRecorded { get; set; }
        public DbSet<CallsTemporary> CallsTemporary { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<CategoriesQuestions> CategoriesQuestions { get; set; }
        public DbSet<Flags> Flags { get; set; }
        public DbSet<FormCallsEvaluatedStateTypes> FormCallsEvaluatedStateTypes { get; set; }
        public DbSet<Forms> Forms { get; set; }
        public DbSet<FormsCallsEvaluated> FormsCallsEvaluated { get; set; }
        public DbSet<FormsSections> FormsSections { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<MessagesAgents> MessagesAgents { get; set; }
        public DbSet<Pages> Pages { get; set; }
        public DbSet<PagesAgents> PagesAgents { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<ScoreTypes> ScoreTypes { get; set; }
        public DbSet<Sections> Sections { get; set; }
        public DbSet<SectionsCategories> SectionsCategories { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<Calls> Calls { get; set; }
        public DbSet<DetailFormView> DetailFormView { get; set; }
        public DbSet<EvaluatedDetailView> EvaluatedDetailView { get; set; }
        public DbSet<FormsCalls> FormsCalls { get; set; }
        [EdmFunction("EvaluationAssisttEntities", "ufnCallEvaluatedSummaries")]
        public virtual IQueryable<ufnCallEvaluatedSummaries_Result> ufnCallEvaluatedSummaries(Nullable<int> teamId, Nullable<System.DateTime> dateMin, Nullable<System.DateTime> dateMax)
        {
            var teamIdParameter = teamId.HasValue ?
                new ObjectParameter("TeamId", teamId) :
                new ObjectParameter("TeamId", typeof(int));
            var dateMinParameter = dateMin.HasValue ?
                new ObjectParameter("DateMin", dateMin) :
                new ObjectParameter("DateMin", typeof(System.DateTime));
            var dateMaxParameter = dateMax.HasValue ?
                new ObjectParameter("DateMax", dateMax) :
                new ObjectParameter("DateMax", typeof(System.DateTime));
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<ufnCallEvaluatedSummaries_Result>("[EvaluationAssisttEntities].[ufnCallEvaluatedSummaries](@TeamId, @DateMin, @DateMax)", teamIdParameter, dateMinParameter, dateMaxParameter);
        }
        [EdmFunction("EvaluationAssisttEntities", "ufnCallEvaluatedTeamLeaderSummaries")]
        public virtual IQueryable<ufnCallEvaluatedTeamLeaderSummaries_Result> ufnCallEvaluatedTeamLeaderSummaries(Nullable<int> agentId, Nullable<System.DateTime> dateMin, Nullable<System.DateTime> dateMax)
        {
            var agentIdParameter = agentId.HasValue ?
                new ObjectParameter("AgentId", agentId) :
                new ObjectParameter("AgentId", typeof(int));
            var dateMinParameter = dateMin.HasValue ?
                new ObjectParameter("DateMin", dateMin) :
                new ObjectParameter("DateMin", typeof(System.DateTime));
            var dateMaxParameter = dateMax.HasValue ?
                new ObjectParameter("DateMax", dateMax) :
                new ObjectParameter("DateMax", typeof(System.DateTime));
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<ufnCallEvaluatedTeamLeaderSummaries_Result>("[EvaluationAssisttEntities].[ufnCallEvaluatedTeamLeaderSummaries](@AgentId, @DateMin, @DateMax)", agentIdParameter, dateMinParameter, dateMaxParameter);
        }
        [EdmFunction("EvaluationAssisttEntities", "ufnCallSummaries")]
        public virtual IQueryable<ufnCallSummaries_Result> ufnCallSummaries(Nullable<int> teamId, Nullable<System.DateTime> dateMin, Nullable<System.DateTime> dateMax)
        {
            var teamIdParameter = teamId.HasValue ?
                new ObjectParameter("TeamId", teamId) :
                new ObjectParameter("TeamId", typeof(int));
            var dateMinParameter = dateMin.HasValue ?
                new ObjectParameter("DateMin", dateMin) :
                new ObjectParameter("DateMin", typeof(System.DateTime));
            var dateMaxParameter = dateMax.HasValue ?
                new ObjectParameter("DateMax", dateMax) :
                new ObjectParameter("DateMax", typeof(System.DateTime));
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<ufnCallSummaries_Result>("[EvaluationAssisttEntities].[ufnCallSummaries](@TeamId, @DateMin, @DateMax)", teamIdParameter, dateMinParameter, dateMaxParameter);
        }
        [EdmFunction("EvaluationAssisttEntities", "ufnCallTeamSummaries")]
        public virtual IQueryable<ufnCallTeamSummaries_Result> ufnCallTeamSummaries(Nullable<int> groupId, Nullable<System.DateTime> dateMin, Nullable<System.DateTime> dateMax)
        {
            var groupIdParameter = groupId.HasValue ?
                new ObjectParameter("GroupId", groupId) :
                new ObjectParameter("GroupId", typeof(int));
            var dateMinParameter = dateMin.HasValue ?
                new ObjectParameter("DateMin", dateMin) :
                new ObjectParameter("DateMin", typeof(System.DateTime));
            var dateMaxParameter = dateMax.HasValue ?
                new ObjectParameter("DateMax", dateMax) :
                new ObjectParameter("DateMax", typeof(System.DateTime));
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<ufnCallTeamSummaries_Result>("[EvaluationAssisttEntities].[ufnCallTeamSummaries](@GroupId, @DateMin, @DateMax)", groupIdParameter, dateMinParameter, dateMaxParameter);
        }
        [EdmFunction("EvaluationAssisttEntities", "ufnFormSettings")]
        public virtual IQueryable<ufnFormSettings_Result> ufnFormSettings()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<ufnFormSettings_Result>("[EvaluationAssisttEntities].[ufnFormSettings]()");
        }
        public virtual ObjectResult<GetCatAnswers_Result> GetCatAnswers(Nullable<int> agentId, Nullable<int> formId, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var agentIdParameter = agentId.HasValue ?
                new ObjectParameter("AgentId", agentId) :
                new ObjectParameter("AgentId", typeof(int));
            var formIdParameter = formId.HasValue ?
                new ObjectParameter("FormId", formId) :
                new ObjectParameter("FormId", typeof(int));
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetCatAnswers_Result>("GetCatAnswers", agentIdParameter, formIdParameter, startDateParameter, endDateParameter);
        }
        public virtual ObjectResult<getLocations_Result> getLocations()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getLocations_Result>("getLocations");
        }
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
        public virtual int uspActiveDirectorySyncLocations()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspActiveDirectorySyncLocations");
        }
        public virtual int uspActiveDirectorySyncUsers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspActiveDirectorySyncUsers");
        }
        public virtual int uspImportCalls()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspImportCalls");
        }
    }
}
