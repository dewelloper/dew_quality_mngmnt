using EvaluationAssistt.Data.Interface;
using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Domain.Entity;
using EvaluationAssistt.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EvaluationAssistt.Service.Services
{
    public class EvaluationReportingService
    {
        private static IUnitOfWork _unitOfWork;
        private static IRepository<Agents> _agentsRepository;
        private static IRepository<AgentTypes> _agentTypesRepository;
        private static IRepository<Teams> _teamsRepository;
        private static IRepository<Groups> _groupsRepository;
        private static IRepository<FormsCallsEvaluated> _formsCallsEvaluatedRepository;
        private static IRepository<CallsTemporary> _callsRepository;
        private static IRepository<FormsCalls> _formsCallsRepository;
        private static IRepository<CallsEvaluated> _callsEvaluatedRepository;
        private static IRepository<Answers> _answerRepository;
        private static IRepository<Questions> _questionRepository;
        private static IRepository<Forms> _formsRepository;
        private static IRepository<FormsSections> _formsSectionsRepository;
        private static IRepository<SectionsCategories> _sectionsCategoriesRepository;
        private static IRepository<Categories> _categoriesRepository;
        private static IRepository<Sections> _sectionsRepository;
        private static IRepository<CategoriesQuestions> _categoriesQuestionsRepository;
        private static IRepository<Answers> _answersRepository;
        private static IRepository<EvaluatedDetailView> _evaluatedDetailRepository;
        private static IRepository<DetailFormView> _detailFormRepository;
        private static string[] _months = { "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık" };

        public EvaluationReportingService()
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = UnityHelper.Container.Resolve<IUnitOfWork>();
            }
            if (_agentsRepository == null)
            {
                _agentsRepository = _unitOfWork.Agents;
            }
            if (_agentTypesRepository == null)
            {
                _agentTypesRepository = _unitOfWork.AgentTypes;
            }
            if (_teamsRepository == null)
            {
                _teamsRepository = _unitOfWork.Teams;
            }
            if (_groupsRepository == null)
            {
                _groupsRepository = _unitOfWork.Groups;
            }
            if (_formsCallsEvaluatedRepository == null)
            {
                _formsCallsEvaluatedRepository = _unitOfWork.FormsCallsEvaluated;
            }
            if (_callsRepository == null)
            {
                _callsRepository = _unitOfWork.Calls;
            }
            if (_formsCallsRepository == null)
            {
                _formsCallsRepository = _unitOfWork.FormsCalls;
            }
            if (_callsEvaluatedRepository == null)
            {
                _callsEvaluatedRepository = _unitOfWork.CallsEvaluated;
            }
            if (_answerRepository == null)
            {
                _answerRepository = _unitOfWork.Answers;
            }
            if (_questionRepository == null)
            {
                _questionRepository = _unitOfWork.Questions;
            }
            if (_formsRepository == null)
            {
                _formsRepository = _unitOfWork.Forms;
            }
            if (_formsSectionsRepository == null)
            {
                _formsSectionsRepository = _unitOfWork.FormsSections;
            }
            if (_sectionsCategoriesRepository == null)
            {
                _sectionsCategoriesRepository = _unitOfWork.SectionsCategories;
            }
            if (_categoriesRepository == null)
            {
                _categoriesRepository = _unitOfWork.Categories;
            }
            if (_sectionsRepository == null)
            {
                _sectionsRepository = _unitOfWork.Sections;
            }
            if (_categoriesQuestionsRepository == null)
            {
                _categoriesQuestionsRepository = _unitOfWork.CategoriesQuestions;
            }
            if (_answersRepository == null)
            {
                _answersRepository = _unitOfWork.Answers;
            }
            if (_evaluatedDetailRepository == null)
            {
                _evaluatedDetailRepository = _unitOfWork.EvaluatedDetailView;
            }
            if (_detailFormRepository == null)
            {
                _detailFormRepository = _unitOfWork.DetailFormView;
            }
        }

        public IQueryable<FormsCallsDto> GetFormCallsByFilter(DateTime startDate, DateTime endDate, Int32 startRecord, Int32 maxRecords, String sortColumns, string reporterId, bool isAdmQ)
        {
            var fresult = new List<FormsCallsDto>();
            if (startDate.ToString().Contains("0001"))
            {
                return fresult.AsQueryable();
            }

            if (reporterId == "9999999")
            {
                if (isAdmQ)
                {
                    var aqEvaluater = _agentsRepository.Find(k => k.AgentTypeId == 1 || k.AgentTypeId == 2).Select(m => m.Id).ToList();
                    var efc = _formsCallsRepository.Find(k => k.Date >= startDate && k.Date <= endDate && aqEvaluater.Contains(k.EvaluatorId))
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
                                    EvaluationDate = x.Date,
                                    Duration = x.Duration / 1000,
                                    IsmComment = x.ISMComment,
                                    TLComment = x.TLComment,
                                    EvaluationDetailNote = x.EvaluationDetailNote,
                                    CallState = x.CallState
                                });
                    return UpdateCallsDto(efc);
                }

                var efc2 = _formsCallsRepository.Find(k => k.Date >= startDate && k.Date <= endDate)
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
                                    EvaluationDate = x.Date,
                                    Duration = x.Duration / 1000,
                                    IsmComment = x.ISMComment,
                                    TLComment = x.TLComment,
                                    EvaluationDetailNote = x.EvaluationDetailNote,
                                    CallState = x.CallState
                                });
                return UpdateCallsDto(efc2);
            }
            else
            {
                var repId = Convert.ToInt32(reporterId);
                var teamId = _agentsRepository.Find(k => k.Id == repId).Select(m => m.TeamId).FirstOrDefault();

                if (teamId != null)
                {
                    if (isAdmQ)
                    {
                        var aqEvaluater = _agentsRepository.Find(k => k.AgentTypeId == 1 || k.AgentTypeId == 2).Select(m => m.Id).ToList();
                        var efc = _formsCallsRepository.Find(k => k.Date >= startDate && k.Date <= endDate && k.EvaluatorId == repId && aqEvaluater.Contains(k.EvaluatorId))
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
                                            EvaluationDate = x.Date,
                                            Duration = x.Duration / 1000,
                                            IsmComment = x.ISMComment,
                                            TLComment = x.TLComment,
                                            EvaluationDetailNote = x.EvaluationDetailNote,
                                            CallState = x.CallState
                                        });
                        return UpdateCallsDto(efc);
                    }

                    _agentsRepository.Find(k => k.TeamId == teamId).Select(m => m.Id).ToList();

                    var efc2 = _formsCallsRepository.Find(k => k.Date >= startDate && k.Date <= endDate && k.EvaluatorId == repId)
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
                                        EvaluationDate = x.Date,
                                        Duration = x.Duration / 1000,
                                        IsmComment = x.ISMComment,
                                        TLComment = x.TLComment,
                                        EvaluationDetailNote = x.EvaluationDetailNote,
                                        CallState = x.CallState
                                    });
                    return UpdateCallsDto(efc2);
                }
                else
                {
                    return null;
                }
            }
        }

        public IQueryable<FormsCallsDto> UpdateCallsDto(IQueryable<FormsCallsDto> calls)
        {
            var yy = new List<FormsCallsDto>();
            foreach (FormsCallsDto fcd in calls)
            {
                var ct = _callsRepository.Find(k => k.Id == fcd.CallId).FirstOrDefault();
                if (ct != null)
                {
                    if (ct.IsIncoming != null && ct.IsIncoming.ToString().Trim() == "IN")
                    {
                        fcd.CalledNumber = ct.CallingDeviceId.ToString();
                    }
                    else
                    {
                        fcd.CalledNumber = ct.CalledDeviceId.ToString();
                    }
                    fcd.CalledDate = ct.DateStarted;
                    fcd.AgentId = Convert.ToInt32(ct.IpPhone.ToString().Trim() == string.Empty ? "0" : ct.IpPhone.ToString());

                    if (fcd.CallState == 61 || fcd.CallState == 62 || fcd.CallState == 51 || fcd.CallState == 52 || fcd.CallState == 41 || fcd.CallState == 42)
                    {
                        fcd.Note = fcd.IsmComment;
                    }
                    else
                    {
                        if (fcd.CallState == 31 || fcd.CallState == 32 || fcd.CallState == 21 || fcd.CallState == 22)
                        {
                            fcd.Note = fcd.TLComment;
                        }
                        else
                        {
                            if (fcd.CallState == 1)
                            {
                                fcd.Note = fcd.AgentNote;
                            }
                            else
                            {
                                fcd.Note = fcd.EvaluationDetailNote;
                            }
                        }
                    }
                    yy.Add(fcd);
                }
            }

            return yy.OrderByDescending(k => k.Id).AsQueryable();
        }

        public IQueryable<CallsOfAgentDto> GetSpecifiedCall(int formId)
        {
            var fce = _formsCallsEvaluatedRepository.Find(k => k.Id == formId).FirstOrDefault();

            var note = string.Empty;
            if (fce.CallState == 61 || fce.CallState == 62 || fce.CallState == 51 || fce.CallState == 52 || fce.CallState == 41 || fce.CallState == 42)
            {
                note = fce.ISMComment;
            }
            else
            {
                if (fce.CallState == 31 || fce.CallState == 32 || fce.CallState == 21 || fce.CallState == 22)
                {
                    note = fce.TLComment;
                }
                else
                {
                    if (fce.CallState == 1)
                    {
                        note = fce.AgentNote;
                    }
                    else
                    {
                        note = fce.EvaluationDetailNote;
                    }
                }
            }
            var ces = _callsEvaluatedRepository.Find(k => k.FormCallId == formId).ToList();

            var result = new List<CallsOfAgentDto>();
            var index = 1;
            foreach (CallsEvaluated ce in ces)
            {
                var answer = _answerRepository.Find(k => k.Id == ce.AnswerId).FirstOrDefault();
                var question = _questionRepository.Find(k => k.Id == ce.QuestionId).FirstOrDefault();
                var callTemp = _callsRepository.Find(k => k.Id == fce.CallId).FirstOrDefault();
                var agent = _agentsRepository.Find(k => k.Id == callTemp.AgentId).FirstOrDefault();

                var phoneNumber = string.Empty;
                if (callTemp.IsIncoming == "IN")
                {
                    phoneNumber = callTemp.CallingDeviceId;
                }
                else
                {
                    phoneNumber = callTemp.CalledDeviceId;
                }
                result.Add(new CallsOfAgentDto()
                            {
                                Id = index++,
                                FormId = fce.FormId,
                                TotalScore = fce.Score,
                                Question = question.QuestionText,
                                Score = answer.Score,
                                ResultNote = note,
                                CallId = fce.CallId.ToString(),
                                Date = callTemp.DateStarted == null ? string.Empty : Convert.ToString(callTemp.DateStarted),
                                Phone = phoneNumber,
                                AgentName = agent.FirstName + " " + agent.LastName
                            });
            }

            return result.AsQueryable();
        }

        public IQueryable<TeamCallsDto> GetTeamCallsByFilter(DateTime startDate, DateTime endDate, Int32 startRecord, Int32 maxRecords, String sortColumns, string reporterId, bool isAdmQ)
        {
            var resultq = new List<TeamCallsDto>();
            if (startDate.ToString().Contains("0001"))
            {
                return resultq.AsQueryable();
            }


            IQueryable<TeamCallsDto> result = null;

            var cresult = new List<TeamCallsDto>();

            if (reporterId == "9999999")
            {
                if (isAdmQ)
                {
                    var aqEvaluater = _agentsRepository.Find(k => k.AgentTypeId == 1 || k.AgentTypeId == 2).Select(m => m.Id).ToList();
                    var efc = _formsCallsRepository.Find(k => k.Date >= startDate && k.Date <= endDate && aqEvaluater.Contains(k.EvaluatorId))
                                    .GroupBy(k => k.AgentId)
                                    .Select(x => new TeamCallsDto()
                                    {
                                        AgentId = x.Max(p => p.AgentId),
                                        AvarageScore = Math.Round(x.Average(p => p.Score), 2),
                                        CallCount = x.Count(),
                                        TotalScore = x.Sum(p => p.Score),
                                        AgentName = x.Select(p => p.FirstName).FirstOrDefault() + " " + x.Select(p => p.LastName).FirstOrDefault()
                                    });
                    result = efc;
                }
                else
                {
                    var efc = _formsCallsRepository.Find(k => k.Date >= startDate && k.Date <= endDate)
                                    .GroupBy(k => k.AgentId)
                                    .Select(x => new TeamCallsDto()
                                    {
                                        AgentId = x.Max(p => p.AgentId),
                                        AvarageScore = Math.Round(x.Average(p => p.Score), 2),
                                        CallCount = x.Count(),
                                        TotalScore = x.Sum(p => p.Score),
                                        AgentName = x.Select(p => p.FirstName).FirstOrDefault() + " " + x.Select(p => p.LastName).FirstOrDefault()
                                    });
                    result = efc;
                }
            }
            else
            {
                var repId = Convert.ToInt32(reporterId);
                var teamId = _agentsRepository.Find(k => k.Id == repId).Select(m => m.TeamId).FirstOrDefault();

                if (teamId != null)
                {
                    var agType = _agentsRepository.Find(k => k.Id == repId).FirstOrDefault();
                    if (agType.AgentTypeId == 1 || agType.AgentTypeId == 2)
                    {
                        _agentsRepository.Find(k => k.TeamId == teamId).Select(m => m.Id).ToList();
                        if (isAdmQ)
                        {
                            var aqEvaluater = _agentsRepository.Find(k => k.AgentTypeId == 1 || k.AgentTypeId == 2).Select(m => m.Id).ToList();
                            var efc = _formsCallsRepository.Find(k => k.Date >= startDate && k.Date <= endDate && aqEvaluater.Contains(k.EvaluatorId))
                                           .GroupBy(k => k.AgentId)
                                           .Select(x => new TeamCallsDto()
                                           {
                                               AgentId = x.Max(p => p.AgentId),
                                               AvarageScore = Math.Round(x.Average(p => p.Score), 2),
                                               CallCount = x.Count(),
                                               TotalScore = x.Sum(p => p.Score),
                                               AgentName = x.Select(p => p.FirstName).FirstOrDefault() + " " + x.Select(p => p.LastName).FirstOrDefault()
                                           });
                            result = efc;
                        }
                        else
                        {
                            var efc = _formsCallsRepository.Find(k => k.Date >= startDate && k.Date <= endDate)
                                           .GroupBy(k => k.AgentId)
                                           .Select(x => new TeamCallsDto()
                                           {
                                               AgentId = x.Max(p => p.AgentId),
                                               AvarageScore = Math.Round(x.Average(p => p.Score), 2),
                                               CallCount = x.Count(),
                                               TotalScore = x.Sum(p => p.Score),
                                               AgentName = x.Select(p => p.FirstName).FirstOrDefault() + " " + x.Select(p => p.LastName).FirstOrDefault()
                                           });
                            result = efc;
                        }
                    }
                    else
                    {
                        _agentsRepository.Find(k => k.TeamId == teamId).Select(m => m.Id).ToList();

                        if (isAdmQ)
                        {
                            var aqEvaluater = _agentsRepository.Find(k => k.AgentTypeId == 1 || k.AgentTypeId == 2).Select(m => m.Id).ToList();
                            var efc = _formsCallsRepository.Find(k => k.Date >= startDate && k.Date <= endDate && k.EvaluatorId == repId && aqEvaluater.Contains(k.EvaluatorId))
                                           .GroupBy(k => k.AgentId)
                                           .Select(x => new TeamCallsDto()
                                           {
                                               AgentId = x.Max(p => p.AgentId),
                                               AvarageScore = Math.Round(x.Average(p => p.Score), 2),
                                               CallCount = x.Count(),
                                               TotalScore = x.Sum(p => p.Score),
                                               AgentName = x.Select(p => p.FirstName).FirstOrDefault() + " " + x.Select(p => p.LastName).FirstOrDefault()
                                           });
                            result = efc;
                        }
                        else
                        {
                            var efc = _formsCallsRepository.Find(k => k.Date >= startDate && k.Date <= endDate && k.EvaluatorId == repId)
                                           .GroupBy(k => k.AgentId)
                                           .Select(x => new TeamCallsDto()
                                           {
                                               AgentId = x.Max(p => p.AgentId),
                                               AvarageScore = Math.Round(x.Average(p => p.Score), 2),
                                               CallCount = x.Count(),
                                               TotalScore = x.Sum(p => p.Score),
                                               AgentName = x.Select(p => p.FirstName).FirstOrDefault() + " " + x.Select(p => p.LastName).FirstOrDefault()
                                           });
                            result = efc;
                        }
                    }
                }
            }

            if (result != null)
            {
                result.ToList();
                foreach (TeamCallsDto tcd in result)
                {
                    var agent = _agentsRepository.Find(k => k.Id == tcd.AgentId).FirstOrDefault();
                    if (agent != null)
                    {
                        tcd.AgentIdIP = agent.IpPhone;
                        cresult.Add(tcd);
                    }
                }
            }

            return cresult.AsQueryable();
        }

        public int GetFormCount(DateTime startDate, DateTime endDate)
        {
            if (startDate.ToString().Contains("0001"))
            {
                startDate = DateTime.Now.AddDays(-30);
                endDate = DateTime.Now;
            }
            var count = _formsCallsRepository.Find(k => k.Date >= startDate && k.Date <= endDate).Count();
            return count;
        }

        public IQueryable<QAnswerPerPercentDto> GetAnswerPerPercentsByFilter(DateTime startDate, DateTime endDate, Int32 startRecord, Int32 maxRecords, String sortColumns, string reporterId, string selectedAgentId, string formId, bool isAdmQ)
        {
            var qresult = new List<QAnswerPerPercentDto>();

            if (formId == null)
            {
                return qresult.AsQueryable();
            }
            if (startDate.ToString().Contains("0001"))
            {
                startDate = DateTime.Now.AddDays(-30);
                endDate = DateTime.Now;
            }

            var selAgentId = Convert.ToInt32(selectedAgentId == null ? "0" : selectedAgentId);
            var frmId = Convert.ToInt32(formId == null ? "0" : formId);
            var fceIds = new List<int>();

            if (isAdmQ)
            {
                var aqEvaluater = _agentsRepository.Find(k => k.AgentTypeId == 1 || k.AgentTypeId == 2).Select(m => m.Id).ToList();
                if (selAgentId != 0 && frmId != 0)
                {
                    fceIds = _formsCallsRepository.Find(k => k.Date >= startDate && k.Date <= endDate && k.AgentId == selAgentId && k.FormId == frmId && aqEvaluater.Contains(k.EvaluatorId)).Select(i => i.Id).ToList();
                }
                else
                {
                    if (selAgentId != 0)
                    {
                        fceIds = _formsCallsRepository.Find(k => k.Date >= startDate && k.Date <= endDate && k.AgentId == selAgentId && aqEvaluater.Contains(k.EvaluatorId)).Select(i => i.Id).ToList();
                    }
                    else
                    {
                        if (frmId != 0)
                        {
                            fceIds = _formsCallsRepository.Find(k => k.Date >= startDate && k.Date <= endDate && k.FormId == frmId && aqEvaluater.Contains(k.EvaluatorId)).Select(i => i.Id).ToList();
                        }
                        else
                        {
                            fceIds = _formsCallsRepository.Find(k => k.Date >= startDate && k.Date <= endDate && aqEvaluater.Contains(k.EvaluatorId)).Select(i => i.Id).ToList();
                        }
                    }
                }
            }
            else
            {
                if (selAgentId != 0 && frmId != 0)
                {
                    fceIds = _formsCallsRepository.Find(k => k.Date >= startDate && k.Date <= endDate && k.AgentId == selAgentId && k.FormId == frmId).Select(i => i.Id).ToList();
                }
                else
                {
                    if (selAgentId != 0)
                    {
                        fceIds = _formsCallsRepository.Find(k => k.Date >= startDate && k.Date <= endDate && k.AgentId == selAgentId).Select(i => i.Id).ToList();
                    }
                    else
                    {
                        if (frmId != 0)
                        {
                            fceIds = _formsCallsRepository.Find(k => k.Date >= startDate && k.Date <= endDate && k.FormId == frmId).Select(i => i.Id).ToList();
                        }
                        else
                        {
                            fceIds = _formsCallsRepository.Find(k => k.Date >= startDate && k.Date <= endDate).Select(i => i.Id).ToList();
                        }
                    }
                }
            }

            var ces = _callsEvaluatedRepository.Find(k => fceIds.Contains(k.FormCallId)).ToList();
            var ces2 = ces.ToList();
            var groupedCes = ces.GroupBy(k => k.QuestionId).ToList();

            var questionsAnswersTemplateContainer = new List<QAnswerPerPercentDto>();
            foreach (var groupItem in groupedCes)
            {
                var qId = groupItem.Key;
                CallsEvaluated cev = null;
                foreach (var gi in groupItem)
                {
                    cev = (CallsEvaluated)gi;
                }
                var fcev = _formsCallsEvaluatedRepository.Find(k => k.Id == cev.FormCallId).FirstOrDefault();
                var ct = _callsRepository.Find(k => k.Id == fcev.CallId).FirstOrDefault();
                var agentId = ct.AgentId;
                var agnt = _agentsRepository.Find(k => k.Id == agentId).FirstOrDefault();
                var agentName = agnt.FirstName + " " + agnt.LastName;
                var frm = _formsRepository.Find(k => k.Id == fcev.FormId).FirstOrDefault();
                var question = _questionRepository.Find(k => k.Id == qId).FirstOrDefault();
                var qst = new QAnswerPerPercentDto() { AgentId = agentId, AgentName = agentName, Question = question.QuestionText, QId = qId, FormId = fcev.FormId, FormNAme = frm.Name, FormScore = fcev.Score, AId = 0 };
                questionsAnswersTemplateContainer.Add(qst);
                var answers = _answerRepository.Find(k => k.QuestionId == qId).ToList();
                foreach (Answers answer in answers)
                {
                    var ans = new QAnswerPerPercentDto() { Question = answer.AnswerText, QId = qId, AId = answer.Id, AnswerScore = answer.Score };
                    questionsAnswersTemplateContainer.Add(ans);
                }
            }

            foreach (CallsEvaluated ce in ces)
            {
                var isAddedQr = qresult.Where(k => k.QId == ce.QuestionId).FirstOrDefault();
                if (isAddedQr == null)
                {
                    qresult.Add(questionsAnswersTemplateContainer.Where(k => k.QId == ce.QuestionId && k.AId == 0).FirstOrDefault());
                }
                else
                {
                    continue;
                }
                var addedQAnswers = questionsAnswersTemplateContainer.Where(k => k.QId == ce.QuestionId && k.AId != 0).ToList();
                for (var i = 0; i < addedQAnswers.Count; i++)
                {
                    var addedQAnswer = addedQAnswers[i];
                    addedQAnswer.Quantity = ces2.Where(k => k.AnswerId == addedQAnswer.AId).ToList().Count;
                    addedQAnswer.Point = addedQAnswer.AnswerScore;
                }

                for (var n = 0; n < addedQAnswers.Count; n++)
                {
                    var addedQAnswer = addedQAnswers[n];
                    addedQAnswer.Percent = (addedQAnswer.Quantity * 100) / addedQAnswers.Select(k => k.Quantity).Sum();
                }

                qresult.AddRange(addedQAnswers);
            }

            return qresult.AsQueryable();
        }

        public IQueryable<CategoryReportsDto> GetCategoriesByFilters(DateTime startDate, DateTime endDate, Int32 startRecord, Int32 maxRecords, String sortColumns, string reporterId, string formId, bool isAdmQ)
        {
            var result = new List<CategoryReportsDto>();
            if (startDate.ToString().Contains("0001"))
            {
                startDate = DateTime.Now.AddDays(-30);
                endDate = DateTime.Now;
            }

            var frmId = Convert.ToInt32(formId == null ? "0" : formId);
            var fceIds = new List<int>();

            if (isAdmQ)
            {
                var aqEvaluater = _agentsRepository.Find(k => k.AgentTypeId == 1 || k.AgentTypeId == 2).Select(m => m.Id).ToList();
                if (frmId != 0)
                {
                    fceIds = _formsCallsRepository.Find(k => k.Date >= startDate && k.Date <= endDate && k.FormId == frmId && aqEvaluater.Contains(k.EvaluatorId)).Select(i => i.Id).ToList();
                }
                else
                {
                    fceIds = _formsCallsRepository.Find(k => k.Date >= startDate && k.Date <= endDate && aqEvaluater.Contains(k.EvaluatorId)).Select(i => i.Id).ToList();
                }
            }
            else
            {
                if (frmId != 0)
                {
                    fceIds = _formsCallsRepository.Find(k => k.Date >= startDate && k.Date <= endDate && k.FormId == frmId).Select(i => i.Id).ToList();
                }
                else
                {
                    fceIds = _formsCallsRepository.Find(k => k.Date >= startDate && k.Date <= endDate).Select(i => i.Id).ToList();
                }
            }

            if (fceIds.Count == 0)
            {
                return result.AsQueryable();
            }
            var ces = _callsEvaluatedRepository.Find(k => fceIds.Contains(k.FormCallId)).ToList();

            var formCallIds = ces.Select(k => k.FormCallId).Distinct().ToList();

            var afrmcid = Convert.ToInt32(formCallIds[0]);

            var evaluatedForm = _formsCallsEvaluatedRepository.Find(k => k.Id == afrmcid).FirstOrDefault();
            _formsCallsRepository.Find(k => k.Id == afrmcid).FirstOrDefault();
            var currentFormId = evaluatedForm.FormId;
            var formSectionsIds = _formsSectionsRepository.Find(k => k.FormId == currentFormId).Select(m => m.SectionId).ToList();
            var pureSectionIds = _sectionsRepository.Find(k => formSectionsIds.Contains(k.Id) && k.IsDisabled == false).Select(m => m.Id).ToList();
            var categoryIds = _sectionsCategoriesRepository.Find(k => pureSectionIds.Contains(k.SectionId)).Select(m => m.CategoryId).ToList();
            var categories = _categoriesRepository.Find(k => categoryIds.Contains(k.Id)).ToList();

            foreach (Categories category in categories)
            {
                var questionIds = _categoriesQuestionsRepository.Find(k => k.CategoryId == category.Id).Select(m => m.QuestionId).ToList();
                var qAnswerIds = ces.Where(k => questionIds.Contains(k.QuestionId)).Select(m => m.AnswerId).ToList();
                var distinctQuestionIds = qAnswerIds.Distinct().ToList();

                var qScore = _answerRepository.Find(k => distinctQuestionIds.Contains(k.Id)).Sum(m => m.Score);

                var qTtotalScore = 0;
                if (qAnswerIds.Count > 0)
                {
                    var ansGrpIds = qAnswerIds.Distinct().ToList();
                    foreach (int scoreGroup in ansGrpIds)
                    {
                        var currAnswerGroup = qAnswerIds.Where(k => k == scoreGroup).ToList();
                        int oneScore = _answerRepository.Find(k => k.Id == scoreGroup).FirstOrDefault().Score;
                        qTtotalScore += oneScore * currAnswerGroup.Count;
                    }
                }

                var averagePoint = (double)((double)qTtotalScore / (double)(qAnswerIds.Count / questionIds.Count));
                var percentAverage = (100 * averagePoint) / (double)qScore;

                var cdto = new CategoryReportsDto()
                { CategoryName = category.Name,
                    MaxPoint = qScore,
                    Point = Math.Round(averagePoint, 2),
                    Quantity = qAnswerIds.Count / questionIds.Count,
                    Percent = Math.Round((decimal)percentAverage, 2)
                };
                result.Add(cdto);
            }

            return result.AsQueryable();
        }

        public DataTable GetCategoryPointsByFilters(DateTime startDate, DateTime endDate, Int32 startRecord, Int32 maxRecords, String sortColumns, string reporterId, bool isAdmQ, string formId = "5")
        {
            var tb = new DataTable();
            if (formId == null || formId == "0")
            {
                return tb;
            }

            if (startDate.ToString().Contains("0001"))
            {
                startDate = DateTime.Now.AddDays(-90);
                endDate = DateTime.Now;
            }

            var agents = new List<int>();
            if (isAdmQ)
            {
                var aqEvaluater = _agentsRepository.Find(k => k.AgentTypeId == 1 || k.AgentTypeId == 2).Select(m => m.Id).ToList();
                agents = _agentsRepository.Find(k => k.Resignation == false && k.AgentTypeId == 5 && aqEvaluater.Contains(k.Id)).Select(m => m.Id).ToList();
            }
            else
            {
                agents = _agentsRepository.Find(k => k.Resignation == false && k.AgentTypeId == 5).Select(m => m.Id).ToList();
            }
            var frmId = Convert.ToInt32(formId);
            var pureSectionIds = _formsSectionsRepository.Find(k => k.FormId == frmId).Select(m => m.SectionId).ToList();
            var categoryIds = _sectionsCategoriesRepository.Find(k => pureSectionIds.Contains(k.SectionId)).Select(m => m.CategoryId).ToList();
            var categories = new List<string>();

            var categoryNames = string.Empty;
            foreach (int catId in categoryIds)
            {
                var cats = _categoriesRepository.Find(k => k.Id == catId).FirstOrDefault();
                categories.Add(cats.Name + "~" + cats.Id);
                categoryNames += cats.Name + "~";
            }

            var table = new DataTable();
            table.Columns.Add("Agent", typeof(string));
            var catIds = new List<int>();
            foreach (string category in categories)
            {
                var cname = category.Split('~');
                table.Columns.Add(cname[0].ToString(), typeof(string));
                catIds.Add(Convert.ToInt32(cname[1]));
            }

            var fid = Convert.ToInt32(formId);
            var detailForms = _detailFormRepository.All().ToList();
            foreach (int agentId in agents)
            {
                string agentCatPointsArr = "";
                DataTable evaluations = _unitOfWork.GetEvaluations(agentId, startDate, endDate, fid);
                if (evaluations.Rows.Count == 0)
                    continue;

                int[] scoreLine = new int[catIds.Count];

                foreach (DataRow dr in evaluations.Rows)
                {
                    int ed = Convert.ToInt32(dr[0]);
                    DataTable evaluationDetail = _unitOfWork.GetEvaluationDetail(ed);

                    List<CategoryResponses> cres = new List<CategoryResponses>();
                    cres = (from DataRow row in evaluationDetail.Rows
                       select new CategoryResponses
                       {
                            CategoryId = Convert.ToInt32(row["CategoryId"]),
                           Score = Convert.ToInt32(row["Score"])

                       }).ToList();

                    var ind = 0;
                    foreach (int cid in catIds)
                    {
                        int categoryScore = cres.Where(k=> k.CategoryId == cid).Sum(m=> m.Score);
                        scoreLine[ind] = categoryScore == null ? 0 : categoryScore + scoreLine[ind];
                        ind++;
                    }
                }

                var ind2 = 0;
                foreach (int score in scoreLine)
                {
                    ind2++;
                    if (ind2 < scoreLine.Count())
                    {
                        agentCatPointsArr += (score / evaluations.Rows.Count) + "~";
                    }
                    else
                    {
                        agentCatPointsArr += (score / evaluations.Rows.Count);
                    }
                    agentCatPointsArr = agentCatPointsArr.Replace("NaN", string.Empty);
                }

                var agnt = _agentsRepository.Find(k => k.Id == agentId).FirstOrDefault();
                var fullArr = agnt.FirstName + " " + agnt.LastName + "~" + agentCatPointsArr;
                table.Rows.Add(fullArr.Split('~'));
                table.AcceptChanges();
            }

            return table;
        }

        public class CategoryResponses
        {
            private int _categoryId = 0;

            public int CategoryId
            {
                get
                {
                    return _categoryId;
                }
                set
                {
                    _categoryId = value;
                }
            }

            private int _score = 0;

            public int Score
            {
                get
                {
                    return _score;
                }
                set
                {
                    _score = value;
                }
            }
        }

        public IQueryable<CategoryReportsDto> GetCategoriesByFiltersOutCalls(DateTime startDate, DateTime endDate, Int32 startRecord, Int32 maxRecords, String sortColumns, string reporterId, string formId, bool isAdmQ)
        {
            var result = new List<CategoryReportsDto>();

            if (formId == null)
            {
                return result.AsQueryable();
            }
            if (startDate.ToString().Contains("0001"))
            {
                startDate = DateTime.Now.AddDays(-30);
                endDate = DateTime.Now;
            }

            var frmId = Convert.ToInt32(formId == null ? "0" : formId);
            var fceIds = new List<int>();

            if (isAdmQ)
            {
                var aqEvaluater = _agentsRepository.Find(k => k.AgentTypeId == 1 || k.AgentTypeId == 2).Select(m => m.Id).ToList();
                if (frmId != 0)
                {
                    fceIds = _formsCallsRepository.Find(k => k.Date >= startDate && k.Date <= endDate && k.FormId == frmId && aqEvaluater.Contains(k.EvaluatorId)).Select(i => i.Id).ToList();
                }
                else
                {
                    fceIds = _formsCallsRepository.Find(k => k.Date >= startDate && k.Date <= endDate && aqEvaluater.Contains(k.EvaluatorId)).Select(i => i.Id).ToList();
                }
            }
            else
            {
                if (frmId != 0)
                {
                    fceIds = _formsCallsRepository.Find(k => k.Date >= startDate && k.Date <= endDate && k.FormId == frmId).Select(i => i.Id).ToList();
                }
                else
                {
                    fceIds = _formsCallsRepository.Find(k => k.Date >= startDate && k.Date <= endDate).Select(i => i.Id).ToList();
                }
            }

            var ces = _callsEvaluatedRepository.Find(k => fceIds.Contains(k.FormCallId)).ToList();

            var forConsolideItems = new List<CategoryReportsDto>();
            var formCallIds = ces.Select(k => k.FormCallId).Distinct().ToList();
            if (formCallIds.Count == 0)
            {
                return null;
            }
            var formCallId = formCallIds[0];

            var evaluatedForm = _formsCallsEvaluatedRepository.Find(k => k.Id == formCallId).FirstOrDefault();
            _formsCallsRepository.Find(k => k.Id == formCallId).FirstOrDefault();
            var currentFormId = evaluatedForm.FormId;
            var formSectionsIds = _formsSectionsRepository.Find(k => k.FormId == currentFormId).Select(m => m.SectionId).ToList();
            var pureSectionIds = _sectionsRepository.Find(k => formSectionsIds.Contains(k.Id) && k.IsDisabled == false).Select(m => m.Id).ToList();
            var categoryIds = _sectionsCategoriesRepository.Find(k => pureSectionIds.Contains(k.SectionId)).Select(m => m.CategoryId).ToList();
            var categories = _categoriesRepository.Find(k => categoryIds.Contains(k.Id)).ToList();

            foreach (Categories category in categories)
            {
                var questionIds = _categoriesQuestionsRepository.Find(k => k.CategoryId == category.Id).Select(m => m.QuestionId).ToList();

                var qAnswerIds = new List<int>();
                foreach (int qid in questionIds)
                {
                    qAnswerIds = ces.Where(k => k.QuestionId == qid).Select(m => m.AnswerId).ToList();
                    var qTtotalScore = 0;
                    if (qAnswerIds.Count > 0)
                    {
                        var ansGrpIds = qAnswerIds.Distinct().ToList();
                        foreach (int scoreGroup in ansGrpIds)
                        {
                            var currAnswerGroup = qAnswerIds.Where(k => k == scoreGroup).ToList();
                            int oneScore = _answerRepository.Find(k => k.Id == scoreGroup).FirstOrDefault().Score;
                            qTtotalScore += oneScore * currAnswerGroup.Count;
                        }
                    }

                    var ques = _questionRepository.Find(k => k.Id == qid).FirstOrDefault();
                    var qScore = _answerRepository.Find(k => k.QuestionId == ques.Id).Select(m => m.Score).Max();

                    var averagePoint = (double)((double)qTtotalScore / (double)qAnswerIds.Count);
                    var percentAverage = (100 * averagePoint) / (double)qScore;

                    var cdto = new CategoryReportsDto()
                    { QuestionName = ques.QuestionText,
                        MaxPoint = qScore,
                        MiddlePoint = Math.Round(averagePoint, 2),
                        Quantity = qAnswerIds.Count,
                        Percent = Math.Round((decimal)percentAverage, 2)
                    };
                    forConsolideItems.Add(cdto);
                }
            }


            return forConsolideItems.AsQueryable();
        }

        public DataTable GetAgentsPointsByMonthly(DateTime startDate, DateTime endDate, Int32 startRecord, Int32 maxRecords, String sortColumns, string reporterId, string selectedAgentId, string formId, bool isAdmQ)
        {
            if (formId == null || formId == "0" || startDate.ToString().Contains("0001"))
            {
                var tb = new DataTable();
                return tb;
            }

            var agents = _agentsRepository.Find(k => k.Resignation == false && k.AgentTypeId == 5).Select(m => m.Id).ToList();
            var agentManagers = new List<int>();
            if (isAdmQ)
            {
                var aqEvaluater = _agentsRepository.Find(k => k.AgentTypeId == 1 || k.AgentTypeId == 2).Select(m => m.Id).ToList();
                agentManagers = _agentsRepository.Find(k => k.Resignation == false && aqEvaluater.Contains(k.Id)).Select(m => m.Id).ToList();
            }

            var table = new DataTable();
            table.Columns.Add("AgentName", typeof(string));
            var columnCount = (endDate.Month - startDate.Month) + 1;
            if (columnCount <= 0)
            {
                return table;
            }
            for (var k = 0; k < columnCount; k++)
            {
                table.Columns.Add(_months[startDate.Month + (k - 1)].ToString(), typeof(string));
            }
            foreach (int agent in agents)
            {
                var agentId = Convert.ToInt32(agent);
                var scoreAverage = string.Empty;
                for (var i = 0; i < columnCount; i++)
                {
                    var sdate = new DateTime(startDate.Year, startDate.Month + i, 1);
                    var edate = new DateTime(endDate.Year, startDate.Month + i, System.DateTime.DaysInMonth(endDate.Year, startDate.Month + i));

                    var fid = Convert.ToInt32(formId);
                    var fce = new List<FormsCalls>();
                    if (isAdmQ)
                    {
                        fce = _formsCallsRepository.Find(k => k.AgentId == agentId && agentManagers.Contains(k.EvaluatorId) && k.DateStarted > sdate && k.DateStarted < edate && k.FormId == fid).ToList();
                    }
                    else
                    {
                        fce = _formsCallsRepository.Find(k => k.AgentId == agentId && k.DateStarted > sdate && k.DateStarted < edate && k.FormId == fid).ToList();
                    }

                    if (i < columnCount - 1)
                    {
                        scoreAverage += (Math.Round((double)((double)fce.Sum(m => m.Score) / fce.Count), 2)).ToString() + "~";
                    }
                    else
                    {
                        scoreAverage += (Math.Round((double)((double)fce.Sum(m => m.Score) / fce.Count), 2)).ToString();
                    }
                    scoreAverage = scoreAverage.Replace("NaN", string.Empty);
                }

                var ages = _agentsRepository.Find(k => k.Id == agentId).FirstOrDefault();
                var paramsArr = (ages.FirstName + " " + ages.LastName + "~" + scoreAverage).ToString().Split('~');
                table.Rows.Add(paramsArr);
                table.AcceptChanges();
            }

            return table;
        }
    }
}
