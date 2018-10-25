using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Infrastructure.Helpers;
using EvaluationAssistt.Presenter.Presenters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace EvaluationAssistt.Web.Pages
{
    public partial class AgentMonthlyPointsReports : EvaluationAssisttPage
    {
        private EvaluationReportingPresenter _repPresenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserHelper.Type != Infrastructure.Enums.UserType.Admin && UserHelper.Type != Infrastructure.Enums.UserType.QualityExpert)
            {
                Response.Redirect("~/Redirections/Error403.Aspx");
            }
            if (_repPresenter == null)
            {
                _repPresenter = new EvaluationReportingPresenter(this);
            }
            Agents = _repPresenter.GetAllAgents();
            Forms = _repPresenter.GetAllForms();
        }

        protected void btntAKQuery_Click(object sender, EventArgs e)
        {
            var startDate = Convert.ToDateTime(aspxtDateStart3.Value);
            var endDate = Convert.ToDateTime(aspxtDateEnd3.Value);

            var reporterId = "0";
            if (UserHelper.Type == Infrastructure.Enums.UserType.Admin || UserHelper.Type == Infrastructure.Enums.UserType.QualityExpert)
            {
                reporterId = "9999999";
            }
            else
            {
                if (UserHelper.Type == Infrastructure.Enums.UserType.TeamLeader)
                {
                    reporterId = UserHelper.UserId.ToString();
                }
            }
            var selectedAgentId = cmbtAgents.SelectedItem == null ? "0" : cmbtAgents.SelectedItem.Value.ToString();
            var formId = cmbtForms.SelectedItem == null ? "0" : cmbtForms.SelectedItem.Value.ToString();

            ods3.SelectParameters.Clear();
            ods3.SelectParameters.Add(new Parameter() { DbType = DbType.DateTime, DefaultValue = startDate.ToString(), Name = "startDate" });
            ods3.SelectParameters.Add(new Parameter() { DbType = DbType.DateTime, DefaultValue = endDate.ToString(), Name = "endDate" });
            ods3.SelectParameters.Add(new Parameter() { DbType = DbType.String, DefaultValue = reporterId, Name = "reporterId" });
            ods3.SelectParameters.Add(new Parameter() { DbType = DbType.String, DefaultValue = selectedAgentId, Name = "selectedAgentId" });
            ods3.SelectParameters.Add(new Parameter() { DbType = DbType.String, DefaultValue = formId, Name = "formId" });
            ods3.SelectParameters.Add(new Parameter() { DbType = DbType.Boolean, DefaultValue = chkQualityAdmin.Checked.ToString(), Name = "isAdmQ" });
            ods3.Update();
        }

        protected void btntExport3_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter3.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            ASPxGridViewExporter3.WriteXlsToResponse();
        }

        protected void btntExportPdf3_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter3.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            ASPxGridViewExporter3.WritePdfToResponse();
        }

        protected void btntExportRtf3_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter3.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            ASPxGridViewExporter3.WriteRtfToResponse();
        }

        protected void btntExportCsv3_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter3.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            ASPxGridViewExporter3.WriteCsvToResponse();
        }

        public IQueryable<AgentsDto> Agents
        {
            set
            {
                var ad = new AgentsDto() { Id = 0, FirstName = "Seçiniz..." };
                var source = new List<AgentsDto>();
                if (cmbtAgents.DataSource == null)
                {
                    source.Add(ad);
                }
                source.AddRange(value.ToList());
                cmbtAgents.DataSource = source;

                cmbtAgents.TextField = "FirstName";
                cmbtAgents.ValueField = "Id";
                cmbtAgents.DataBind();
            }
        }

        public IQueryable<FormsDto> Forms
        {
            set
            {
                var ad = new FormsDto() { Id = 0, Name = "Seçiniz..." };
                var source = new List<FormsDto>();
                if (cmbtForms.DataSource == null)
                {
                    source.Add(ad);
                }
                source.AddRange(value.ToList());
                cmbtForms.DataSource = source;

                cmbtForms.TextField = "Name";
                cmbtForms.ValueField = "Id";
                cmbtForms.DataBind();
            }
        }
    }
}
