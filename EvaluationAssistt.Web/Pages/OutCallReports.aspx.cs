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
    public partial class OutCallReports : EvaluationAssisttPage
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
            Forms = _repPresenter.GetAllForms();
        }

        protected void btncExport3_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            ASPxGridViewExporter1.WriteXlsToResponse();
        }

        protected void btncExportPdf3_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            ASPxGridViewExporter1.WritePdfToResponse();
        }

        protected void btncExportRtf3_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            ASPxGridViewExporter1.WriteRtfToResponse();
        }

        protected void btncExportCsv3_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            ASPxGridViewExporter1.WriteCsvToResponse();
        }

        public IQueryable<AgentsDto> Agents
        {
            set
            {
            }
        }

        public IQueryable<FormsDto> Forms
        {
            set
            {
                var ad = new FormsDto() { Id = 0, Name = "Seçiniz..." };
                var source = new List<FormsDto>();
                if (acmbcForms.DataSource == null)
                {
                    source.Add(ad);
                }
                source.AddRange(value.ToList());
                acmbcForms.DataSource = source;

                acmbcForms.TextField = "Name";
                acmbcForms.ValueField = "Id";
                acmbcForms.DataBind();
            }
        }

        protected void btnCatQuery_Click(object sender, EventArgs e)
        {
            var startDate = Convert.ToDateTime(axdcStartDate.Value);
            var endDate = Convert.ToDateTime(axdcEndDate.Value);

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
            var formId = acmbcForms.SelectedItem == null ? "0" : acmbcForms.SelectedItem.Value.ToString();

            odsc4.SelectParameters.Clear();
            odsc4.SelectParameters.Add(new Parameter() { DbType = DbType.DateTime, DefaultValue = startDate.ToString(), Name = "startDate" });
            odsc4.SelectParameters.Add(new Parameter() { DbType = DbType.DateTime, DefaultValue = endDate.ToString(), Name = "endDate" });
            odsc4.SelectParameters.Add(new Parameter() { DbType = DbType.String, DefaultValue = reporterId, Name = "reporterId" });
            odsc4.SelectParameters.Add(new Parameter() { DbType = DbType.String, DefaultValue = formId, Name = "formId" });
            odsc4.SelectParameters.Add(new Parameter() { DbType = DbType.Boolean, DefaultValue = chkQualityAdminAgent.Checked.ToString(), Name = "isAdmQ" });
            odsc4.Update();
        }
    }
}
