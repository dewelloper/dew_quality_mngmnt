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
    public partial class CategoryPointReports : EvaluationAssisttPage
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
            if (!IsPostBack && Session["Reload"] == null)
            {
                Forms = _repPresenter.GetAllForms();
            }
        }

        public IQueryable<FormsDto> Forms
        {
            set
            {
                var ad = new FormsDto() { Id = 0, Name = "Seçiniz..." };
                var source = new List<FormsDto>();
                if (acmbPForms.DataSource == null)
                {
                    source.Add(ad);
                }
                source.AddRange(value.ToList());
                acmbPForms.DataSource = source;

                acmbPForms.TextField = "Name";
                acmbPForms.ValueField = "Id";
                acmbPForms.DataBind();

                if (Session["SelectedIndex"] != null)
                {
                    acmbPForms.SelectedIndex = Convert.ToInt32(Session["SelectedIndex"]);
                    axdpStartDate.Text = Session["StartDate"].ToString();
                    axdPEndDate.Text = Session["EndDate"].ToString();
                }
            }
        }

        protected void btnPCatQuery_Click(object sender, EventArgs e)
        {
            var startDate = Convert.ToDateTime(axdpStartDate.Value);
            var endDate = Convert.ToDateTime(axdPEndDate.Value);

            var ts = endDate - startDate;
            var difDays = ts.Days;
            if (difDays > 31)
            {
                alblMessage.Text = "Dikkat! Seçilen tarih aralığı 31 günü geçemez...";
                return;
            }

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
            var formId = acmbPForms.SelectedItem == null ? "0" : acmbPForms.SelectedItem.Value.ToString();

            odsPoint.SelectParameters.Clear();
            odsPoint.SelectParameters.Add(new Parameter() { DbType = DbType.DateTime, DefaultValue = startDate.ToString(), Name = "startDate" });
            odsPoint.SelectParameters.Add(new Parameter() { DbType = DbType.DateTime, DefaultValue = endDate.ToString(), Name = "endDate" });
            odsPoint.SelectParameters.Add(new Parameter() { DbType = DbType.String, DefaultValue = reporterId, Name = "reporterId" });
            odsPoint.SelectParameters.Add(new Parameter() { DbType = DbType.String, DefaultValue = formId, Name = "formId" });
            odsPoint.SelectParameters.Add(new Parameter() { DbType = DbType.Boolean, DefaultValue = chkQualityAdminAgent.Checked.ToString(), Name = "isAdmQ" });
            odsPoint.Update();
        }

        protected void btnExportP3_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            ASPxGridViewExporter1.WriteXlsToResponse();
        }

        protected void btnExportPdfP3_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            ASPxGridViewExporter1.WritePdfToResponse();
        }

        protected void btnExportRtfP3_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            ASPxGridViewExporter1.WriteRtfToResponse();
        }

        protected void btnExportCsvP3_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            ASPxGridViewExporter1.WriteCsvToResponse();
        }

        protected void odsPoint_DataBinding(object sender, EventArgs e)
        {
        }

        protected void odsPoint_Load(object sender, EventArgs e)
        {
        }

        protected void acmbPForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["SelectedIndex"] = acmbPForms.SelectedIndex;
            Session["StartDate"] = axdpStartDate.Text;
            Session["EndDate"] = axdPEndDate.Text;
            Page.Response.Redirect(Page.Request.Url.ToString(), false);
        }
    }
}
