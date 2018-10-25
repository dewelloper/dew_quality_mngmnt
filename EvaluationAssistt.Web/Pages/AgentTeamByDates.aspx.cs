using EvaluationAssistt.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace EvaluationAssistt.Web.Pages
{
    public partial class AgentTeamByDates : EvaluationAssisttPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserHelper.Type == Infrastructure.Enums.UserType.Agent)
            {
                Response.Redirect("~/Redirections/Error403.Aspx");
            }
            if (UserHelper.Type == Infrastructure.Enums.UserType.TeamLeader)
            {
                chkQualityAdmin.Visible = false;
            }
            if (!IsPostBack)
            {
                ASPxGridView2.SettingsPager.PageSize = 20;
            }
        }

        protected void btnTeamCalls_Click(object sender, EventArgs e)
        {
            var startDate = Convert.ToDateTime(aspxDateStart2.Value);
            var endDate = Convert.ToDateTime(aspxDateEnd2.Value);

            var reporterId = "0";
            if (UserHelper.Type != Infrastructure.Enums.UserType.Agent)
            {
                reporterId = UserHelper.UserId.ToString();
            }
            ods2.SelectParameters.Clear();
            ods2.SelectParameters.Add(new Parameter() { DbType = DbType.DateTime, DefaultValue = startDate.ToString(), Name = "startDate" });
            ods2.SelectParameters.Add(new Parameter() { DbType = DbType.DateTime, DefaultValue = endDate.ToString(), Name = "endDate" });
            ods2.SelectParameters.Add(new Parameter() { DbType = DbType.String, DefaultValue = reporterId, Name = "reporterId" });
            ods2.SelectParameters.Add(new Parameter() { DbType = DbType.Boolean, DefaultValue = chkQualityAdmin.Checked.ToString(), Name = "isAdmQ" });
            ods2.Update();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            ASPxGridViewExporter1.WriteXlsToResponse();
        }

        protected void btnExportPdf_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            ASPxGridViewExporter1.WritePdfToResponse();
        }

        protected void btnExportRtf_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            ASPxGridViewExporter1.WriteRtfToResponse();
        }

        protected void btnExportCsv_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            ASPxGridViewExporter1.WriteCsvToResponse();
        }
    }
}
