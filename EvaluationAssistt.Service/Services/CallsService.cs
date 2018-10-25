using System;
using System.Collections.Generic;
using System.Linq;
using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Data.Interface;
using EvaluationAssistt.Domain.Entity;
using EvaluationAssistt.Infrastructure.Helpers;
using EvaluationAssistt.Data.Repository.EFRepository.ExtendedRepository;

namespace EvaluationAssistt.Service.Services
{
    public class CallsService
    {
        private static IUnitOfWork _unitOfWork;
        private static IRepository<CallsTemporary> _callsRepository;
        private static IRepository<Agents> _agentsRepository;
        private static CallsRepository _callsRepositoryCustom;
        private static IRepository<FormsCallsEvaluated> _formsCallsEvaluatedRepository;

        public CallsService()
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = UnityHelper.Container.Resolve<IUnitOfWork>();
            }
            if (_callsRepository == null)
            {
                _callsRepository = _unitOfWork.Calls;
            }
            if (_agentsRepository == null)
            {
                _agentsRepository = _unitOfWork.Agents;
            }
            if (_callsRepositoryCustom == null)
            {
                _callsRepositoryCustom = new CallsRepository();
            }
            if (_formsCallsEvaluatedRepository == null)
            {
                _formsCallsEvaluatedRepository = _unitOfWork.FormsCallsEvaluated;
            }
        }

        public IQueryable<CallsDto> CallsRandom(DateTime startDate, int randomCallCount)
        {
            var list = new List<CallsTemporary>();
            var agentIds = _callsRepository.Find(k => k.DateStarted >= startDate).Select(m => m.AgentId).Distinct().ToList();
            foreach (int agentId in agentIds)
            {
                var rnd = new Random();
                list.AddRange(_callsRepository.Find(k => k.DateStarted >= startDate && k.AgentId == agentId).ToList().OrderBy(m => rnd.Next()).Take(randomCallCount).ToList());
            }

            var result = list.Select(x => new CallsDto()
            {
                Id = x.Id,
                FileName = x.FileName,
                AgentId = x.AgentId,
                AgentName = x.FirstName + " " + x.LastName,
                LoginID = x.LoginId,
                LocationName = x.LocationName,
                IpPhone = x.IpPhone,
                GloballyUniqueCallLinkageID = x.GloballyUniqueCallLinkageID,
                AnsweringDeviceId = x.AnsweringDeviceId,
                CallingDeviceId = x.CallingDeviceId,
                CalledDeviceId = x.CalledDeviceId,
                Duration = x.Duration,
                VdnName = x.VdnName,
                VdnExtension = x.VdnExtension,
                DateStarted = x.DateStarted,
                AcdGroup = x.AcdGroup,
                IsIncoming = x.IsIncoming

            }).AsQueryable();

            return result.AsQueryable();
        }

        public IQueryable<CallsDto> GetCalls(List<int> teamIds, int? agentId, int minDuration, int maxDuration, DateTime? minDate, DateTime? maxDate,
            string callingDeviceId, string remark, string ucid, string locName, int groupId, int teamId, int assistantId,
            int minDur, int maxDur, string callingPhone, int userId, bool CallResultShowTypeId, string scillNo, string loginId)
        {
            if (agentId != null)
            {
                Convert.ToInt32(agentId);
                var agnt = _agentsRepository.Find(k => k.Id == agentId).FirstOrDefault();
                if (agnt != null)
                {
                    loginId = agnt.LoginId;
                }
            }

            IQueryable<CallsTemporary> list = null;
            if (!CallResultShowTypeId)
            {
                if (!string.IsNullOrEmpty(scillNo))
                {
                    var agent = _agentsRepository.Find(k => k.RegisterNumber == scillNo).FirstOrDefault();
                    list = _callsRepository.Find(x => x.Duration >= minDuration && x.Duration <= maxDuration
                    && x.DateStarted > minDate && x.DateStarted < maxDate && x.AgentId == agent.Id).OrderByDescending(m => m.Id).Take(5000);
                }
                else
                {
                    if (!string.IsNullOrEmpty(loginId))
                    {
                        var agent = _agentsRepository.Find(k => k.LoginId == loginId).FirstOrDefault();
                        list = _callsRepository.Find(x => x.Duration >= minDuration && x.Duration <= maxDuration
                        && x.DateStarted > minDate && x.DateStarted < maxDate
                        && x.AgentId == agent.Id).OrderByDescending(m => m.Id).Take(5000);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(ucid))
                        {
                            list = _callsRepository.Find(x => x.Duration >= minDuration && x.Duration <= maxDuration
                            && x.DateStarted > minDate && x.DateStarted < maxDate
                            && x.GloballyUniqueCallLinkageID == ucid).OrderByDescending(m => m.Id).Take(5000);
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(callingPhone))
                            {
                                list = _callsRepository.Find(x => x.Duration >= minDuration && x.Duration <= maxDuration
                                && x.DateStarted > minDate && x.DateStarted < maxDate
                                && x.CallingDeviceId == callingPhone).OrderByDescending(m => m.Id).Take(5000);
                            }
                            else
                            {
                                list = _callsRepository.Find(x => x.Duration >= minDuration && x.Duration <= maxDuration
                                && x.DateStarted > minDate && x.DateStarted < maxDate
                                && (x.CallingDeviceId == callingPhone || 1 == 1)
                                && (x.Remark == remark || 1 == 1)
                                && (x.GloballyUniqueCallLinkageID == ucid || 1 == 1)
                                && (x.LocationName == locName)).OrderByDescending(m => m.Id).Take(5000);
                            }
                        }
                    }
                }
            }
            else
            {
                var agentIds = new List<Int32>();
                if (assistantId != 0)
                {
                    agentIds.Add(assistantId);
                }
                else
                {
                    agentIds = _agentsRepository.Find(x => teamIds.Contains((int)x.TeamId)).Select(x => x.Id).ToList();
                }
                if (!string.IsNullOrEmpty(scillNo))
                {
                    var agent = _agentsRepository.Find(k => k.RegisterNumber == scillNo).FirstOrDefault();
                    list = _callsRepository.Find(x => x.Duration >= minDuration && x.Duration <= maxDuration
                    && x.DateStarted > minDate && x.DateStarted < maxDate && x.AgentId == agent.Id).OrderByDescending(m => m.Id).Take(5000);
                }
                else
                {
                    if (!string.IsNullOrEmpty(loginId))
                    {
                        var agent = _agentsRepository.Find(k => k.LoginId == loginId).FirstOrDefault();
                        list = _callsRepository.Find(x => x.Duration >= minDuration && x.Duration <= maxDuration
                        && x.DateStarted > minDate && x.DateStarted < maxDate
                        && x.AgentId == agent.Id).OrderByDescending(m => m.Id).Take(5000);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(ucid))
                        {
                            list = _callsRepository.Find(x => agentIds.Contains(x.AgentId) && x.Duration >= minDuration && x.Duration <= maxDuration
                            && x.DateStarted > minDate && x.DateStarted < maxDate
                            && (x.GloballyUniqueCallLinkageID == ucid)).OrderByDescending(m => m.Id).Take(5000);
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(callingPhone))
                            {
                                list = _callsRepository.Find(x => agentIds.Contains(x.AgentId) && x.Duration >= minDuration && x.Duration <= maxDuration
                                && x.DateStarted > minDate && x.DateStarted < maxDate
                                && (x.CallingDeviceId == callingPhone)).OrderByDescending(m => m.Id).Take(5000);
                            }
                            else
                            {
                                if (locName.Trim() == string.Empty)
                                {
                                    list = _callsRepository.Find(x => agentIds.Contains(x.AgentId) && x.Duration >= minDuration && x.Duration <= maxDuration
                                    && x.DateStarted > minDate && x.DateStarted < maxDate
                                    && (x.CallingDeviceId == callingPhone || 1 == 1)
                                    && (x.Remark == remark || 1 == 1)
                                    && (x.GloballyUniqueCallLinkageID == ucid || 1 == 1)).OrderByDescending(m => m.Id).Take(5000);
                                }
                                else
                                {
                                    list = _callsRepository.Find(x => agentIds.Contains(x.AgentId) && x.Duration >= minDuration && x.Duration <= maxDuration
                                    && x.DateStarted > minDate && x.DateStarted < maxDate
                                    && (x.CallingDeviceId == callingPhone || 1 == 1)
                                    && (x.Remark == remark || 1 == 1)
                                    && (x.GloballyUniqueCallLinkageID == ucid || 1 == 1)
                                    && (x.LocationName == locName)).OrderByDescending(m => m.Id).Take(5000);
                                }
                            }
                        }
                    }
                }
            }

            var extractedCalls = new List<CallsTemporary>();
            var evaluatedCallIds = _formsCallsEvaluatedRepository.Find(k => k.Date > minDate && k.Date < maxDate).Select(m => m.CallId).ToList();
            extractedCalls = list.Where(k => !evaluatedCallIds.Contains(k.Id)).ToList();

            var result = extractedCalls.Select(x => new CallsDto()
              {
                  Id = x.Id,
                  FileName = x.FileName,
                  AgentId = x.AgentId,
                  AgentName = x.FirstName + " " + x.LastName,
                  LoginID = x.LoginId,
                  LocationName = x.LocationName,
                  IpPhone = x.IpPhone,
                  GloballyUniqueCallLinkageID = x.GloballyUniqueCallLinkageID,
                  AnsweringDeviceId = x.AnsweringDeviceId,
                  CallingDeviceId = x.CallingDeviceId,
                  CalledDeviceId = x.CalledDeviceId,
                  Duration = x.Duration,
                  VdnName = x.VdnName,
                  VdnExtension = x.VdnExtension,
                  DateStarted = x.DateStarted,
                  AcdGroup = x.AcdGroup,
                  IsIncoming = x.IsIncoming

              }).AsQueryable();


            return result.OrderByDescending(k => k.Id).AsQueryable();
        }

        public CallsDto GetCallById(int callId)
        {
            var entity = _callsRepository.FindById(callId);

            var result = new CallsDto()
            { Id = entity.Id,
                AgentId = entity.AgentId,
                AgentName = entity.FirstName + " " + entity.LastName,
                CallingDeviceId = entity.CallingDeviceId,
                Duration = entity.Duration,
                FileName = entity.FileName,
                LoginID = entity.LoginId,
                VdnName = entity.VdnName,
                VdnExtension = entity.VdnExtension,
                DateStarted = entity.DateStarted,
                Marked = entity.Marked,
                CalledDeviceId = entity.CalledDeviceId,
                IsIncoming = entity.IsIncoming
            };

            return result;
        }

        public IQueryable<CallsDto> GetCallsByAgentIdForThisMonth(int? agentId)
        {
            var loginId = _agentsRepository.Find(x => x.Id == agentId).Select(x => x.LoginId).FirstOrDefault();

            var result = _callsRepository.Find(x => x.AgentId == agentId && x.LoginId == loginId
                && (x.DateStarted.Value.Year == DateTime.Now.Year && x.DateStarted.Value.Month == DateTime.Now.Month)
                && (x.Duration >= 1000 && x.Duration <= 1800000))
                .Select(x => new CallsDto()
                {
                    Id = x.Id,
                    FileName = x.FileName,
                    AgentId = x.AgentId,
                    AgentName = x.FirstName + " " + x.LastName,
                    LoginID = x.LoginId,
                    CallingDeviceId = x.CallingDeviceId,
                    Duration = x.Duration,
                    VdnName = x.VdnName,
                    VdnExtension = x.VdnExtension,
                    DateStarted = x.DateStarted
                });

            return result;
        }

        public Tuple<int, int?> GetCallSummary(int agentId, DateTime dateMin, DateTime dateMax)
        {
            var list = _callsRepository.Find(x => x.AgentId == agentId && (x.DateStarted >= dateMin && x.DateStarted <= dateMax));

            var count = list.Count();

            var averageDuration = list.Sum(x => (long?)x.Duration);
            var duration = Convert.ToInt32(averageDuration / 1000.0 / count);

            var summary = new Tuple<int, int?>(count, duration);

            return summary;
        }

        public IQueryable<ufnCallSummaries_Result> GetTeamCallSummary(int teamId, DateTime dateMin, DateTime dateMax)
        {
            return _callsRepositoryCustom.TeamCallSummary(teamId, dateMin, dateMax);
        }

        public IQueryable<ufnCallEvaluatedSummaries_Result> GetTeamCallEvaluatedSummary(int teamId, DateTime dateMin, DateTime dateMax)
        {
            return _callsRepositoryCustom.TeamCallEvaluatedSummary(teamId, dateMin, dateMax);
        }

        public IQueryable<ufnCallEvaluatedTeamLeaderSummaries_Result> GetTeamLeaderCallEvaluatedSummary(int agentId, DateTime dateMin, DateTime dateMax)
        {
            return _callsRepositoryCustom.GetTeamLeaderCallEvaluatedSummary(agentId, dateMin, dateMax);
        }

        public string GetFileNameById(int callId)
        {
            var entity = _callsRepository.Find(x => x.Id == callId).FirstOrDefault();

            if (entity == null)
            {
                return String.Empty;
            }
            return entity.FileName;
        }

        public IQueryable<ufnCallTeamSummaries_Result> GetGroupCallSummary(int groupId, DateTime dateMin, DateTime dateMax)
        {
            return _callsRepositoryCustom.GetGroupCallSummary(groupId, dateMin, dateMax);
        }

        public void MarkForm(bool marked, string callId)
        {
            var call = int.Parse(callId);
            var entity = _callsRepository.Find(x => x.Id == call).FirstOrDefault();
            entity.Marked = marked;
            _unitOfWork.Save();
        }
    }
}
