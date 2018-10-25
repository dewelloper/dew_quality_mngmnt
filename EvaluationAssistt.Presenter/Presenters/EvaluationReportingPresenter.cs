using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Presenter.Presenters
{
    public class EvaluationReportingPresenter
    {
        private readonly IReportingView _view;
        private static EvaluationReportingService _reportingService = new EvaluationReportingService();
        private static AgentsService _agentService = new AgentsService();
        private static FormsService _formsService = new FormsService();

        public EvaluationReportingPresenter(IReportingView view)
        {
            _view = view;
        }

        public IQueryable<FormsCallsDto> GetFormCallsByFilter(DateTime startDate, DateTime endDate)
        {
            var result = _reportingService.GetFormCallsByFilter(startDate, endDate, 0, 0, string.Empty, "0", false);
            var result2 = _reportingService.UpdateCallsDto(result);
            _view.FormsCalls = result2;
            return result2;
        }

        public IQueryable<FormsCallsDto> GetFormCallsByFilter(DateTime startDate, DateTime endDate, Int32 startRecord, Int32 maxRecords, String sortColumns, string reporterId)
        {
            var result = _reportingService.GetFormCallsByFilter(startDate, endDate, startRecord, maxRecords, sortColumns, reporterId, false);
            var result2 = _reportingService.UpdateCallsDto(result);
            return result2;
        }

        public IQueryable<CallsOfAgentDto> GetSpecifiedCall(int formId)
        {
            var res = _reportingService.GetSpecifiedCall(formId);
            _view.CallsOfAgents = res;
            return res;
        }

        public IQueryable<AgentsDto> GetAllAgents()
        {
            var agents = _agentService.GetAgentsAllForCombo();
            _view.Agents = agents;
            return agents;
        }

        public IQueryable<FormsDto> GetAllForms()
        {
            var forms = _formsService.GetFormsAll();
            _view.Forms = forms;
            return forms;
        }
    }
}
