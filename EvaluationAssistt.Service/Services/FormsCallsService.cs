using System;
using System.Collections.Generic;
using System.Linq;
using EvaluationAssistt.Data.Interface;
using EvaluationAssistt.Domain.Entity;
using EvaluationAssistt.Infrastructure.Helpers;
using EvaluationAssistt.Domain.Dto;

namespace EvaluationAssistt.Service.Services
{
    public class FormsCallsService
    {
        private static IUnitOfWork _unitOfWork;
        private static IRepository<FormsCalls> _formsCallsRepository;
        private static IRepository<FormsCallsEvaluated> _formsCallsEvaluatedRepository;
        private static IRepository<CallsEvaluated> _callsEvaluatedRepository;
        private static IRepository<Agents> _agentRepository;


        public FormsCallsService()
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = UnityHelper.Container.Resolve<IUnitOfWork>();
            }
            if (_formsCallsRepository == null)
            {
                _formsCallsRepository = _unitOfWork.FormsCalls;
            }
            if (_formsCallsEvaluatedRepository == null)
            {
                _formsCallsEvaluatedRepository = _unitOfWork.FormsCallsEvaluated;
            }
            if (_callsEvaluatedRepository == null)
            {
                _callsEvaluatedRepository = _unitOfWork.CallsEvaluated;
            }
            if (_agentRepository == null)
            {
                _agentRepository = _unitOfWork.Agents;
            }
        }

        public IQueryable<FormsCallsDto> GetCallsEvaluatedByTeams(List<int> teams, int? minScore, int? maxScore, bool evaluationtype, int userId)
        {
            if (evaluationtype)
            {
                var result = _formsCallsRepository.Find(x => x.EvaluatorId == userId && x.Score >= minScore && x.Score <= maxScore)
                                .Select(x => new FormsCallsDto()
                                {
                                    Id = x.Id,
                                    FormID = x.FormId,
                                    FormName = x.FormName,
                                    CallId = x.CallId,
                                    CallDate = x.DateStarted,
                                    AgentId = x.AgentId,
                                    AgentName = x.FirstName + " " + x.LastName,
                                    EvaluatorId = x.EvaluatorId,
                                    EvaluatorName = x.EvaluatorFirstName + " " + x.EvaluatorLastName,
                                    Score = x.Score,
                                    EvaluationDate = x.Date
                                });

                return result;
            }
            else
            {
                var result = _formsCallsRepository.Find(x => x.Score >= minScore && x.Score <= maxScore)
                               .Select(x => new FormsCallsDto()
                               {
                                   Id = x.Id,
                                   FormID = x.FormId,
                                   FormName = x.FormName,
                                   CallId = x.CallId,
                                   CallDate = x.DateStarted,
                                   AgentId = x.AgentId,
                                   AgentName = x.FirstName + " " + x.LastName,
                                   EvaluatorId = x.EvaluatorId,
                                   EvaluatorName = x.EvaluatorFirstName + " " + x.EvaluatorLastName,
                                   Score = x.Score,
                                   EvaluationDate = x.Date
                               });

                return result;
            }
        }

        public IQueryable<FormsCallsDto> GetCallsEvaluatedByTeamsAndDate(List<int> teams, DateTime minDate, DateTime maxDate, int evaluatorId)
        {
            var isAdmin = false;
            if (teams.Count > 0 && teams[0] == 99999)
            {
                isAdmin = true;
            }
            if (isAdmin && evaluatorId == 0)
            {
                var result2 = _formsCallsRepository.Find(x => x.Date <= maxDate && x.Date >= minDate)
                                .Select(x => new FormsCallsDto()
                                {
                                    Id = x.Id,
                                    FormID = x.FormId,
                                    FormName = x.FormName,
                                    CallId = x.CallId,
                                    CallDate = x.DateStarted,
                                    AgentId = x.AgentId,
                                    AgentName = x.FirstName + " " + x.LastName,
                                    EvaluatorId = x.EvaluatorId,
                                    EvaluatorName = x.EvaluatorFirstName + " " + x.EvaluatorLastName,
                                    Score = x.Score,
                                    EvaluationDate = x.Date
                                });


                return result2;
            }
            else
            {
                if (isAdmin && evaluatorId != 0)
                {
                    var result2 = _formsCallsRepository.Find(x => x.EvaluatorId == evaluatorId && x.Date <= maxDate && x.Date >= minDate)
                                .Select(x => new FormsCallsDto()
                                {
                                    Id = x.Id,
                                    FormID = x.FormId,
                                    FormName = x.FormName,
                                    CallId = x.CallId,
                                    CallDate = x.DateStarted,
                                    AgentId = x.AgentId,
                                    AgentName = x.FirstName + " " + x.LastName,
                                    EvaluatorId = x.EvaluatorId,
                                    EvaluatorName = x.EvaluatorFirstName + " " + x.EvaluatorLastName,
                                    Score = x.Score,
                                    EvaluationDate = x.Date
                                });


                    return result2;
                }
            }
            if (evaluatorId == 0)
            {
                var result1 = _formsCallsRepository.Find(x => teams.Contains((int)x.TeamId) && x.Date <= maxDate && x.Date >= minDate)
                                .Select(x => new FormsCallsDto()
                                {
                                    Id = x.Id,
                                    FormID = x.FormId,
                                    FormName = x.FormName,
                                    CallId = x.CallId,
                                    CallDate = x.DateStarted,
                                    AgentId = x.AgentId,
                                    AgentName = x.FirstName + " " + x.LastName,
                                    EvaluatorId = x.EvaluatorId,
                                    EvaluatorName = x.EvaluatorFirstName + " " + x.EvaluatorLastName,
                                    Score = x.Score,
                                    EvaluationDate = x.Date
                                });


                return result1;
            }
            else
            {
                var result3 = _formsCallsRepository.Find(x => x.EvaluatorId == evaluatorId && x.Date <= maxDate && x.Date >= minDate)
                                .Select(x => new FormsCallsDto()
                                {
                                    Id = x.Id,
                                    FormID = x.FormId,
                                    FormName = x.FormName,
                                    CallId = x.CallId,
                                    CallDate = x.DateStarted,
                                    AgentId = x.AgentId,
                                    AgentName = x.FirstName + " " + x.LastName,
                                    EvaluatorId = x.EvaluatorId,
                                    EvaluatorName = x.EvaluatorFirstName + " " + x.EvaluatorLastName,
                                    Score = x.Score,
                                    EvaluationDate = x.Date
                                });


                return result3;
            }
        }

        public IQueryable<FormsCallsDto> GetCallsEvaluatedByAgentIdLast30Days(int agentId)
        {
            var date = DateTime.Now.AddDays(-30);

            var result = _formsCallsRepository.Find(x => x.AgentId == agentId && x.Date >= date)
                            .Select(x => new FormsCallsDto()
                            {
                                Id = x.Id,
                                FormID = x.FormId,
                                FormName = x.FormName,
                                CallId = x.CallId,
                                CallDate = x.Date,
                                EvaluatorId = x.EvaluatorId,
                                EvaluatorName = x.EvaluatorFirstName + " " + x.EvaluatorLastName,
                                Score = x.Score,
                                EvaluationDate = x.Date
                            });

            return result;
        }

        public FormsCallsDto GetCallEvaluated(int callId, int formId, int Fceid)
        {
            FormsCalls entity = null;
            if (Fceid == 0)
            {
                entity = _formsCallsRepository.Find(x => x.CallId == callId && x.FormId == formId).FirstOrDefault();
            }
            else
            {
                entity = _formsCallsRepository.Find(x => x.Id == Fceid).FirstOrDefault();
            }
            var result = new FormsCallsDto()
            { Id = entity.Id,
                EvaluatorName = entity.EvaluatorFirstName + " " + entity.EvaluatorLastName,
                EvaluationDate = entity.Date,
                Score = entity.Score
            };

            return result;
        }

        public string GetFormCallNote(int formCallId)
        {
//            _unitOfWork.Save(_formsCallsEvaluatedRepository.FindSingle(k => k.Id == formCallId));
            var entity = _formsCallsEvaluatedRepository.FindSingle(k => k.Id == formCallId);//_formsCallsRepository.FindById(formCallId);

            var note = entity == null ? String.Empty : entity.AgentNote;

            return note;
        }

        public string GetFormTLNote(int formCallId)
        {
            var entity = _formsCallsEvaluatedRepository.FindById(formCallId);

            var note = entity == null ? String.Empty : entity.TLComment;

            return note;
        }

        public string GetFormISMNote(int formCallId)
        {
            var entity = _formsCallsEvaluatedRepository.FindById(formCallId);

            var note = entity == null ? String.Empty : entity.ISMComment;

            return note;
        }

        public string GetEvaluationNote(int formCallId)
        {
            var entity = _formsCallsRepository.FindById(formCallId);

            var note = entity == null ? String.Empty : entity.EvaluationDetailNote;

            return note;
        }

        public void SaveNote(int callId, int formId, string note)
        {
            var entity = _formsCallsEvaluatedRepository.Find(x => x.CallId == callId && x.FormId == formId).FirstOrDefault();

            if (entity != null)
            {
                entity.CallState = 1;
                entity.AgentNote = note;
                _unitOfWork.Save();
            }
        }

        public void SaveInstantancy(int callId, int formId, string selection, string editedScore, string ISMNote, string TLNote, Dictionary<int, int> answers, int entityformid, int fceid)
        {
            var entity = _formsCallsEvaluatedRepository.Find(x => x.Id == fceid).FirstOrDefault();

            var formCallsEvaluatedAnswers = _callsEvaluatedRepository.Find(x => x.FormCallId == entityformid).ToList();

            foreach (KeyValuePair<int, int> item in answers)
            {
                var ce = formCallsEvaluatedAnswers.Where(k => k.QuestionId == item.Key).FirstOrDefault();
                if (ce != null)
                {
                    ce.AnswerId = item.Value;
                    _unitOfWork.Save();
                }
            }

            if (entity != null)
            {
                entity.CallState = Convert.ToInt32(selection);
                entity.Score = Convert.ToInt32(editedScore);
                entity.ISMComment = ISMNote;
                entity.TLComment = TLNote;
                _unitOfWork.Save();
            }
        }

        public void SetNoteSeen(int callId, int formId)
        {
            var entity = _formsCallsEvaluatedRepository.Find(x => x.CallId == callId && x.FormId == formId).FirstOrDefault();

            if (entity != null)
            {
                entity.AgentNoteSeen = true;
                _unitOfWork.Save();
            }
        }

        public IQueryable<FormsCallsDto> GetCallsEvaluatedWithRemarks(int teamId, int userTypeId, DateTime startDate, DateTime endDate, bool evaluationSearchAuthenticationIsLinked, int userId)
        {
            if (userTypeId == 1)
            {
                return _formsCallsRepository.Find(x => (x.TeamId == teamId || teamId == 0) && !String.IsNullOrEmpty(x.AgentNote) && x.Date >= startDate && x.Date <= endDate)
                                .Select(x => new FormsCallsDto()
                                {
                                    Id = x.Id,
                                    FormID = x.FormId,
                                    FormName = x.FormName,
                                    CallId = x.CallId,
                                    CallDate = x.DateStarted,
                                    EvaluatorId = x.AgentId,
                                    EvaluatorName = x.EvaluatorFirstName + " " + x.EvaluatorLastName,
                                    Score = x.Score,
                                    EvaluationDate = x.Date,
                                    AgentName = x.FirstName + " " + x.LastName,
                                    AgentNoteSeen = x.AgentNoteSeen.HasValue ? (bool)x.AgentNoteSeen : false,
                                    CallState = x.CallState == null ? 0 : (int)x.CallState
                                });
            }
            else
            {
                if (userTypeId == 2)
                {
                    return _formsCallsRepository.Find(x => x.Date >= startDate && x.Date <= endDate && (x.TeamId == teamId || teamId == 0) && !String.IsNullOrEmpty(x.AgentNote) && (x.CallState == 32 || x.CallState == 42 || x.CallState == 51 || x.CallState == 52))
                               .Select(x => new FormsCallsDto()
                               {
                                   Id = x.Id,
                                   FormID = x.FormId,
                                   FormName = x.FormName,
                                   CallId = x.CallId,
                                   CallDate = x.DateStarted,
                                   EvaluatorId = x.AgentId,
                                   EvaluatorName = x.EvaluatorFirstName + " " + x.EvaluatorLastName,
                                   Score = x.Score,
                                   EvaluationDate = x.Date,
                                   AgentName = x.FirstName + " " + x.LastName,
                                   AgentNoteSeen = x.AgentNoteSeen.HasValue ? (bool)x.AgentNoteSeen : false,
                                   CallState = x.CallState == null ? 0 : (int)x.CallState
                               });
                }
                else
                {
                    if (userTypeId == 4)
                    {
                        var qtl = _agentRepository.Find(k => k.AgentTypeId == 2 || k.AgentTypeId == 1 || k.AgentTypeId == 4).Select(m => m.Id).ToList();
                        if (evaluationSearchAuthenticationIsLinked)
                        {
                            var res = _formsCallsRepository.Find(x => x.Date >= startDate && x.Date <= endDate && (x.EvaluatorId == userId || qtl.Contains(x.EvaluatorId)) && !String.IsNullOrEmpty(x.AgentNote) && (x.CallState == null || x.CallState == 0 || x.CallState == 1 || x.CallState == 31 || x.CallState == 32 || x.CallState == 51 || x.CallState == 52 || x.CallState == 41 || x.CallState == 42))
                                   .Select(x => new FormsCallsDto()
                            { Id = x.Id,
                                       FormID = x.FormId,
                                       FormName = x.FormName,
                                       CallId = x.CallId,
                                       CallDate = x.DateStarted,
                                       EvaluatorId = x.AgentId,
                                       EvaluatorName = x.EvaluatorFirstName + " " + x.EvaluatorLastName,
                                       Score = x.Score,
                                       EvaluationDate = x.Date,
                                       AgentName = x.FirstName + " " + x.LastName,
                                       AgentNoteSeen = x.AgentNoteSeen.HasValue ? (bool)x.AgentNoteSeen : false,
                                       CallState = x.CallState == null ? 0 : (int)x.CallState
                            });
                            var mine = _agentRepository.Find(k => k.Id == userId).FirstOrDefault();
                            var myteamIds = _agentRepository.Find(k => k.TeamId == mine.TeamId).Select(m => m.Id).ToList();
                            return res.Where(k => myteamIds.Contains(k.EvaluatorId));
                        }
                        else
                        {
                            return _formsCallsRepository.Find(x => x.Date >= startDate && x.Date <= endDate && (x.TeamId == teamId || teamId == 0) && !String.IsNullOrEmpty(x.AgentNote) && (x.CallState == null || x.CallState == 0 || x.CallState == 1 || x.CallState == 31 || x.CallState == 32 || x.CallState == 51 || x.CallState == 52 || x.CallState == 41 || x.CallState == 42))
                              .Select(x => new FormsCallsDto()
                              {
                                  Id = x.Id,
                                  FormID = x.FormId,
                                  FormName = x.FormName,
                                  CallId = x.CallId,
                                  CallDate = x.DateStarted,
                                  EvaluatorId = x.AgentId,
                                  EvaluatorName = x.EvaluatorFirstName + " " + x.EvaluatorLastName,
                                  Score = x.Score,
                                  EvaluationDate = x.Date,
                                  AgentName = x.FirstName + " " + x.LastName,
                                  AgentNoteSeen = x.AgentNoteSeen.HasValue ? (bool)x.AgentNoteSeen : false,
                                  CallState = x.CallState == null ? 0 : (int)x.CallState
                              });
                        }
                    }
                    else
                    {
                        if (evaluationSearchAuthenticationIsLinked)
                        {
                            return _formsCallsRepository.Find(x => x.Date >= startDate && x.Date <= endDate && x.EvaluatorId == userId && !String.IsNullOrEmpty(x.AgentNote) && (x.CallState == null || x.CallState == 0 || x.CallState == 1 || x.CallState == 31 || x.CallState == 32 || x.CallState == 51 || x.CallState == 52 || x.CallState == 41 || x.CallState == 42))
                               .Select(x => new FormsCallsDto()
                               {
                                   Id = x.Id,
                                   FormID = x.FormId,
                                   FormName = x.FormName,
                                   CallId = x.CallId,
                                   CallDate = x.DateStarted,
                                   EvaluatorId = x.AgentId,
                                   EvaluatorName = x.EvaluatorFirstName + " " + x.EvaluatorLastName,
                                   Score = x.Score,
                                   EvaluationDate = x.Date,
                                   AgentName = x.FirstName + " " + x.LastName,
                                   AgentNoteSeen = x.AgentNoteSeen.HasValue ? (bool)x.AgentNoteSeen : false,
                                   CallState = x.CallState == null ? 0 : (int)x.CallState
                               });
                        }
                        else
                        {
                            return _formsCallsRepository.Find(x => x.Date >= startDate && x.Date <= endDate && (x.TeamId == teamId || teamId == 0) && !String.IsNullOrEmpty(x.AgentNote) && (x.CallState == null || x.CallState == 0 || x.CallState == 1 || x.CallState == 31 || x.CallState == 32 || x.CallState == 51 || x.CallState == 52 || x.CallState == 41 || x.CallState == 42))
                               .Select(x => new FormsCallsDto()
                               {
                                   Id = x.Id,
                                   FormID = x.FormId,
                                   FormName = x.FormName,
                                   CallId = x.CallId,
                                   CallDate = x.DateStarted,
                                   EvaluatorId = x.AgentId,
                                   EvaluatorName = x.EvaluatorFirstName + " " + x.EvaluatorLastName,
                                   Score = x.Score,
                                   EvaluationDate = x.Date,
                                   AgentName = x.FirstName + " " + x.LastName,
                                   AgentNoteSeen = x.AgentNoteSeen.HasValue ? (bool)x.AgentNoteSeen : false,
                                   CallState = x.CallState == null ? 0 : (int)x.CallState
                               });
                        }
                    }
                }
            }
        }

        public void DeleteEvaluation(int id)
        {
            var entity = _unitOfWork.FormsCallsEvaluated.Find(k => k.CallId == id).FirstOrDefault();

            _formsCallsEvaluatedRepository.Delete(entity, true);

            _unitOfWork.Save();
        }
    }
}
