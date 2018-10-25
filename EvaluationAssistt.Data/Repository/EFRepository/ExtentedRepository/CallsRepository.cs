using EvaluationAssistt.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Data.Repository.EFRepository.ExtendedRepository
{
    public class CallsRepository
    {
        private EvaluationAssisttEntities context;

        public CallsRepository()
        {
            context = new EvaluationAssisttEntities();
        }

        public IQueryable<ufnCallSummaries_Result> TeamCallSummary(int? teamId, DateTime dateMin, DateTime dateMax)
        {
            return context.ufnCallSummaries(teamId, dateMin, dateMax);
        }

        public IQueryable<ufnCallEvaluatedSummaries_Result> TeamCallEvaluatedSummary(int? teamId, DateTime dateMin, DateTime dateMax)
        {
            return context.ufnCallEvaluatedSummaries(teamId, dateMin, dateMax);
        }

        public IQueryable<ufnCallEvaluatedTeamLeaderSummaries_Result> GetTeamLeaderCallEvaluatedSummary(int agentId, DateTime dateMin, DateTime dateMax)
        {
            return context.ufnCallEvaluatedTeamLeaderSummaries(agentId, dateMin, dateMax);
        }

        public IQueryable<ufnCallTeamSummaries_Result> GetGroupCallSummary(int groupId, DateTime dateMin, DateTime dateMax)
        {
            var min = DateTime.Now.AddDays(-30);
            var max = DateTime.Now;
            if (dateMin.ToString().Contains("001"))
            {
                dateMin = min;
            }
            if (dateMax.ToString().Contains("001"))
            {
                dateMax = max;
            }
            return context.ufnCallTeamSummaries(groupId, dateMin, dateMax);
        }
        public IQueryable<ufnFormSettings_Result> GetFormSettings()
        {
            return context.ufnFormSettings();
        }

        public List<Groups> GetGroups()
        {
            return context.Groups.ToList();
        }

        public List<Groups> GetGroupsById(int groupId)
        {
            return context.Groups.Where(k => k.Id == groupId).ToList();
        }

        public List<Teams> GetTeams()
        {
            return context.Teams.ToList();
        }

        public List<Teams> GetTeamsById(int teamId)
        {
            return context.Teams.Where(k => k.Id == teamId).ToList();
        }
    }
}
