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
    public partial class AdminCategoryReports : EvaluationAssisttPage
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

        protected void btnExport3_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            ASPxGridViewExporter1.WriteXlsToResponse();
        }

        protected void btnExportPdf3_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            ASPxGridViewExporter1.WritePdfToResponse();
        }

        protected void btnExportRtf3_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            ASPxGridViewExporter1.WriteRtfToResponse();
        }

        protected void btnExportCsv3_Click(object sender, EventArgs e)
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
                if (acmbForms.DataSource == null)
                {
                    source.Add(ad);
                }
                source.AddRange(value.ToList());
                acmbForms.DataSource = source;

                acmbForms.TextField = "Name";
                acmbForms.ValueField = "Id";
                acmbForms.DataBind();
            }
        }

        protected void btnCatQuery_Click(object sender, EventArgs e)
        {
            var startDate = Convert.ToDateTime(axdStartDate.Value);
            var endDate = Convert.ToDateTime(axdEndDate.Value);

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
            var formId = acmbForms.SelectedItem == null ? "0" : acmbForms.SelectedItem.Value.ToString();

            ods4.SelectParameters.Clear();
            ods4.SelectParameters.Add(new Parameter() { DbType = DbType.DateTime, DefaultValue = startDate.ToString(), Name = "startDate" });
            ods4.SelectParameters.Add(new Parameter() { DbType = DbType.DateTime, DefaultValue = endDate.ToString(), Name = "endDate" });
            ods4.SelectParameters.Add(new Parameter() { DbType = DbType.String, DefaultValue = reporterId, Name = "reporterId" });
            ods4.SelectParameters.Add(new Parameter() { DbType = DbType.String, DefaultValue = formId, Name = "formId" });
            ods4.SelectParameters.Add(new Parameter() { DbType = DbType.Boolean, DefaultValue = chkQualityAdmin.Checked.ToString() , Name = "isAdmQ" });
            ods4.Update();
        }
    }
}
